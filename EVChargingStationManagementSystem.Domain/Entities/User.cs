using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVChargingStationManagementSystem.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public DateTime Birthday { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
