using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Services.Interfaces;

namespace FarmAdministrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("CrearUsuario")]
        public async Task<IActionResult> CreateNewUser([FromBody] UsersDTO user)
        {
            try
            {
                await _userService.CreateNewUser(user);

                return CreatedAtAction(nameof(CreateNewUser), user);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UsersDTO>> GetById(int id)
        {
            var usuario = await _userService.GetUserByIdAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersDTO>>> GetAll()
        {
            var usuarios = await _userService.GetAllUsersAsync();
            return Ok(usuarios);
        }


        [HttpPost("CambiarContrasenia")]
        public async Task<IActionResult> Put([FromBody] ChangePasswordDTO usuarioDTO)
        {
            try
            {
                await _userService.ChangePassword(usuarioDTO);
                return Ok("contra modificada");
            }
            catch (Exception ex)
            {
                return BadRequest("error al modificar contra" + ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpPost]
        [Route("GenerarToken/{email}")]
        public async Task<ActionResult> ChangePassword(string email)
        {
            try
            {
                await _userService.ChangePassword(email);
                return Ok();
            }
            catch
            {
                return BadRequest("Hubo un error al enviar el mail");
            }
        }

        [HttpPost]
        [Route("VerificarToken/{token}")]
        public async Task<ActionResult> VerifyToken(string token)
        {
            try
            {
                await _userService.VerifyToken(token);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("El token no coincide");
            }
        }
    }
}
