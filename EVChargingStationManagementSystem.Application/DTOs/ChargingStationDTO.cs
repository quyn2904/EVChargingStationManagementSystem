using EVChargingStationManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVChargingStationManagementSystem.Application.DTOs
{
    public class ChargingStationDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Longtitude { get; set; }

        public string Latitude { get; set; }

        public Boolean IsActive { get; set; }

        public ICollection<ChargingPoint> ChargingPoints { get; set; }
    }
}
