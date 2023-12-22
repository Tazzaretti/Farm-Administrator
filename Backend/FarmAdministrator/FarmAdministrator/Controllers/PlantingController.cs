using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Services.Interfaces;

namespace FarmAdministrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantingController : Controller
    {
        private readonly IPlantingService _service;
        public PlantingController(IPlantingService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("/CreatePlanting")]

        public async Task<IActionResult> AddPlanting([FromBody] PlantingDTO planting)
        {
            try
            {
                await _service.AddPlanting(planting);
                return CreatedAtAction(nameof(AddPlanting), null);

            }
            catch (Exception ex)
            {

                return BadRequest(new { error = ex.Message });

            }
        }


        [HttpDelete]
        [Route("/DeletePlanting")]

        public async Task<IActionResult> DeletePlanting(int id)
        {
            try
            {
                bool response = await _service.DeletePlanting(id);

                if (response)
                {
                    return Ok();

                }
                else
                {
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {

                return BadRequest(new { error = ex.Message });

            }
        }


        [HttpGet]
        [Route("/PlotPlantings")]

        public async Task<IActionResult> GetPlotPlantings(int id)
        {
            try
            {
                List<PlantingDTO> plotPlantings = await _service.GetPlotPlantings(id);
                return Ok(plotPlantings);

            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });

            }
        }


        [HttpPost]
        [Route("/ModifyPlanting")]
        public async Task<IActionResult> ModifyPlanting([FromBody] PlantingDTO planting)
        {
            try
            {
                await _service.ModifyPlanting(planting);
                return Ok(planting);
            }
            catch (Exception ex)
            {
                // Imprimir la excepción completa en la consola
                Console.WriteLine(ex.ToString());

                // También puedes registrar la excepción en un archivo de registro si es necesario

                return BadRequest(new { error = ex.Message });
            }
        }


        [HttpGet]
        [Route("GetPlantingById")]
        public async Task<IActionResult> GetPlantingById(int id)
        {
            try
            {
                PlantingDTO planting = await _service.GetPlantingById(id);
                return Ok(planting);

            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });

            }
        }
    }
}
