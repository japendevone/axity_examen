using ExamService.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.Domain.Main.Product.Aggregates
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
