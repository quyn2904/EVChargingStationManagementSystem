using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVChargingStationManagementSystem.Domain.Entities
{
    public class ChargingConnectorType : BaseEntity
    {
        public string Name { get; set; }

        public ChargingStandard Standard { get; set; }
    }

    public enum ChargingStandard
    {
        AC = 0,
        DC = 1,
        Other = 2
    }
}
