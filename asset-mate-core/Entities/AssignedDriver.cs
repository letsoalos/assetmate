namespace asset_mate_core.Entities
{
    public class AssignedDriver : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime LicenseExpiryDate { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string EmergencyContactName { get; set; }
        public string AdditionalNotes { get; set; }
        public bool IsActive { get; set; } // Indicates if the driver is currently active
        public int BranchId { get; set; }
        public int ProjectId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public int CreatedByUserId { get; set; }
    }
}