using ExamService.Application.Seed;
using ExamService.Domain.Main.User.Aggregates;
using ExamService.Services.Main.DataContract.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.Application.Main.User.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserRepository _userRepository;

        public UserApplicationService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
        }

        public GetUserResponse GetUserByPassword(GetUserByPasswordRequest request)
        {
            return _userRepository.UserLogin(request.Nombre, request.Password).ProjectedAs<GetUserResponse>();
        }
    }
}
