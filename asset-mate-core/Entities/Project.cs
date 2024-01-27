namespace asset_mate_core.Entities
{
    public class Project : BaseEntity
    {
        public string ProjectName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProjectManager
        {
            get { return $"{FirstName} {LastName}"; }
        }

    }
}