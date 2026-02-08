using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreModelSeperation.Domain;

namespace CoreModelSeperation.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Price)
                   .HasPrecision(18, 2)
                   .IsRequired();

            // Shadow property
            builder.Property<bool>("IsDeleted")
                   .HasDefaultValue(false);
            builder.Property<string>("CreateBy");
            builder.Property<DateTime>("CreatedDate")
                   .HasDefaultValueSql("GETUTCDATE()");
            builder.Property<string>("ModifiedBy");
            builder.Property<DateTime?>("ModifiedDate");
        }
    }
}