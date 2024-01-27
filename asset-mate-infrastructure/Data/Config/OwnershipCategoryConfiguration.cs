using asset_mate_core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asset_mate_infrastructure.Data.Config
{
    public class OwnershipCategoryConfiguration : IEntityTypeConfiguration<OwnershipCategory>
    {
        public void Configure(EntityTypeBuilder<OwnershipCategory> builder)
        {
            builder.Property(o => o.Id).IsRequired();
            builder.Property(o => o.Name).IsRequired().HasMaxLength(50);
        }
    }
}