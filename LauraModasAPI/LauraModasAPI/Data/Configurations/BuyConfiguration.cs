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

            builder.HasOne(p => p.CustomerModel).WithMany(p => p.BuysModel);

            builder.Property(p => p.Name)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(p => p.Value)
                .HasColumnType("double")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnType("varchar(350)");

            builder.Property(p => p.CustomerModelId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Date)
                .HasColumnType("Date");

            builder.Property(p => p.NumberOfInstallments)
                .HasColumnType("int");

            builder.Property(p => p.InstallmentValue)
                .HasColumnType("double");

            builder.Property(p => p.DateOfPayment)
                .HasColumnType("Date")
                .IsRequired();

        }
    }
}
