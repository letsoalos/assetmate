using asset_mate_core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asset_mate_infrastructure.Data.Config
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.Property(b => b.Id).IsRequired();
            builder.Property(b => b.Name).IsRequired().HasMaxLength(50);
            builder.Property(b => b.StreetAddress).IsRequired().HasMaxLength(100);
            builder.Property(b => b.City).IsRequired().HasMaxLength(50);
            builder.Property(b => b.AddressCode).IsRequired().HasMaxLength(10);
            builder.Property(b => b.ContactNumber).IsRequired().HasMaxLength(10);
            builder.Property(b => b.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(b => b.LastName).IsRequired().HasMaxLength(50);
        }
    }
}