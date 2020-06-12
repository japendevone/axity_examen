using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.Services.Main.DataContract.Product
{
    public class GetProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float? Cost { get; set; }
        public int? Inverntory { get; set; }
    }
}
