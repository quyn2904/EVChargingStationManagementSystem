 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVChargingStationManagementSystem.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string LicensePlate { get; set; }

        public string Model { get; set; }

        public int YearOfManufacture { get; set; }

        public int BatteryCapacity { get; set; }

        public int BatteryPercentage { get; set; }

        public int ChargingRate { get; set; }

        public DateTime LastChargedAt { get; set; }

        public Guid VehicleTypeId { get; set; }

        public Guid VehicleManufacturerId { get; set; }

        public Guid ChargingConnectorTypeId { get; set; }

        public Guid UserId { get; set; }

        public string Status { get; set; }

        public VehicleType VehicleType { get; set; }

        public VehicleManufacturer VehicleManufacturer { get; set; }

        public ChargingConnectorType ChargingConnectorType { get; set; }

        public ICollection<ChargingSession> ChargingSessions { get; set; }

        public User User { get; set; }
    }
}
