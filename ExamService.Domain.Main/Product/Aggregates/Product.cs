using ExamService.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.Domain.Main.Product.Aggregates
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public float? Cost { get; set; }
        public int? Inverntory { get; set; }
    }
}
