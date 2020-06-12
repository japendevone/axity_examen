using ExamService.Domain.Seed;
using ExamService.Domain.Seed.Specification;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.DataAccess.Seed
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        #region Members
        private IQueryableUnitOfWork _UnitOfWork;
        #endregion

        #region Constructor
        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        #endregion

        #region IRepository Members
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return this._UnitOfWork;
            }
        }

        public virtual void Add(T entity)
        {
            if (entity != (T)null)
                this.DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            if (entity != (T)null)
            {
                _UnitOfWork.SetModified(entity);
            }
        }

        public virtual void Delete(T entity)
        {
            if (entity != (T)null)
            {
                this._UnitOfWork.Attach(entity);

                this.DbSet.Remove(entity);
            }
        }

        public virtual void TrackItem(T entity)
        {
            if (entity != (T)null)
            {
                this._UnitOfWork.Attach<T>(entity);
            }
        }

        public virtual void Merge(T persisted, T current)
        {
            _UnitOfWork.ApplyCurrentValues(persisted, current);
        }

        public virtual T Get(int id)
        {
            return this.DbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.DbSet;
        }

        public virtual IEnumerable<T> AllMatching(ISpecification<T> specification)
        {
            return this.DbSet.Where(specification.SatisfiedBy());
        }

        public virtual IEnumerable<T> GetPaged<KProperty>(int pageIndex,
            int pageSize,
            Expression<Func<T, KProperty>> orderByExpression,
            IEnumerable<T> dbset,
            ISpecification<T> specification,
            bool ascending,
            out int pages,
            out int registers)
        {
            registers = dbset.Count();

            if (ascending)
            {
                var registersAscending = dbset.OrderBy(orderByExpression.Compile())
                    .Where(specification.SatisfiedBy().Compile());

                int countAscending = registersAscending.Count();
                pages = (int)(countAscending / pageSize);
                if (countAscending % pageSize > 0)
                    pages++;

                return registersAscending
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize);
            }
            else
            {
                var registersDescending = dbset.OrderByDescending(orderByExpression.Compile())
                    .Where(specification.SatisfiedBy().Compile());

                int countDescending = registersDescending.Count();
                pages = (int)(countDescending / pageSize);
                if (countDescending % pageSize > 0)
                    pages++;

                return registersDescending
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize);
            }
        }

        public virtual IEnumerable<T> GetPaged<KProperty>(
            int pageIndex,
            int pageSize,
            Expression<Func<T, KProperty>> orderByExpression,
            bool ascending,
            out int pages,
            out int registers)
        {
            var set = this.DbSet;

            registers = set.Count();
            pages = (int)(registers / pageSize);
            if (registers % pageSize > 0)
                pages++;

            if (ascending)
            {
                return set.OrderBy(orderByExpression)
                          .Skip(pageSize * pageIndex)
                          .Take(pageSize);
            }
            else
            {
                return set.OrderByDescending(orderByExpression)
                          .Skip(pageSize * pageIndex)
                          .Take(pageSize);
            }
        }

        public virtual IEnumerable<T> GetPaged<KProperty>(
            int pageIndex,
            int pageSize,
            Expression<Func<T, KProperty>> orderByExpression,
            Expression<Func<T, bool>> filter,
            bool ascending,
            out int pages,
            out int registers)
        {
            var set = this.DbSet;

            registers = set.Count();
            pages = (int)(registers / pageSize);
            if (registers % pageSize > 0)
                pages++;

            if (ascending)
            {
                var registersAscending = set.OrderBy(orderByExpression)
                          .Where(filter);

                int countAscending = registersAscending.Count();
                pages = (int)(countAscending / pageSize);
                if (countAscending % pageSize > 0)
                    pages++;

                return registersAscending
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize);
            }
            else
            {
                var registersDescending = set.OrderByDescending(orderByExpression)
                          .Where(filter);

                int countDescending = registersDescending.Count();
                pages = (int)(countDescending / pageSize);
                if (countDescending % pageSize > 0)
                    pages++;

                return registersDescending
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize);
            }
        }

        public virtual IEnumerable<T> GetPaged<KProperty>(
            int pageIndex,
            int pageSize,
            Expression<Func<T, KProperty>> orderByExpression,
            ISpecification<T> specification,
            bool ascending,
            out int pages,
            out int registers)
        {
            var set = this.DbSet;

            registers = set.Count();

            if (ascending)
            {
                var registersAscending = set.OrderBy(orderByExpression)
                    .Where(specification.SatisfiedBy());

                int countAscending = registersAscending.Count();
                pages = (int)(countAscending / pageSize);
                if (countAscending % pageSize > 0)
                    pages++;

                return registersAscending
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize);
            }
            else
            {
                var registersDescending = set.OrderByDescending(orderByExpression)
                    .Where(specification.SatisfiedBy());

                int countDescending = registersDescending.Count();
                pages = (int)(countDescending / pageSize);
                if (countDescending % pageSize > 0)
                    pages++;

                return registersDescending
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize);
            }
        }

        public virtual IEnumerable<T> GetPaged<KProperty, kJoin, U>(
            int pageIndex,
            int pageSize,
            Expression<Func<T, KProperty>> orderByExpression,
            IEnumerable<U> inner,
            Expression<Func<T, kJoin>> outerKeySelector,
            Expression<Func<U, kJoin>> innerKeySelector,
            Expression<Func<T, U, T>> resultSelector,
            bool ascending,
            out int pages,
            out int registers) where U : Entity
        {
            var set = this.DbSet;

            registers = set.Count();
            pages = (int)(registers / pageSize);
            if (registers % pageSize > 0)
                pages++;

            if (ascending)
            {
                var registersAscending = set.Join<T, U, kJoin, T>(inner, outerKeySelector, innerKeySelector, resultSelector)
                          .OrderBy(orderByExpression);

                int countAscending = registersAscending.Count();
                pages = (int)(countAscending / pageSize);
                if (countAscending % pageSize > 0)
                    pages++;

                return registersAscending
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize);
            }
            else
            {
                var registersDescending = set.Join<T, U, kJoin, T>(inner, outerKeySelector, innerKeySelector, resultSelector)
                          .OrderByDescending(orderByExpression);

                int countDescending = registersDescending.Count();
                pages = (int)(countDescending / pageSize);
                if (countDescending % pageSize > 0)
                    pages++;

                return registersDescending
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize);
            }
        }

        public virtual IEnumerable<T> GetPaged<KProperty, kJoin, U>(
            int pageIndex,
            int pageSize,
            Expression<Func<T, KProperty>> orderByExpression,
            IEnumerable<U> inner,
            Expression<Func<T, kJoin>> outerKeySelector,
            Expression<Func<U, kJoin>> innerKeySelector,
            Expression<Func<T, U, T>> resultSelector,
            ISpecification<T> specification,
            bool ascending,
            out int pages,
            out int registers) where U : Entity
        {
            var set = this.DbSet;

            registers = set.Count();
            pages = (int)(registers / pageSize);
            if (registers % pageSize > 0)
                pages++;

            if (ascending)
            {
                var registersAscending = set.Join<T, U, kJoin, T>(inner, outerKeySelector, innerKeySelector, resultSelector)
                          .OrderBy(orderByExpression)
                          .Where(specification.SatisfiedBy());

                int countAscending = registersAscending.Count();
                pages = (int)(countAscending / pageSize);
                if (countAscending % pageSize > 0)
                    pages++;

                return registersAscending
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize);
            }
            else
            {
                var registersDescending = set.Join<T, U, kJoin, T>(inner, outerKeySelector, innerKeySelector, resultSelector)
                          .OrderByDescending(orderByExpression)
                          .Where(specification.SatisfiedBy());

                int countDescending = registersDescending.Count();
                pages = (int)(countDescending / pageSize);
                if (countDescending % pageSize > 0)
                    pages++;

                return registersDescending
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize);
            }
        }

        public virtual IEnumerable<T> GetFiltered(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return this.DbSet.Where(filter);
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            if (this._UnitOfWork != null)
                this._UnitOfWork.Dispose();
        }
        #endregion

        #region Private Members
        private IDbSet<T> DbSet
        {
            get { return _UnitOfWork.CreateSet<T>(); }
        }
        #endregion
    }
}
