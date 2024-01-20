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
    }
}