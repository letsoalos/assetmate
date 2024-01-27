using asset_mate_core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asset_mate_infrastructure.Data.Config
{
    public class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
    {
        public void Configure(EntityTypeBuilder<VehicleType> builder)
        {
            builder.Property(v => v.Id).IsRequired();
            builder.Property(v => v.Name).IsRequired().HasMaxLength(50);
        }
    }
}