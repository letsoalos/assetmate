using asset_mate_core.Entities;

namespace asset_mate_core.Specifications
{
    public class VehicleWithFiltersForCountSpecification : BaseSpecification<Vehicle>
    {
        public VehicleWithFiltersForCountSpecification(VehicleSpecParams vehicleParams)
        : base(x =>
                (string.IsNullOrEmpty(vehicleParams.Search) || x.Make.ToLower().Contains(vehicleParams.Search)) &&
                (!vehicleParams.VehicleTypeId.HasValue || x.VehicleTypeId == vehicleParams.VehicleTypeId) &&
                (!vehicleParams.FleetTypeId.HasValue || x.FleetTypeId == vehicleParams.FleetTypeId)
            )
        {
        }
    }
}