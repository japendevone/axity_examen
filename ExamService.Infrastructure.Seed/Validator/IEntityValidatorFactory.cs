namespace ExamService.Infrastructure.Seed.Validator
{
    public interface IEntityValidatorFactory
    {
        IEntityValidator Create();
    }
}