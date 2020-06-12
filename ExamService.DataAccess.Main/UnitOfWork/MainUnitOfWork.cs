using ExamService.DataAccess.Main.UnitOfWork.Mapping;
using ExamService.DataAccess.Seed;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;


namespace ExamService.DataAccess.Main.UnitOfWork
{
    public class MainUnitOfWork : DbContext, IQueryableUnitOfWork
    {
        #region IDbSet Members

        private IDbSet<Domain.Main.User.Aggregates.User> _users;
        public IDbSet<Domain.Main.User.Aggregates.User> Users => _users ?? (_users = Set<Domain.Main.User.Aggregates.User>());

        private IDbSet<Domain.Main.Product.Aggregates.Product> _products;
        public IDbSet<Domain.Main.Product.Aggregates.Product> Products => _products ?? (_products = Set<Domain.Main.Product.Aggregates.Product>());

        #endregion

        #region Constructor
        public MainUnitOfWork()
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }
        #endregion

        #region IQueryableUnitOfWork Members
        public DbSet<TEntity> CreateSet<TEntity>()
            where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void Attach<TEntity>(TEntity item)
            where TEntity : class
        {
            Entry(item).State = EntityState.Unchanged;
        }

        public void SetModified<TEntity>(TEntity item)
            where TEntity : class
        {
            Entry(item).State = EntityState.Modified;
        }
        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current)
            where TEntity : class
        {
            Entry(original).CurrentValues.SetValues(current);
        }

        public void Commit()
        {
            base.SaveChanges();
        }

        public void CommitAndRefreshChanges()
        {
            bool saveFailed;

            do
            {
                try
                {
                    base.SaveChanges();

                    saveFailed = false;

                }
                catch (DbUpdateConcurrencyException exception)
                {
                    saveFailed = true;

                    exception.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });

                }
            } while (saveFailed);
        }

        public void RollbackChanges()
        {
            ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            return Database.SqlQuery<TEntity>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sqlCommand, parameters);
        }
        #endregion

        #region DbContext Overrides

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ProductEntityConfiguration());
            modelBuilder.Configurations.Add(new UserEntityConfiguration());
        }

        #endregion
    }
}
