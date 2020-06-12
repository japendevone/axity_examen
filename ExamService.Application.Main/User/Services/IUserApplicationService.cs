using ExamService.Services.Main.DataContract.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.Application.Main.User.Services
{
    public interface IUserApplicationService : IDisposable
    {
        GetUserResponse GetUserByPassword(GetUserByPasswordRequest request);
    }
}
