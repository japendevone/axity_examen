using ExamService.Services.Main.DataContract.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.Application.Main.Mapping
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<Domain.Main.User.Aggregates.User, GetUserResponse>();
        }
    }
}
