using LauraModasAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LauraModasAPI.Data.Configurations
{
    public class BuylogConfiguration : IEntityTypeConfiguration<BuyLogModel>
    {
        public void Configure(EntityTypeBuilder<BuyLogModel> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CustomerName)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.CustomerId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.PaymentValue)
                .HasColumnType("double")
                .IsRequired();

            builder.Property(p => p.DateOfPayment)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.NameOfProduct)
                .HasColumnType("varchar(200)")
                .IsRequired();
        }
    }
}
