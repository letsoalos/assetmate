namespace asset_mate_core.Entities
{
    public class Vehicle : BaseEntity
    {
        public string VIN { get; set; }
        public string EngineNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ManufacturerYear { get; set; }
        public string RegistrationNumber { get; set; }
        public int CurrentOdometer { get; set; }
        public DateTime? LicensDiskExpiryDate { get; set; }
        public string PictureUrl { get; set; }
        public int VehicleTypeId { get; set; }
        public int FleetTypeId { get; set; }
        public int OwnershipCategoryId { get; set; }    //Vehicle has an OwnershipCategory. OwnershipCategory can be associated with multiple Vehicles.
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public int VehicleStatusId { get; set; }   //Vehicle has a particular St+atus. Status can be associated with multiple Vehicles.
        public int BranchId { get; set; }   //Vehicle belongs to one Branch. Branch can have multiple Vehicles.
        public int ProjectId { get; set; }
        public int AssignedDriverId { get; set; }   //Vehicle can be associated with one Driver. Driver can be associated with multiple Vehicles.
        public int CreatedByUserId { get; set; }
        public DateTime DateModified { get; set; }
        public int ModifiedByUserId { get; set; }


        public virtual VehicleType VehicleType { get; set; }
        public virtual FleetType FleetType { get; set; }
        public virtual OwnershipCategory OwnershipCategory { get; set; }
        public virtual VehicleStatus VehicleStatus { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual AssignedDriver AssignedDriver { get; set; }
        public virtual Project Project { get; set; }

    }
}