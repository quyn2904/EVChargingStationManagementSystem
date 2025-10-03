using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVChargingStationManagementSystem.Domain.Entities
{
    public class ChargingPoint : BaseEntity
    {
        public int PortNumber { get; set; }

        public int PowerOutput { get; set; }

        public string PricingType { get; set; }

        public int PricingRate { get; set; }

        public Boolean IsActive { get; set; }

        public Guid ChargingConnectorTypeId { get; set; }

        public Guid ChargingStationId { get; set; }

        public ChargingConnectorType ChargingConnectorType { get; set; }

        public ChargingStation ChargingStation { get; set; }

        public ICollection<ChargingSession> ChargingSessions { get; set; }

    }
}
