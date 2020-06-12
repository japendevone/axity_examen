using ExamService.Services.Main.DataContract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.Application.Main.Mapping
{
    public class ProductProfile : AutoMapper.Profile
    {
        public ProductProfile()
        {
            CreateMap<Domain.Main.Product.Aggregates.Product, GetProductResponse>();
        }
    }
}
