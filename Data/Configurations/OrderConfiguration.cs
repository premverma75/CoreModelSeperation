using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreModelSeperation.Domain;

namespace CoreModelSeperation.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TotalAmount)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.UserId);

            // Shadow property
            builder.Property<string>("CreateBy");
            builder.Property<DateTime>("CreatedDate")
                   .HasDefaultValueSql("GETUTCDATE()");
            builder.Property<string>("ModifiedBy");
            builder.Property<DateTime?>("ModifiedDate");
        }
    }
}