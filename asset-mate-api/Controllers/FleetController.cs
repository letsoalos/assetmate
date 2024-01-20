using asset_mate_core.Entities;
using asset_mate_infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asset_mate_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FleetController : ControllerBase
    {
        private readonly DataContext _context;
        public FleetController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("get-vehicles")]
        public async Task<ActionResult<List<Vehicle>>> GetVehicles()
        {
            var vehicles = await _context.Vehicles.ToListAsync();

            return vehicles;
        }

        [HttpGet("get-vehicle/{VehicleId}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int VehicleId)
        {
            var vehicle = await _context.Vehicles.FindAsync(VehicleId);

            return Ok(vehicle);
        }

    }
}