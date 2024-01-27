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
            builder.HasOne<VehicleType>().WithMany().HasForeignKey(v => v.VehicleTypeId);
            builder.HasOne<FleetType>().WithMany().HasForeignKey(v => v.FleetTypeId);
            builder.HasOne<OwnershipCategory>().WithMany().HasForeignKey(v => v.OwnershipCategoryId);
            builder.HasOne<VehicleStatus>().WithMany().HasForeignKey(v => v.VehicleStatusId);
            builder.HasOne<Branch>().WithMany().HasForeignKey(v => v.BranchId);
            builder.HasOne<Project>().WithMany().HasForeignKey(v => v.ProjectId);
            builder.HasOne<AssignedDriver>().WithMany().HasForeignKey(v => v.AssignedDriverId);
        }
    }
}