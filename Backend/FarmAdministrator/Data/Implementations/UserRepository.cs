using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly FarmAdministratorContext _context;

        public UserRepository(FarmAdministratorContext context)
        {
            _context = context;
        }

        public async Task<UsersDTO> GetUserById(int id)
        {
            Users ifExists = await _context.Users.FirstOrDefaultAsync(e => e.IdUser == id);

            if (ifExists != null)
            {
                Users userById = await _context.Users.FindAsync(id);

                UsersDTO result = new UsersDTO()
                {
                    IdUser = userById.IdUser,
                    Email = userById.Email,
                    Password = userById.Password,
                    Name = userById.Name,
                    LastName = userById.LastName,
                    Phone = userById.Phone,
                    Adress = userById.Adress,
                    Education = userById.Education,
                    Experience = userById.Experience,
                    UserType = userById.UserType

                };
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<UsersDTO>> GetAllUsers()
        {
            // Obtener todos los usuarios
            List<Users> users = await _context.Users.Where(u => u.State == 0).ToListAsync();

            // Mapea la lista de usuarios a una lista de objetos UsuariopDTO.
            List<UsersDTO> results = users.Select(user => new UsersDTO
            {
                IdUser = user.IdUser,
                Email = user.Email,
                Password = user.Password,
                UserType = user.UserType
            }).ToList();

            return results;

        }

        public async Task<bool> InsertUser(UsersDTO user)
        {
            Users ifExists = await _context.Users.FirstOrDefaultAsync(e => e.Email == user.Email);

            if (ifExists == null)
            {
                Users newUser = new Users()
                {
                    IdUser = user.IdUser,
                    Password = user.Password,
                    Email = user.Email,
                    Name = user.Name,
                    LastName = user.LastName,
                    UserType = user.UserType,
                    UserRole = 1,
                    Phone = user.Phone,
                    Adress = user.Adress,
                    Experience = user.Experience,
                    Education = user.Education,
                    RegisterDate = DateTime.Now,
                };

                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateUser(UsersDTO user)
        {
            // Buscar el usuario por su Email
            Users existingUser = await _context.Users.FirstOrDefaultAsync(e => e.Email == user.Email);

            if (existingUser != null)
            {
                existingUser.IdUser = user.IdUser;
                existingUser.Password = user.Password;
                existingUser.Name = user.Name;
                existingUser.LastName = user.LastName;
                existingUser.UserRole = user.UserRole;
                existingUser.UserType = user.UserType;
                existingUser.Email = user.Email;
                existingUser.Phone = user.Phone;
                existingUser.Adress = user.Adress;
                existingUser.Experience = user.Experience;
                existingUser.Education = user.Education;
                existingUser.RegisterDate = user.RegisterDate;
                existingUser.State = user.State;
                // Actualiza otros campos si es necesario

                // Marcar la entidad como modificada
                _context.Entry(existingUser).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task DeleteUser(int id)
        {
            // Eliminar un usuario por su ID de la base de datos
            var usuario = await _context.Users.FindAsync(id);
            if (usuario != null)
            {
                usuario.State = 0;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<UsersDTO> GetUserByEmail(string email)
        {
            Users ifExists = await _context.Users.FirstOrDefaultAsync(e => e.Email == email);

            if (ifExists != null)
            {

                UsersDTO result = new UsersDTO()
                {
                    IdUser = ifExists.IdUser,
                    Password = ifExists.Password,
                    Email = ifExists.Email,
                    Name = ifExists.Name,
                    LastName = ifExists.LastName,
                    UserType = ifExists.UserType,
                    UserRole = ifExists.UserRole,
                    Phone = ifExists.Phone,
                    Adress = ifExists.Adress,

                };
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> ChangePassword(ChangePasswordDTO user)
        {
            // Buscar el usuario por su ID
            Users existingUser = await _context.Users.FirstOrDefaultAsync(e => e.Email == user.Email);

            if (existingUser != null)
            {
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                // Actualiza otros campos si es necesario

                // Marcar la entidad como modificada
                _context.Entry(existingUser).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
