using EVChargingStationManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EVChargingStationManagementSystem.Application.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        

    }
}
