using AutoMapper;
using EVChargingStationManagementSystem.Application.DTOs;
using EVChargingStationManagementSystem.Application.Interfaces;
using EVChargingStationManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVChargingStationManagementSystem.Application.Services
{
    public class ChargingStationService
    {
        private readonly IChargingStationRepository _repository;
        private readonly IMapper _mapper;

        public ChargingStationService(IChargingStationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ChargingStationDTO> CreateAsync(CreateChargingStationRequestDTO request)
        {
            var entity = _mapper.Map<ChargingStation>(request);

            var chargingStation = await _repository.CreateAsync(entity);

            return _mapper.Map<ChargingStationDTO>(chargingStation);
        }

        public async Task<ChargingStationDTO?> GetByIdAsync(Guid id)
        {
            return _mapper.Map<ChargingStationDTO>(await _repository.GetByIdAsync(id));
        }
    }
}
