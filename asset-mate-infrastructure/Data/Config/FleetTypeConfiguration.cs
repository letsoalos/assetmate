using asset_mate_core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asset_mate_infrastructure.Data.Config
{
    public class FleetTypeConfiguration : IEntityTypeConfiguration<FleetType>
    {
        public void Configure(EntityTypeBuilder<FleetType> builder)
        {
            builder.Property(f => f.Id).IsRequired();
            builder.Property(f => f.Name).IsRequired().HasMaxLength(50);
            builder.Property(f => f.FleetTypeCode).IsRequired().HasMaxLength(10);
        }
    }
}