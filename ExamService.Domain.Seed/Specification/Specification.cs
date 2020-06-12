using ExamService.Domain.Seed.Specification;
using System;
using System.Linq.Expressions;

namespace ExamService.Domain.Seed.Specification
{
    public abstract class Specification<T> : ISpecification<T> where T : class
    {
        #region ISpecification<T> Members
        public abstract Expression<Func<T, bool>> SatisfiedBy();
        #endregion

        #region Override Operators
        public static Specification<T> operator &(Specification<T> leftSideSpecification, Specification<T> rightSideSpecification)
        {
            return new AndSpecification<T>(leftSideSpecification, rightSideSpecification);
        }

        public static Specification<T> operator |(Specification<T> leftSideSpecification, Specification<T> rightSideSpecification)
        {
            return new OrSpecification<T>(leftSideSpecification, rightSideSpecification);
        }

        public static Specification<T> operator !(Specification<T> specification)
        {
            return new NotSpecification<T>(specification);
        }

        public static bool operator false(Specification<T> specification)
        {
            return false;
        }

        public static bool operator true(Specification<T> specification)
        {
            return false;
        }
        #endregion
    }
}