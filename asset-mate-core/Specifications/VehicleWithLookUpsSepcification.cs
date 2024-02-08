using asset_mate_core.Entities;

namespace asset_mate_core.Specifications
{
    public class VehicleWithLookUpsSepcification : BaseSpecification<Vehicle>
    {
        public VehicleWithLookUpsSepcification()
        {
            AddInclude(x => x.AssignedDriver);
            AddInclude(x => x.Branch);
            AddInclude(x => x.Project);
            AddInclude(x => x.FleetType);
            AddInclude(x => x.VehicleStatus);
            AddInclude(x => x.OwnershipCategory);
            AddInclude(x => x.VehicleType);
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