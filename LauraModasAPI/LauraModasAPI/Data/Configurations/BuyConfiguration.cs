using LauraModasAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LauraModasAPI.Data.Configurations
{
    public class BuyConfiguration : IEntityTypeConfiguration<BuyModel>
    {
        public void Configure(EntityTypeBuilder<BuyModel> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(p => p.Value)
                .HasColumnType("double")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnType("varchar(350)");

            builder.Property(p => p.Status)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.CustomerId)
                .HasColumnType("int")
                .IsRequired();

        }
    }
}
