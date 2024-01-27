using asset_mate_core.Entities;

namespace asset_mate_core.Interfaces
{
    /// <summary>
    /// Declare signature of methods
    /// </summary>
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleByIdAsync(int vehicleId);
        Task<IReadOnlyList<Vehicle>> GetVehiclesAsync();
        Task<Vehicle> AddVehicleAsync(Vehicle vehicle);
        Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle);
        Task<AssignedDriver> GetAssignedDriverByVehicleIdAsync(int VehicleId);
        Task<IReadOnlyList<VehicleType>> GetVehicleTypesAsync();
        Task<IReadOnlyList<FleetType>> GetFleetTypesAsync();
        Task<IReadOnlyList<Branch>> GetBranchesAsync();
        Task<IReadOnlyList<Project>> GetProjectsAsync();
        Task<IReadOnlyList<VehicleStatus>> GetVehicleStatusAsync();
        Task<IReadOnlyList<OwnershipCategory>> GetOwnershipCategoriesAsync();
    }
}