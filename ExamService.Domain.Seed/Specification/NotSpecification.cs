using System;
using System.Linq;
using System.Linq.Expressions;

namespace ExamService.Domain.Seed.Specification
{
    public sealed class NotSpecification<T> : Specification<T> where T : class
    {
        #region Members
        Expression<Func<T, bool>> _OriginalCriteria;
        #endregion

        #region Constructor
        public NotSpecification(ISpecification<T> originalSpecification)
        {

            if (originalSpecification == (ISpecification<T>)null)
                throw new ArgumentNullException("originalSpecification");

            _OriginalCriteria = originalSpecification.SatisfiedBy();
        }

        public NotSpecification(Expression<Func<T, bool>> originalSpecification)
        {
            if (originalSpecification == (Expression<Func<T, bool>>)null)
                throw new ArgumentNullException("originalSpecification");

            _OriginalCriteria = originalSpecification;
        }
        #endregion

        #region Override Specification methods
        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Not(_OriginalCriteria.Body),
                                                         _OriginalCriteria.Parameters.Single());
        }

        #endregion
    }
}
