using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Services.Interfaces;

namespace FarmAdministrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : Controller
    {
        private readonly IApplicationService _service;
        public ApplicationController(IApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("/CreateApplication")]

        public async Task<IActionResult> AddAplication([FromBody] ApplicationDTO application)
        {
            try
            {
                await _service.AddAplication(application);
                return CreatedAtAction(nameof(AddAplication), null);

            }
            catch (Exception ex)
            {

                return BadRequest(new { error = ex.Message });

            }
        }


        [HttpDelete]
        [Route("/DeleteApplication")]

        public async Task<IActionResult> DeleteApplication(int id)
        {
            try
            {
                bool response = await _service.DeleteApplication(id);

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
        [Route("/PlotApplications")]

        public async Task<IActionResult> GetPlotApplications(int id)
        {
            try
            {
                List<ApplicationDTO> UserPlots = await _service.GetPlotApplications(id);
                return Ok(UserPlots);

            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });

            }
        }


        [HttpPost]
        [Route("/ModifyApplication")]
        public async Task<IActionResult> ModifyApplication([FromBody] ApplicationDTO application)
        {
            try
            {
                await _service.ModifyApplication(application);
                return Ok(application);
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
        [Route("GetApplicationById")]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            try
            {
                ApplicationDTO application = await _service.GetApplicationById(id);
                return Ok(application);

            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });

            }
        }
    }
}
