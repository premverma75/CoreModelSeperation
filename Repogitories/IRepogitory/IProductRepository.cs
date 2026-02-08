using CoreModelSeperation.Data;
using CoreModelSeperation.Domain;

namespace CoreModelSeperation.Repogitories.IRepogitory
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
    }
}