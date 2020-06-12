using ExamService.Application.Seed;
using ExamService.Domain.Main.Product.Aggregates;
using ExamService.Services.Main.DataContract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.Application.Main.Product.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IProductRepository _productRepository;

        public ProductApplicationService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
        }

        public List<GetProductResponse> GetAllProducts()
        {
            var result = _productRepository.GetAll().ToList();

            return result.ProjectedAs<GetProductResponse>();
        }
    }
}
