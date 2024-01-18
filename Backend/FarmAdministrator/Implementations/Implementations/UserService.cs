using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Models;
using Services.Helpers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IAdminRepository _adminRepository;
        private readonly FarmAdministratorContext _context;
        private readonly IEmailService _email;
        private readonly IEncryptHelper _encrypt;
        public UserService(IAdminRepository adminRepository, IUserRepository repository, FarmAdministratorContext context, IEmailService email, IEncryptHelper encrypt)
        {
            _adminRepository = adminRepository;
            _repository = repository;
            _context = context;
            _email = email;
            _encrypt = encrypt;

        }

        public async Task<UsersDTO> CreateNewUser(UsersDTO newUser)
        {
            try
            {
                // Verificar si el usuario ya existe en la base de datos
                var existingUser = await _repository.GetUserByEmail(newUser.Email);
                if (existingUser != null)
                {
                    throw new Exception("El usuario ya existe");
                }

                // Insertar el nuevo usuario en la base de datos y obtener el usuario con el IdUsuario asignado
               newUser.Password = _encrypt.GetSHA256(newUser.Password);
                await _repository.InsertUser(newUser);

                UsersDTO insertedUser = await _repository.GetUserByEmail(newUser.Email);


                if (insertedUser != null && newUser.UserType == 3)
                {
                    // Crear un administrador si el tipo de usuario es 3
                    AdminDTO newAdmin = new AdminDTO()
                    {
                        IdUser = insertedUser.IdUser,
                        AdminType = 1
                    };

                    await _adminRepository.InsertAdmin(newAdmin);
                }

                return insertedUser;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return null;
            }
        }
        public async Task<UsersDTO> GetUserByIdAsync(int id)
        {
            if (id != null)
            {

                UsersDTO getUser = await _repository.GetUserById(id);
                if (getUser != null)
                {

                    return getUser;

                }
                else
                {

                    throw new Exception("El usuario no existe");
                }

            }
            else
            {
                throw new Exception("La id es null");
            }
        }

        public async Task<List<UsersDTO>> GetAllUsersAsync()
        {
            List<UsersDTO> listOfUsers = await _repository.GetAllUsers();

            if (listOfUsers != null)
            {
                return listOfUsers;
            }
            else
            {
                throw new Exception("Error al traer todos los usuarios");
            }
        }



        public async Task UpdateUserAsync(UsersDTO user)
        {
            try
            {
                Users ifUserExist = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

                if (ifUserExist != null)
                {
                    user.Password = _encrypt.GetSHA256(user.Password);
                    bool result = await _repository.UpdateUser(user);
                    if (!result)
                    {
                        throw new Exception("El usuario no fue modificado");

                    }
                }
                else
                {
                    throw new Exception("El usuario no fue encontrado");
                }
            }
            catch
            {
                throw new Exception("hubo un error en modificar");
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            // Llama al método del repositorio para eliminar un usuario por su ID
            await _repository.DeleteUser(id);
        }

        public async Task<UsersDTO> GetUserByEmailAsync(string email)
        {
            if (email != null)
            {

                UsersDTO getUser = await _repository.GetUserByEmail(email);
                if (getUser != null)
                {

                    return getUser;

                }
                else
                {

                    throw new Exception("El usuario no existe");
                }

            }
            else
            {
                throw new Exception("La id es null");
            }
        }

        public async Task ChangePassword(string email)
        {
            try
            {
                Users ifUserExist = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

                if (ifUserExist == null)
                {
                    throw new Exception("El usuario no fue encontrado");
                }
                string token = GenerateToken.GenerateNumericToken();

                Tokens newToken = new Tokens()
                {
                    Token = token,
                    IdUser = ifUserExist.IdUser,
                    GenerationDate = DateTime.Now.ToString(),
                    ExpirationDate = DateTime.Now.AddDays(1).ToString(),
                    Valid = true
                };
                await _context.Tokens.AddAsync(newToken);
                await _context.SaveChangesAsync();

                EmailDTO newEmail = new EmailDTO()
                {
                    Destinatario = email,
                    Asunto = "Cambiar Contraseña UTN",
                    Contenido = newToken.Token

                };
                bool send = await _email.SendEmail(newEmail);

                if (!send)
                {
                    throw new Exception("El mail no se envio");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al enviar el token");
            }


        }

        public async Task VerifyToken(string token)
        {
            try
            {
                Tokens ifTokenExist = await _context.Tokens.FirstOrDefaultAsync(t => t.Token == token);

                if (ifTokenExist == null)
                {
                    throw new Exception("El token no existe");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo verificar el token");
            }
        }
        public async Task ChangePassword(ChangePasswordDTO user)
        {
            try
            {
                Users ifUserExist = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

                if (ifUserExist != null)
                {
                    user.Password = _encrypt.GetSHA256(user.Password);
                    bool result = await _repository.ChangePassword(user);
                    if (!result)
                    {
                        throw new Exception("El usuario no fue modificado");

                    }
                }
                else
                {
                    throw new Exception("El usuario no fue encontrado");
                }
            }
            catch
            {
                throw new Exception("hubo un error en modificar");
            }
        }

    }
}
