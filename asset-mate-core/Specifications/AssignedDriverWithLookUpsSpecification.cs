using asset_mate_core.Entities;

namespace asset_mate_core.Specifications
{
    public class AssignedDriverWithLookUpsSpecification : BaseSpecification<AssignedDriver>
    {
        public AssignedDriverWithLookUpsSpecification()
        {
            AddInclude(x => x.Branch);
            AddInclude(x => x.Project);
            AddOrderBy(x => x.LastName);
        }

        public AssignedDriverWithLookUpsSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.Branch);
            AddInclude(x => x.Project);
        }
    }
}