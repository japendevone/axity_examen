using ExamService.DataAccess.Main.UnitOfWork;
using ExamService.DataAccess.Seed;
using ExamService.Domain.Main.User.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.DataAccess.Main.User
{
    public class UserRepository : Repository<Domain.Main.User.Aggregates.User>, IUserRepository
    {
        public UserRepository(MainUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public Domain.Main.User.Aggregates.User UserLogin(string userName, string password)
        {
            var currentUnitOfWork = UnitOfWork as MainUnitOfWork;

            if (currentUnitOfWork == null)
                throw new ArgumentNullException(nameof(currentUnitOfWork));

            return currentUnitOfWork.Users.FirstOrDefault(x => x.Nombre == userName && x.Password == password);
        }
    }
}
