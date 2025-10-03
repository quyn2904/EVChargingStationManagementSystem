using EVChargingStationManagementSystem.Application.Interfaces;
using EVChargingStationManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVChargingStationManagementSystem.Infrastructure.Repositories
{
    public class ChargingStationRepository : IChargingStationRepository
    {
        private readonly AppDbContext _appDbContext;

        public ChargingStationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        Task<List<ChargingStation>> IRepository<ChargingStation>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ChargingStation?> GetByIdAsync(Guid id)
        {
            return await _appDbContext.ChargingStations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ChargingStation> CreateAsync(ChargingStation entity)
        {
            await _appDbContext.ChargingStations.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        Task<ChargingStation?> IRepository<ChargingStation>.UpdateAsync(Guid id, ChargingStation entity)
        {
            throw new NotImplementedException();
        }

        Task<ChargingStation?> IRepository<ChargingStation>.DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
