using EVChargingStationManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVChargingStationManagementSystem.Application.Interfaces
{
    public interface IChargingStationRepository : IRepository<ChargingStation>
    {
    }
}
