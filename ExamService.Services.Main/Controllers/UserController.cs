using ExamService.Application.Main.User.Services;
using ExamService.Services.Main.DataContract.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExamService.Services.Main.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private readonly IUserApplicationService _userApplicationService;

        public UserController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService ??
                throw new ArgumentNullException(nameof(userApplicationService));
        }

        [HttpPost]
        public IHttpActionResult Login(GetUserByPasswordRequest request)
        {
            return Ok(_userApplicationService.GetUserByPassword(request));
        }
    }
}
