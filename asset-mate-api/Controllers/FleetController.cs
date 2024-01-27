using asset_mate_core.Entities;
using asset_mate_core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asset_mate_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FleetController : ControllerBase
    {
        private readonly IVehicleRepository _repo;
        public FleetController(IVehicleRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("get-vehicles")]
        public async Task<ActionResult<IReadOnlyList<Vehicle>>> GetVehicles()
        {
            var vehicles = await _repo.GetVehiclesAsync();

            return Ok(vehicles);
        }

        [HttpGet("get-vehicle/{VehicleId}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int VehicleId)
        {
            var vehicle = await _repo.GetVehicleByIdAsync(VehicleId);

            return Ok(vehicle);
        }

        [HttpGet("get-assigned-driver-by-vehicle")]
        public async Task<ActionResult<AssignedDriver>> GetAssignedDriverByVehicle(int VehicleId)
        {
            return Ok(await _repo.GetAssignedDriverByVehicleIdAsync(VehicleId));
        }

        [HttpGet("get-vehicle-types")]
        public async Task<ActionResult<VehicleType>> GetVehicleTypes()
        {
            return Ok(await _repo.GetVehicleTypesAsync());
        }

        [HttpGet("get-fleet-types")]
        public async Task<ActionResult<FleetType>> GetFleetTypes()
        {
            return Ok(await _repo.GetFleetTypesAsync());
        }

        [HttpGet("get-branches")]
        public async Task<ActionResult<Branch>> GetBranches()
        {
            return Ok(await _repo.GetBranchesAsync());
        }

    }
}