using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Services.Interfaces;

namespace FarmAdministrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HarvestController : Controller
    {
        private readonly IHarvestService _service;
        public HarvestController(IHarvestService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("/CreateHarvest")]

        public async Task<IActionResult> AddHarvest([FromBody] HarvestDTO harvest)
        {
            try
            {
                await _service.AddHarvest(harvest);
                return CreatedAtAction(nameof(AddHarvest), null);

            }
            catch (Exception ex)
            {

                return BadRequest(new { error = ex.Message });

            }
        }


        [HttpDelete]
        [Route("/DeleteHarvest")]

        public async Task<IActionResult> DeleteHarvest(int id)
        {
            try
            {
                bool response = await _service.DeleteHarvest(id);

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
        [Route("/PlotHarvests")]

        public async Task<IActionResult> GetPlotHarvests(int id)
        {
            try
            {
                List<HarvestDTO> PlotHarvests = await _service.GetPlotHarvests(id);
                return Ok(PlotHarvests);

            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });

            }
        }


        [HttpPost]
        [Route("/ModifyHarvest")]
        public async Task<IActionResult> ModifyHarvest([FromBody] HarvestDTO harvest)
        {
            try
            {
                await _service.ModifyHarvest(harvest);
                return Ok(harvest);
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
        [Route("GetHarvestById")]
        public async Task<IActionResult> GetHarvestById(int id)
        {
            try
            {
                HarvestDTO harvest = await _service.GetHarvestById(id);
                return Ok(harvest);

            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });

            }
        }
    }
}
