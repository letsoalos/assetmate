using asset_mate_api.Dtos;
using asset_mate_core.Entities;
using asset_mate_core.Interfaces;
using asset_mate_core.Specifications;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace asset_mate_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FleetController : ControllerBase
    {
        private readonly IGenericRepository<Vehicle> _vehiclesRepo;
        private readonly IGenericRepository<VehicleType> _vehicleTypeRepo;
        private readonly IGenericRepository<FleetType> _fleetTypeRepo;
        private readonly IGenericRepository<Branch> _brancheRepo;
        private readonly IGenericRepository<AssignedDriver> _assignedDriverRepo;
        private readonly IGenericRepository<OwnershipCategory> _ownershipCategoryRepo;
        private readonly IGenericRepository<VehicleStatus> _vehicleStatusRepo;
        private readonly IGenericRepository<Project> _projectRepo;
        private readonly IMapper _mapper;



        public FleetController(IGenericRepository<Vehicle> vehiclesRepo, IGenericRepository<VehicleType> vehicleTypeRepo,
        IGenericRepository<VehicleStatus> vehicleStatusRepo, IGenericRepository<FleetType> fleetTypeRepo, IGenericRepository<Branch> brancheRepo,
        IGenericRepository<AssignedDriver> assignedDriverRepo, IGenericRepository<OwnershipCategory> ownershipCategoryRepo,
        IGenericRepository<Project> projectRepo, IMapper mapper)
        {
            _vehiclesRepo = vehiclesRepo;
            _vehicleTypeRepo = vehicleTypeRepo;
            _vehicleStatusRepo = vehicleStatusRepo;
            _fleetTypeRepo = fleetTypeRepo;
            _brancheRepo = brancheRepo;
            _assignedDriverRepo = assignedDriverRepo;
            _ownershipCategoryRepo = ownershipCategoryRepo;
            _projectRepo = projectRepo;
            _mapper = mapper;
        }

        [HttpGet("get-vehicles")]
        public async Task<ActionResult<IReadOnlyList<VehicleToReturnDto>>> GetVehicles()
        {
            var spec = new VehicleWithLookUpsSepcification();

            var vehicles = await _vehiclesRepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Vehicle>, IReadOnlyList<VehicleToReturnDto>>(vehicles));
        }

        [HttpGet("get-vehicle/{VehicleId}")]
        public async Task<ActionResult<VehicleToReturnDto>> GetVehicle(int VehicleId)
        {
            var spec = new VehicleWithLookUpsSepcification(VehicleId);

            var vehicle = await _vehiclesRepo.GetEntityWithSpec(spec);

            return _mapper.Map<Vehicle, VehicleToReturnDto>(vehicle);
        }

        [HttpGet("get-assigned-driver-by-vehicle/{AssignedDriverId}")]
        public async Task<ActionResult<AssignedDriverToReturnDto>> GetAssignedDriverByVehicle(int AssignedDriverId)
        {
            var spec = new AssignedDriverWithLookUpsSpecification(AssignedDriverId);

            var assignedDriver = await _assignedDriverRepo.GetEntityWithSpec(spec);

            return _mapper.Map<AssignedDriver, AssignedDriverToReturnDto>(assignedDriver);
        }

        [HttpGet("get-branch-by-vehicle/{BranchId}")]
        public async Task<ActionResult<BranchToReturnDto>> GetBranchesAsync(int BranchId)
        {
            var branch = await _brancheRepo.GetByIdAsync(BranchId);

            return _mapper.Map<Branch, BranchToReturnDto>(branch);
        }

        //[HttpGet("get-vehicle-types")]
        //public async Task<ActionResult<VehicleType>> GetVehicleTypes()
        //{
        //return Ok(await _vehicleTypeRepo.ListAllAsync());
        //}

        //[HttpGet("get-fleet-types")]
        //public async Task<ActionResult<FleetType>> GetFleetTypes()
        //{
        //return Ok(await _fleetTypeRepo.ListAllAsync());
        //}

    }
}