using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Services.Interfaces;

namespace FarmAdministrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlotController : Controller
    {
        private readonly IPlotService _service;
        public PlotController(IPlotService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("/CreatePlot")]

        public async Task<IActionResult> AddPlot([FromBody] PlotDTO plot)
        {
            try
            {
                await _service.CreatePlot(plot);
                return CreatedAtAction(nameof(AddPlot), null);

            }
            catch (Exception ex)
            {

                return BadRequest(new { error = ex.Message });

            }
        }


        [HttpDelete]
        [Route("/DeletePlot")]

        public async Task<IActionResult> DeletePlot(int id)
        {
            try
            {
                bool response = await _service.DeletePlot(id);

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
        [Route("/UserPlots")]

        public async Task<IActionResult> GetUserPlots(int id)
        {
            try
            {
                List<PlotDTO> UserPlots = await _service.GetUserPlots(id);
                return Ok(UserPlots);

            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });

            }
        }


        [HttpPost]
        [Route("/ModifyPlot")]
        public async Task<IActionResult> ModifyPlot([FromBody] PlotDTO plot)
        {
            try
            {
                await _service.ModifyPlot(plot);
                return Ok(plot);
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
        [Route("GetPlotById")]
        public async Task<IActionResult> GetPlotById(int id)
        {
            try
            {
                PlotDTO Plot = await _service.GetPlotById(id);
                return Ok(Plot);

            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });

            }
        }
    }
}
