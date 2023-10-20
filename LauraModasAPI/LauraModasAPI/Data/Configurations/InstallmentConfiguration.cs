using LauraModasAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LauraModasAPI.Data.Configurations
{
    public class InstallmentConfiguration : IEntityTypeConfiguration<InstallmentModel>
    {
        public void Configure(EntityTypeBuilder<InstallmentModel> builder)
        {
            builder.HasKey("CustomerId");

            builder.Property(p => p.NumberOfInstallments)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.InstallmentValue)
                .HasColumnType("double")
                .IsRequired();

            builder.Property(p => p.TotalValue)
                .HasColumnType("double")
                .IsRequired();

            builder.Property(p => p.RemainingValue)
                .HasColumnType("double");

            builder.Property(p => p.DateOfPayment)
                .HasColumnType("date")
                .IsRequired();
        }
    }
}
