using CoreModelSeperation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreModelSeperation.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasIndex(x => x.Email)
                   .IsUnique();

            // Shadow property (Audit)
            builder.Property<string>("CreateBy");
            builder.Property<DateTime>("CreatedDate")
                   .HasDefaultValueSql("GETUTCDATE()");
            builder.Property<string>("ModifiedBy");
            builder.Property<DateTime?>("ModifiedDate");
        }
    }
}