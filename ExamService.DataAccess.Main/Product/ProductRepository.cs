using ExamService.DataAccess.Main.UnitOfWork;
using ExamService.DataAccess.Seed;
using ExamService.Domain.Main.Product.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.DataAccess.Main.Product
{
    public class ProductRepository : Repository<Domain.Main.Product.Aggregates.Product>, IProductRepository
    {
        public ProductRepository(MainUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
