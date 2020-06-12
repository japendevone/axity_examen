using ExamService.Domain.Seed.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.Domain.Seed
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        #region Properties
        IUnitOfWork UnitOfWork { get; }
        #endregion

        #region Methods
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void TrackItem(T item);
        void Merge(T persisted, T current);
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> AllMatching(ISpecification<T> specification);
        IEnumerable<T> GetPaged<KProperty>(
            int pageIndex,
            int pageSize,
            Expression<Func<T, KProperty>> orderByExpression,
            IEnumerable<T> dbset,
            ISpecification<T> specification,
            bool ascending,
            out int pages,
            out int registers);
        IEnumerable<T> GetPaged<KProperty>(
            int pageIndex,
            int pageSize,
            Expression<Func<T, KProperty>> orderByExpression,
            bool ascending,
            out int pages,
            out int registers);
        IEnumerable<T> GetPaged<KProperty>(
            int pageIndex,
            int pageSize,
            Expression<Func<T, KProperty>> orderByExpression,
            Expression<Func<T, bool>> filter,
            bool ascending,
            out int pages,
            out int registers);
        IEnumerable<T> GetPaged<KProperty>(
            int pageIndex,
            int pageSize,
            Expression<Func<T, KProperty>> orderByExpression,
            ISpecification<T> specification,
            bool ascending,
            out int pages,
            out int registers);

        IEnumerable<T> GetPaged<KProperty, kJoin, U>(
            int pageIndex,
            int pageSize,
            Expression<Func<T, KProperty>> orderByExpression,
            IEnumerable<U> inner,
            Expression<Func<T, kJoin>> outerKeySelector,
            Expression<Func<U, kJoin>> innerKeySelector,
            Expression<Func<T, U, T>> resultSelector,
            bool ascending,
            out int pages,
            out int registers) where U : Entity;
        IEnumerable<T> GetPaged<KProperty, kJoin, U>(
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
            out int registers) where U : Entity;
        IEnumerable<T> GetFiltered(Expression<Func<T, bool>> filter);
        #endregion
    }
}
