using ExamService.Infrastructure.Seed.Validator;

namespace ExamService.Infrastructure.Main.Validator
{
    public class DataAnnotationsEntityValidatorFactory : IEntityValidatorFactory
    {
        public IEntityValidator Create()
        {
            return new DataAnnotationsEntityValidator();
        }
    }
}