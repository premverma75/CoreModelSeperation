namespace CoreModelSeperation.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int MobileNumber { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}