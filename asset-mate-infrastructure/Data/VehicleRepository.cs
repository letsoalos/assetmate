using asset_mate_core.Entities;
using asset_mate_core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace asset_mate_infrastructure.Data
{
    /// <summary>
    /// Add Concreate and/or implementation class
    /// </summary>
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DataContext _context;
        public VehicleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int vehicleId)
        {
            return await _context.Vehicles
                .Include(v => v.VehicleType)                //using eager loading
                .Include(v => v.FleetType)
                .Include(v => v.OwnershipCategory)
                .Include(v => v.VehicleStatus)
                .Include(v => v.Branch)
                .Include(v => v.AssignedDriver)
                .Include(v => v.Project)
                .FirstOrDefaultAsync(v => v.Id == vehicleId);
        }

        public async Task<IReadOnlyList<Vehicle>> GetVehiclesAsync()
        {
            return await _context.Vehicles
                .Include(v => v.VehicleType)                //using eager loading
                .Include(v => v.FleetType)
                .Include(v => v.OwnershipCategory)
                .Include(v => v.VehicleStatus)
                .Include(v => v.Branch)
                .Include(v => v.AssignedDriver)
                .Include(v => v.Project)
                .ToListAsync();
        }

        public Task<Vehicle> AddVehicleAsync(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public async Task<AssignedDriver> GetAssignedDriverByVehicleIdAsync(int vehicleId)
        {
            var assignedDriver = await _context.AssignedDrivers.FirstOrDefaultAsync(v => v.Id == vehicleId);

            if (assignedDriver == null) return null;

            return assignedDriver;
        }

        public async Task<IReadOnlyList<VehicleType>> GetVehicleTypesAsync()
        {
            return await _context.VehicleTypes.ToListAsync();
        }

        public async Task<IReadOnlyList<FleetType>> GetFleetTypesAsync()
        {
            return await _context.FleetTypes.ToListAsync();
        }

        public async Task<IReadOnlyList<Branch>> GetBranchesAsync()
        {
            return await _context.Branches.ToListAsync();
        }

        public async Task<IReadOnlyList<Project>> GetProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<IReadOnlyList<VehicleStatus>> GetVehicleStatusAsync()
        {
            return await _context.VehicleStatuses.ToListAsync();
        }

        public async Task<IReadOnlyList<OwnershipCategory>> GetOwnershipCategoriesAsync()
        {
            return await _context.OwnershipCategories.ToListAsync();
        }
    }
}