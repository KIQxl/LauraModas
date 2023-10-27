using LauraModasAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LauraModasAPI.Data.Configurations
{
    public class LotConfiguration : IEntityTypeConfiguration<LotModel>
    {
        public void Configure(EntityTypeBuilder<LotModel> builder)
        {
            
            builder.HasKey(x => x.Id);
            
            builder.Property(p => p.Category)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.Quantity)
                .HasColumnType("int");

            builder.Property(p => p.Value)
                .HasColumnType("double");

            builder.Property(p => p.AmountValue)
                .HasColumnType("double");

            builder.Property(p => p.Date)
                .HasColumnType("date")
                .IsRequired();
        }
    }
}
