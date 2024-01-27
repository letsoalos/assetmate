namespace asset_mate_core.Entities
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string AddressCode { get; set; }
        public string ContactNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ContactPerson
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }
}