using ExamService.Services.Main.DataContract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.Application.Main.Product.Services
{
    public interface IProductApplicationService : IDisposable
    {
        List<GetProductResponse> GetAllProducts();
    }
}
