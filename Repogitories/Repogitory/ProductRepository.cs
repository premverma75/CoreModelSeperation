using CoreModelSeperation.Data;
using CoreModelSeperation.Domain;
using CoreModelSeperation.Repogitories.IRepogitory;
using Microsoft.EntityFrameworkCore;

namespace CoreModelSeperation.Repogitories.Repogitory
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await appDbContext.Products.AsNoTracking().AsQueryable().ToListAsync();
        }
    }
}