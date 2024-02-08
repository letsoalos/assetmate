using asset_mate_core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asset_mate_infrastructure.Data.Config
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(v => v.Id).IsRequired();
            builder.Property(v => v.VIN).IsRequired().HasMaxLength(50);
            builder.Property(v => v.EngineNumber).IsRequired().HasMaxLength(50);
            builder.Property(v => v.Make).IsRequired().HasMaxLength(50);
            builder.Property(v => v.Model).IsRequired().HasMaxLength(50);
            builder.Property(v => v.ManufacturerYear).IsRequired().HasMaxLength(4);
            builder.Property(v => v.RegistrationNumber).IsRequired().HasMaxLength(20);
            builder.Property(v => v.CurrentOdometer).IsRequired();
            builder.Property(v => v.LicensDiskExpiryDate).IsRequired().HasMaxLength(20);
            builder.HasOne(v => v.VehicleType).WithMany().HasForeignKey(v => v.VehicleTypeId);
            builder.HasOne(f => f.FleetType).WithMany().HasForeignKey(v => v.FleetTypeId);
            builder.HasOne(o => o.OwnershipCategory).WithMany().HasForeignKey(v => v.OwnershipCategoryId);
            builder.HasOne(v => v.VehicleStatus).WithMany().HasForeignKey(v => v.VehicleStatusId);
            builder.HasOne(b => b.Branch).WithMany().HasForeignKey(v => v.BranchId);
            builder.HasOne(p => p.Project).WithMany().HasForeignKey(v => v.ProjectId);
            builder.HasOne(a => a.AssignedDriver).WithMany().HasForeignKey(v => v.AssignedDriverId);
        }
    }
}