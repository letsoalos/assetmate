using asset_mate_core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asset_mate_infrastructure.Data.Config
{
    public class AssignedDriverConfiguration : IEntityTypeConfiguration<AssignedDriver>
    {
        public void Configure(EntityTypeBuilder<AssignedDriver> builder)
        {
            builder.Property(d => d.Id).IsRequired();
            builder.Property(d => d.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(d => d.LastName).IsRequired().HasMaxLength(50);
            builder.Property(d => d.LicenseNumber).IsRequired().HasMaxLength(20);
            builder.Property(d => d.ContactNumber).IsRequired().HasMaxLength(10);
            builder.Property(d => d.Address).IsRequired().HasMaxLength(100);
            builder.Property(d => d.EmergencyContactNumber).IsRequired().HasMaxLength(10);
            builder.Property(d => d.EmergencyContactName).IsRequired().HasMaxLength(50);
            builder.HasOne<Branch>().WithMany().HasForeignKey(d => d.BranchId);             //Has one Branch with many drivers
            builder.HasOne<Project>().WithMany().HasForeignKey(d => d.ProjectId);           //A Project can be associated with many drivers
        }
    }
}