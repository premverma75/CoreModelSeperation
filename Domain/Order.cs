namespace CoreModelSeperation.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}