using asset_mate_api.Dtos;
using asset_mate_api.Errors;
using asset_mate_api.Helpers;
using asset_mate_core.Entities;
using asset_mate_core.Interfaces;
using asset_mate_core.Specifications;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace asset_mate_api.Controllers
{
    public class FleetController : BaseApiController
    {
        private readonly IGenericRepository<Vehicle> _vehiclesRepo;
        private readonly IGenericRepository<Branch> _brancheRepo;
        private readonly IGenericRepository<AssignedDriver> _assignedDriverRepo;
        private readonly IMapper _mapper;



        public FleetController(IGenericRepository<Vehicle> vehiclesRepo, IGenericRepository<Branch> brancheRepo,
        IGenericRepository<AssignedDriver> assignedDriverRepo, IMapper mapper)
        {
            _vehiclesRepo = vehiclesRepo;
            _brancheRepo = brancheRepo;
            _assignedDriverRepo = assignedDriverRepo;
            _mapper = mapper;
        }

        [HttpGet("get-vehicles")]
        public async Task<ActionResult<Pagination<VehicleToReturnDto>>> GetVehicles([FromQuery] VehicleSpecParams vehicleParams)
        {
            var spec = new VehicleWithLookUpsSepcification(vehicleParams);
            var countSpec = new VehicleWithFiltersForCountSpecification(vehicleParams);

            var totalItems = await _vehiclesRepo.CountAsync(countSpec);

            var vehicles = await _vehiclesRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Vehicle>, IReadOnlyList<VehicleToReturnDto>>(vehicles);

            return Ok(new Pagination<VehicleToReturnDto>(vehicleParams.PageIndex, vehicleParams.PageSize, totalItems, data));
        }

        [HttpGet("get-vehicle/{VehicleId}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VehicleToReturnDto>> GetVehicle(int VehicleId)
        {
            var spec = new VehicleWithLookUpsSepcification(VehicleId);
            var vehicle = await _vehiclesRepo.GetEntityWithSpec(spec);

            if (vehicle == null) return NotFound(new ApiResponse(404));

            return Ok(_mapper.Map<Vehicle, VehicleToReturnDto>(vehicle));
        }

        [HttpGet("get-assigned-driver-by-vehicle/{AssignedDriverId}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AssignedDriverToReturnDto>> GetAssignedDriverByVehicle(int AssignedDriverId)
        {
            var spec = new AssignedDriverWithLookUpsSpecification(AssignedDriverId);
            var assignedDriver = await _assignedDriverRepo.GetEntityWithSpec(spec);

            if (assignedDriver == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<AssignedDriver, AssignedDriverToReturnDto>(assignedDriver);
        }

        [HttpGet("get-branch-by-vehicle/{BranchId}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BranchToReturnDto>> GetBranchesAsync(int BranchId)
        {
            var branch = await _brancheRepo.GetByIdAsync(BranchId);

            if (branch == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Branch, BranchToReturnDto>(branch);
        }
    }
}