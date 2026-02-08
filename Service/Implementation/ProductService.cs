using CoreModelSeperation.Repogitories.IRepogitory;
using CoreModelSeperation.Service.Interface;

namespace CoreModelSeperation.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<List<Domain.Product>> GetProducts()
        {
            return _productRepository.GetProducts();
        }
    }
}