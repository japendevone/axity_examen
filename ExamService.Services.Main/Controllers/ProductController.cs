using ExamService.Application.Main.Product.Services;
using ExamService.Services.Main.DataContract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ExamService.Services.Main.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private readonly IProductApplicationService _productApplicationService;

        public ProductController(IProductApplicationService productApplicationService)
        {
            _productApplicationService = productApplicationService ?? throw new ArgumentNullException(nameof(productApplicationService));
        }

        [HttpGet]
        [ResponseType(typeof(GetProductResponse))]
        public IHttpActionResult GetAll()
        {
            return Ok(_productApplicationService.GetAllProducts());
        }
    }
}
