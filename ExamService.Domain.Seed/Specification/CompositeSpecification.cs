namespace ExamService.Domain.Seed.Specification
{
    public abstract class CompositeSpecification<T> : Specification<T> where T : class
    {
        #region Properties
        public abstract ISpecification<T> LeftSideSpecification { get; }

        public abstract ISpecification<T> RightSideSpecification { get; }
        #endregion
    }
}
