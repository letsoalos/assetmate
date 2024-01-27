using System.Reflection;
using asset_mate_core.Entities;
using Microsoft.EntityFrameworkCore;

namespace asset_mate_infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<AssignedDriver> AssignedDrivers { get; set; }
        public DbSet<VehicleStatus> VehicleStatuses { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<OwnershipCategory> OwnershipCategories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<FleetType> FleetTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}