using MediatR;
using MyCRUDApi.MyCRUDApi.Application.DTOs;
using MyCRUDApi.MyCRUDApi.Application.Interfaces;
using MyCRUDApi.MyCRUDApi.Domain.Entities;

namespace MyCRUDApi.MyCRUDApi.Application.Products.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductDTO>>  // ✅ Add IRequest<IEnumerable<Product>>
    {
    }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProductsAsync();

            // ✅ Convert Entity to DTO
            return products.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock
            }).ToList();
        }
    }
}
