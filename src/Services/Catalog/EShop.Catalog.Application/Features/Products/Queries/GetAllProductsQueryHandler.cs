using EShop.Catalog.Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Catalog.Application.Features.Products.Queries
{
    //Uçak pisti gibi düşün
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IEnumerable<GetProductResponse>>
    {

        public Task<IEnumerable<GetProductResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = new List<Product>()
            {
                new Product("Şemsiye", "Yağmura şemsiye", 100,1000,null),
                new Product("Bisiklet", "Çocuklar için bisiklet", 1000,10,null),
                new Product("Bilgisayar", "Güçlü bilgisayar", 2000,10,null),
                new Product("Telefon", "Güçlü telefon", 1000,100,null)

            };

            var response = products.Select(p => new GetProductResponse(p.Id, p.Name, p.Description, p.Price, p.CategoryId, p.ImageUrl));

            return Task.FromResult(response);
        }
    }
}
