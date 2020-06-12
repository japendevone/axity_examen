using ExamService.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.Domain.Main.User.Aggregates
{
    public interface IUserRepository : IRepository<User>
    {
        User UserLogin(string userName, string password);
    }
}
