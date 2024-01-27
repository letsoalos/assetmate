using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using asset_mate_core.Entities;

namespace asset_mate_infrastructure.Data
{
    public class DataContextSeed
    {
        public static async Task SeedAsync(DataContext context)
        {
            if (!context.Branches.Any())
            {
                var branchesData = File.ReadAllText("../asset-mate-infrastructure/Data/SeedData/branches.json");
                var branches = DeserializeJson<List<Branch>>(branchesData);
                context.Branches.AddRange(branches);
            }

            if (!context.FleetTypes.Any())
            {
                var fleetTypesData = File.ReadAllText("../asset-mate-infrastructure/Data/SeedData/fleetTypes.json");
                var fleetTypes = DeserializeJson<List<FleetType>>(fleetTypesData);
                context.FleetTypes.AddRange(fleetTypes);
            }

            if (!context.OwnershipCategories.Any())
            {
                var ownershipCategoriesData = File.ReadAllText("../asset-mate-infrastructure/Data/SeedData/ownershipCategories.json");
                var ownershipCategories = DeserializeJson<List<OwnershipCategory>>(ownershipCategoriesData);
                context.OwnershipCategories.AddRange(ownershipCategories);
            }

            if (!context.Projects.Any())
            {
                var projectsData = File.ReadAllText("../asset-mate-infrastructure/Data/SeedData/projects.json");
                var projects = DeserializeJson<List<Project>>(projectsData);
                context.Projects.AddRange(projects);
            }

            if (!context.VehicleStatuses.Any())
            {
                var vehicleStatusesData = File.ReadAllText("../asset-mate-infrastructure/Data/SeedData/vehicleStatuses.json");
                var vehicleStatuses = DeserializeJson<List<VehicleStatus>>(vehicleStatusesData);
                context.VehicleStatuses.AddRange(vehicleStatuses);
            }

            if (!context.VehicleTypes.Any())
            {
                var vehicleTypesData = File.ReadAllText("../asset-mate-infrastructure/Data/SeedData/vehicleTypes.json");
                var vehicleTypes = DeserializeJson<List<VehicleType>>(vehicleTypesData);
                context.VehicleTypes.AddRange(vehicleTypes);
            }

            if (!context.AssignedDrivers.Any())
            {
                var assignedDriversData = File.ReadAllText("../asset-mate-infrastructure/Data/SeedData/assignedDrivers.json");
                var assignedDrivers = DeserializeJson<List<AssignedDriver>>(assignedDriversData);
                context.AssignedDrivers.AddRange(assignedDrivers);
            }

            if (!context.Vehicles.Any())
            {
                var vehiclesData = File.ReadAllText("../asset-mate-infrastructure/Data/SeedData/vehicles.json");
                var vehicles = DeserializeJson<List<Vehicle>>(vehiclesData);
                context.Vehicles.AddRange(vehicles);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }

        private static T DeserializeJson<T>(string jsonData)
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new DateTimeConverter() }, // Add the DateTimeConverter
                PropertyNameCaseInsensitive = true, // Adjust this based on your needs
                // Additional options if necessary...
            };

            return JsonSerializer.Deserialize<T>(jsonData, options);
        }

        public class DateTimeConverter : JsonConverter<DateTime>
        {
            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                string dateStr = reader.GetString();
                if (DateTime.TryParseExact(dateStr, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out DateTime result))
                {
                    return result;
                }

                // Handle parsing failure
                throw new JsonException($"Unable to parse date string: {dateStr}");
            }

            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
            }
        }
    }
}