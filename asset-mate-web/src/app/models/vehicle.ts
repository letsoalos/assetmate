export interface Vehicle {
  id: number
  vin: string
  engineNumber: string
  make: string
  model: string
  manufacturerYear: number
  registrationNumber: string
  currentOdometer: number
  licensDiskExpiryDate: string
  pictureUrl: string
  dateCreated: string
  createdByUserId: number
  dateModified: string
  modifiedByUserId: number
  vehicleType: string
  fleetType: string
  ownershipCategory: string
  vehicleStatus: string
  branch: string
  assignedDriver: string
  project: string
}