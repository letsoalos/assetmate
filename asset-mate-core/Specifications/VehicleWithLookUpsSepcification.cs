using asset_mate_core.Entities;

namespace asset_mate_core.Specifications
{
    public class VehicleWithLookUpsSepcification : BaseSpecification<Vehicle>
    {
        public VehicleWithLookUpsSepcification(VehicleSpecParams vehicleParams)
            : base(x =>
                (string.IsNullOrEmpty(vehicleParams.Search) || x.Make.ToLower().Contains(vehicleParams.Search)) &&
                (!vehicleParams.VehicleTypeId.HasValue || x.VehicleTypeId == vehicleParams.VehicleTypeId) &&
                (!vehicleParams.FleetTypeId.HasValue || x.FleetTypeId == vehicleParams.FleetTypeId)
            )
        {
            AddInclude(x => x.AssignedDriver);
            AddInclude(x => x.Branch);
            AddInclude(x => x.Project);
            AddInclude(x => x.FleetType);
            AddInclude(x => x.VehicleStatus);
            AddInclude(x => x.OwnershipCategory);
            AddInclude(x => x.VehicleType);
            AddOrderBy(x => x.Make);
            ApplyPaging(vehicleParams.PageSize * (vehicleParams.PageIndex - 1), vehicleParams.PageSize);

            if (!string.IsNullOrEmpty(vehicleParams.Sort))
            {
                switch (vehicleParams.Sort)
                {
                    case "modelAsc":
                        AddOrderBy(m => m.Model);
                        break;
                    case "modelDesc":
                        AddOrderByDescending(m => m.Model);
                        break;
                    default:
                        AddOrderBy(m => m.Make);
                        break;
                }
            }
        }

        public VehicleWithLookUpsSepcification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.AssignedDriver);
            AddInclude(x => x.Branch);
            AddInclude(x => x.Project);
            AddInclude(x => x.FleetType);
            AddInclude(x => x.VehicleStatus);
            AddInclude(x => x.OwnershipCategory);
            AddInclude(x => x.VehicleType);
        }

    }
}