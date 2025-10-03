using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVChargingStationManagementSystem.Domain.Entities
{
    public class ChargingSession: BaseEntity
    {
        public Guid VehicleId { get; set; }

        public Guid ChargingPointId { get; set; }

        public DateTime StartingTimestamp { get; set; }

        public DateTime EndingTimestamp { get; set; }

        public int EnergyConsumed { get; set; }

        public int ChargingCost { get; set; }

        public ChargingSessionStatus Status { get; set; }

        public ChargingPoint ChargingPoint { get; set; }

        public Vehicle Vehicle { get; set; }
    }

    public enum ChargingSessionStatus
    {
        Booked = 0,
        Charging = 1,
        Charged = 2,
        Canceled = 3,
    }
}
