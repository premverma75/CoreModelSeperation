using Microsoft.EntityFrameworkCore;
using CoreModelSeperation.Domain;

namespace CoreModelSeperation.Data
{
    public partial class AppDbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Product> Products => Set<Product>();
    }
}