using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.Services.Main.DataContract.User
{
    public class GetUserByPasswordRequest
    {
        public string Nombre { get; set; }
        public string Password { get; set; }
    }
}
