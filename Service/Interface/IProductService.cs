namespace CoreModelSeperation.Service.Interface
{
    public interface IProductService
    {
        Task<List<Domain.Product>> GetProducts();
    }
}