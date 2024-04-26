using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Models;
using Services.Implementations;
using Services.Interfaces;

namespace FarmAdministrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineryController : Controller
    {
        private readonly IMachineryService _machineryService;

        public MachineryController(IMachineryService machineryService)
        {
            _machineryService = machineryService;
        }

        [HttpPost]
        [Route("AddMachinery")]
        public async Task<IActionResult> AddMachinery([FromBody] AddMachineryDTO machinery, [FromQuery] int userId)
        {
            try
            {
                // Verificar si se proporciona una fecha de fabricación en la solicitud
                if (machinery.YearManufactured == default(DateTime))
                {
                    // Si YearManufactured tiene el valor predeterminado (01/01/0001), establecerlo como null
                    machinery.YearManufactured = null;
                }

                bool result = await _machineryService.AddMachinery(machinery, userId);
                if (result)
                {
                    return Ok("Machinery added successfully.");
                }
                else
                {
                    return BadRequest("Failed to add machinery.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Delete/{machineryId}")]
        public async Task<IActionResult> DeleteMachinery(int machineryId)
        {
            try
            {
                bool result = await _machineryService.DeleteMachinery(machineryId);
                if (result)
                {
                    return Ok("Machinery deleted successfully.");
                }
                else
                {
                    return NotFound("Machinery not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetMachineryById/{machineryId}")]
        public async Task<IActionResult> GetMachineryById(int machineryId)
        {
            try
            {
                Machinery machinery = await _machineryService.GetMachineryById(machineryId);
                return Ok(machinery);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateMachinery([FromBody] UpdateMachineryDTO machinery)
        {
            try
            {
                bool result = await _machineryService.UpdateMachinery(machinery);
                if (result)
                {
                    return Ok("Machinery updated successfully.");
                }
                else
                {
                    return NotFound("Machinery not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetByUser/{userId}")]
        public async Task<IActionResult> GetMachinesByUserId(int userId)
        {
            try
            {
                List<Machinery> machines = await _machineryService.GetMachinesByUserId(userId);
                if (machines != null)
                {
                    return Ok(machines);
                }
                else
                {
                    return NotFound("No machines found for the specified user.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("AddFuelConsumption")]

        public async Task<IActionResult> AddFuelConsumption([FromBody] AddFuelConsumptionDTO fuelConsumption)
        {
            try
            {
                bool result = await _machineryService.AddFuelConsumption(fuelConsumption);
                if (result)
                {
                    return Ok("Consumption succesfully added");
                }
                else 
                {
                    return NotFound("Machine not found");
                };
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("AddMaintenance")]

        public async Task<IActionResult> AddMaintenance([FromBody] AddMaintenanceRepairsDTO maintenance)
        {
            try
            {
                bool result = await _machineryService.AddMaintenance(maintenance);
                if (result)
                {
                    return Ok("Maintenance succesfully added");
                }
                else 
                {
                    return NotFound("Machine not found");
                };
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
