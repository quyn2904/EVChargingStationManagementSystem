using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVChargingStationManagementSystem.Domain.Entities
{
    public class ChargingStation: BaseEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Longtitude { get; set; }

        public string Latitude { get; set; }

        public Boolean IsActive { get; set; } = false;

        public ICollection<ChargingPoint> ChargingPoints { get; set; }
    }
}
