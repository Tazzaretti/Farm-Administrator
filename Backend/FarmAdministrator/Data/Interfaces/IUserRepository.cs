using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserRepository
    {
        Task<UsersDTO> GetUserById(int id);

        Task<List<UsersDTO>> GetAllUsers();

        // Insertar un nuevo usuario
        Task<bool> InsertUser(UsersDTO user);

        // Actualizar un usuario existente
        Task<bool> UpdateUser(UsersDTO user);

        // Eliminar un usuario por su ID
        Task DeleteUser(int id);

        Task<UsersDTO> GetUserByEmail(string email);
        Task<bool> ChangePassword(ChangePasswordDTO user);
    }
}
