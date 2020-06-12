using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.Services.Main.DataContract.User
{
    public class GetUserResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public int? UsuarioBloqueado { get; set; }
        public int? UserLoginTries { get; set; }
    }
}
