using EVChargingStationManagementSystem.Application.DTOs;
using EVChargingStationManagementSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EVChargingStationManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChargingStationController : Controller
    {
        private readonly ChargingStationService _service;

        public ChargingStationController(ChargingStationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ChargingStationDTO>> Create([FromBody] CreateChargingStationRequestDTO request)
        {
            var createdChargingStationDto = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = createdChargingStationDto.Id }, createdChargingStationDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult<ChargingStationDTO>> GetById([FromRoute] Guid id)
        {
            var chargingStation = await _service.GetByIdAsync(id);

            if (chargingStation == null)
            {
                return NotFound();
            }

            return Ok(chargingStation);
        }
    }
}
