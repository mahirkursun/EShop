using EShop.Catalog.Application.Features.Products.Queries;
using EShop.Catalog.Domain.Aggregates;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<IActionResult> GetProducts()
        {
            //var products = new List<Product>()
            //{
            //    new Product("Şemsiye", "Yağmura şemsiye", 100,1000,null),
            //    new Product("Bisiklet", "Çocuklar için bisiklet", 1000,10,null),
            //    new Product("Bilgisayar", "Güçlü bilgisayar", 2000,10,null),
            //    new Product("Telefon", "Güçlü telefon", 1000,100,null)

            //};
            var request = new GetAllProductsQueryRequest();
            var products = _mediator.Send(request);

            var result = Ok(products);
            return Task.FromResult<IActionResult>(result);
        }
    }
}
