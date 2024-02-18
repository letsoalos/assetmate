using asset_mate_api.Dtos;
using asset_mate_api.Errors;
using asset_mate_core.Entities;
using asset_mate_core.Interfaces;
using asset_mate_core.Specifications;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace asset_mate_api.Controllers
{
    public class AssignedDriverController : BaseApiController
    {
        private readonly IGenericRepository<AssignedDriver> _assignedDriverRepo;
        private readonly IMapper _mapper;
        public AssignedDriverController(IGenericRepository<AssignedDriver> assignedDriverRepo, IMapper mapper)
        {
            _assignedDriverRepo = assignedDriverRepo;
            _mapper = mapper;
        }

        [HttpGet("get-drivers")]
        public async Task<ActionResult<IReadOnlyList<AssignedDriverToReturnDto>>> GetDrivers()
        {
            var spec = new AssignedDriverWithLookUpsSpecification();
            var drivers = await _assignedDriverRepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<AssignedDriver>, IReadOnlyList<AssignedDriverToReturnDto>>(drivers));
        }

        [HttpGet("get-driver/{driverId}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AssignedDriverToReturnDto>> GetDriver(int driverId)
        {
            var spec = new AssignedDriverWithLookUpsSpecification(driverId);
            var driver = await _assignedDriverRepo.GetEntityWithSpec(spec);

            if (driver == null) return NotFound(new ApiResponse(404));


            return Ok(_mapper.Map<AssignedDriver, AssignedDriverToReturnDto>(driver));
        }

    }
}