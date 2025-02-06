using MediatR;
using MyCRUDApi.MyCRUDApi.Application.DTOs;
using MyCRUDApi.MyCRUDApi.Application.Interfaces;

namespace MyCRUDApi.MyCRUDApi.Application.Products.Queries
{
    public class GetProductByIDQuery : IRequest<ProductDTO>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdHandler : IRequestHandler<GetProductByIDQuery, ProductDTO>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductDTO> Handle(GetProductByIDQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductByIdAsync(request.Id);
            if (product == null) return null;

            return new ProductDTO
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId
            };
        }
    }
}
