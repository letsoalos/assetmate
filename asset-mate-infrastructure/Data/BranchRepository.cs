using asset_mate_core.Entities;
using asset_mate_core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace asset_mate_infrastructure.Data
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DataContext _contenxt;
        public BranchRepository(DataContext context)
        {
            _contenxt = context;
        }


        public async Task<IReadOnlyList<Branch>> GetBranchesAsync()
        {
            return await _contenxt.Branches.ToListAsync();
        }

        public async Task<Branch> GetBranchByIdAsync(int branchId)
        {
            return await _contenxt.Branches.FirstOrDefaultAsync(b => b.Id == branchId);
        }

        public Task<Branch> AddBranchAsync(Branch branch)
        {
            throw new NotImplementedException();
        }

        public Task<Branch> UpdateBranchAsync(Branch branch)
        {
            throw new NotImplementedException();
        }
    }
}