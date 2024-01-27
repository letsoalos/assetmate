using asset_mate_core.Entities;
using asset_mate_core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace asset_mate_infrastructure.Data
{
    public class AssignedDriverRepository : IAssignedDriverRepository
    {
        private readonly DataContext _context;
        public AssignedDriverRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<AssignedDriver>> GetAssignedDriversAsync()
        {
            return await _context.AssignedDrivers.ToListAsync();
        }

        public async Task<AssignedDriver> GetAssignedDriverByIdAsync(int assignedDriverId)
        {
            return await _context.AssignedDrivers.FirstOrDefaultAsync(v => v.Id == assignedDriverId);
        }

        public async Task<IReadOnlyList<Branch>> GetBranchesAsync()
        {
            return await _context.Branches.ToListAsync();
        }

        public async Task<IReadOnlyList<Project>> GetProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public Task<AssignedDriver> AddAssignedDriverAsync(AssignedDriver assignedDriver)
        {
            throw new NotImplementedException();
        }

        public Task<AssignedDriver> UpdateAssignedDriverAsync(AssignedDriver assignedDriver)
        {
            throw new NotImplementedException();
        }
    }
}