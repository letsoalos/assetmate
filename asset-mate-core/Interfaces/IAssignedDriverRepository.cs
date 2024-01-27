using asset_mate_core.Entities;

namespace asset_mate_core.Interfaces
{
    public interface IAssignedDriverRepository
    {
        Task<AssignedDriver> GetAssignedDriverByIdAsync(int assignedDriverId);
        Task<IReadOnlyList<AssignedDriver>> GetAssignedDriversAsync();
        Task<AssignedDriver> AddAssignedDriverAsync(AssignedDriver assignedDriver);
        Task<AssignedDriver> UpdateAssignedDriverAsync(AssignedDriver assignedDriver);
        Task<IReadOnlyList<Branch>> GetBranchesAsync();
        Task<IReadOnlyList<Project>> GetProjectsAsync();

    }
}