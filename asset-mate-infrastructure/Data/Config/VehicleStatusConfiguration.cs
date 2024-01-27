using asset_mate_core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asset_mate_infrastructure.Data.Config
{
    public class VehicleStatusConfiguration : IEntityTypeConfiguration<VehicleStatus>
    {
        public void Configure(EntityTypeBuilder<VehicleStatus> builder)
        {
            builder.Property(v => v.Id).IsRequired();
            builder.Property(v => v.Name).IsRequired().HasMaxLength(50);
            builder.Property(v => v.VehicleStatusCode).IsRequired().HasMaxLength(50);
        }
    }
}