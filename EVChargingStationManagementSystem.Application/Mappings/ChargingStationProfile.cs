using AutoMapper;
using EVChargingStationManagementSystem.Application.DTOs;
using EVChargingStationManagementSystem.Domain.Entities;

namespace EVChargingStationManagementSystem.Application.Mappings
{
    public class ChargingStationProfile : Profile
    {
        public ChargingStationProfile()
        {
            CreateMap<ChargingStationDTO, ChargingStation>().ReverseMap();
            CreateMap<CreateChargingStationRequestDTO, ChargingStation>();
        }
    }
}
