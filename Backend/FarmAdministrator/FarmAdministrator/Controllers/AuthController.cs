using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models.DTOs;
using Services.Helpers;
using Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FarmAdministrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IUserRepository _usuarioRepository;
        private readonly IUserService _usuarioService;
        private readonly IAdminRepository _adminRepository;
        private readonly string secretKey;
        private readonly IEncryptHelper _encryptHelper;

        public AuthController(IUserRepository userRepository, IUserService userService, IConfiguration config, IAdminRepository adminRepository, IEncryptHelper encryptHelper)
        {
            _usuarioRepository = userRepository;
            _usuarioService = userService;
            secretKey = config.GetSection("AppSettings:Key").ToString();
            _adminRepository = adminRepository;
            _encryptHelper = encryptHelper;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromBody] AuthDTO user)
        {
            try
            {
                // Buscar el usuario en la base de datos por correo electrónico
                UsersDTO LoginUser = await _usuarioRepository.GetUserByEmail(user.Email);

                if (LoginUser == null)
                {
                    return BadRequest("Usuario no encontrado");
                }

                // Verificar si la contraseña coincide
                string hashPassword = _encryptHelper.GetSHA256(user.Contrasenia);
                if (LoginUser.Password != hashPassword)
                {
                    return BadRequest("Contraseña incorrecta");
                }

                UsersDTO newToken = new UsersDTO()
                {
                    IdUser = LoginUser.IdUser,
                    Email = LoginUser.Email,
                    UserType = LoginUser.UserType
                };
                // Generar un token JWT
                string token = GenerateJwtToken(newToken);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }

        //[HttpPost("Registro")]
        //public async Task<ActionResult<string>> Registro([FromBody] UsuariosDTO newUser)
        //{
        //    try
        //    {
        //        // Verificar si el usuario ya existe en la base de datos
        //        var existingUser = await _usuarioRepository.GetUsuarioByEmail(newUser.Email);
        //        if (existingUser != null)
        //        {
        //            return BadRequest("El usuario ya existe");
        //        }
        //
        //        // Insertar el nuevo usuario en la base de datos y obtener el usuario con el IdUsuario asignado
        //        await _usuarioRepository.InsertUsuario(newUser);
        //
        //        UsuariosDTO insertedUser = await _usuarioRepository.GetUsuarioByEmail(newUser.Email);
        //
        //        if (insertedUser != null)
        //        {
        //            // En este punto, insertedUser.IdUsuario contendrá el ID asignado automáticamente.
        //            if (insertedUser.TipoUsuario == 3)
        //            {
        //                AdminDTO newAdmin = new AdminDTO()
        //                {
        //                    IdUsuario = insertedUser.IdUsuario,
        //                    RolAdmin = 1
        //                };
        //
        //                try
        //                {
        //                    await _adminRepository.InsertAdmin(newAdmin);
        //                }
        //                catch (Exception ex)
        //                {
        //                    return BadRequest(new { error = ex.Message });
        //                }
        //            }
        //
        //            // Generar un token JWT para el nuevo usuario
        //            var token = GenerateJwtToken(newUser);
        //
        //            return Ok(token);
        //        }
        //        else
        //        {
        //            return BadRequest("Error al insertar el usuario.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Error interno del servidor: {ex.Message}");
        //    }
        //}

        [HttpPost("Registro")]
        public async Task<ActionResult<string>> Registro([FromBody] UsersDTO newUser)
        {
            try
            {
                var result = await _usuarioService.CreateNewUser(newUser);

                if (result != null)
                {
                    // Generar un token JWT para el nuevo usuario
                    var token = GenerateJwtToken(result);

                    return Ok(token);
                }
                else
                {
                    return BadRequest("Error al insertar el usuario.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error interno del servidor: {ex.Message}");
            }
        }
        private string GenerateJwtToken(UsersDTO usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.IdUser.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim("Tipo_Usuario", usuario.UserRole.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
