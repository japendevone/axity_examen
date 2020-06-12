using System;
using System.Linq.Expressions;

namespace ExamService.Domain.Seed.Specification
{
    public interface ISpecification<T> where T : class
    {
        Expression<Func<T, bool>> SatisfiedBy();
    }
}
