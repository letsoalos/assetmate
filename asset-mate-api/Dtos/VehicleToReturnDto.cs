namespace asset_mate_api.Dtos
{
    public class VehicleToReturnDto
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        public string EngineNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ManufacturerYear { get; set; }
        public string RegistrationNumber { get; set; }
        public int CurrentOdometer { get; set; }
        public DateTime? LicensDiskExpiryDate { get; set; }
        public string PictureUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime DateModified { get; set; }
        public int ModifiedByUserId { get; set; }
        public string VehicleType { get; set; }
        public string FleetType { get; set; }
        public string OwnershipCategory { get; set; }
        public string VehicleStatus { get; set; }
        public string Branch { get; set; }
        public string AssignedDriver { get; set; }
        public string Project { get; set; }

    }
}