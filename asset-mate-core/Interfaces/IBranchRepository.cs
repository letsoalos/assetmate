using asset_mate_core.Entities;

namespace asset_mate_core.Interfaces
{
    public interface IBranchRepository
    {
        Task<Branch> GetBranchByIdAsync(int branchId);
        Task<IReadOnlyList<Branch>> GetBranchesAsync();
        Task<Branch> AddBranchAsync(Branch branch);
        Task<Branch> UpdateBranchAsync(Branch branch);
    }
}