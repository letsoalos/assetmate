using asset_mate_api.Dtos;
using asset_mate_core.Entities;
using asset_mate_core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace asset_mate_api.Controllers
{
    public class BranchController : BaseApiController
    {
        private readonly IGenericRepository<Branch> _branchRepo;
        private readonly IMapper _mapper;
        public BranchController(IGenericRepository<Branch> branchRepo, IMapper mapper)
        {
            _branchRepo = branchRepo;
            _mapper = mapper;
        }

        [HttpGet("get-branches")]
        public async Task<ActionResult<IReadOnlyList<BranchToReturnDto>>> GetBranches()
        {
            var branches = await _branchRepo.ListAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<Branch>, IReadOnlyList<BranchToReturnDto>>(branches));
        }

        [HttpGet("get-branch/{branchId}")]
        public async Task<ActionResult<BranchToReturnDto>> GetBranch(int branchId)
        {
            var branch = await _branchRepo.GetByIdAsync(branchId);

            return Ok(_mapper.Map<Branch, BranchToReturnDto>(branch));
        }
    }
}