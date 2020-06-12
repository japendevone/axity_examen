using System;
using System.Linq.Expressions;

namespace ExamService.Domain.Seed.Specification
{
    public sealed class TrueSpecification<TEntity> : Specification<TEntity> where TEntity : class
    {
        #region Specification overrides
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            bool result = true;
            Expression<Func<TEntity, bool>> trueExpression = t => result;
            return trueExpression;
        }
        #endregion
    }
}