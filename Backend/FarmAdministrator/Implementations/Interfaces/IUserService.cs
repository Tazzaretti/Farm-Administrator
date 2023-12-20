using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<UsersDTO> CreateNewUser(UsersDTO newUser);
        Task<UsersDTO> GetUserByIdAsync(int id);
        Task<List<UsersDTO>> GetAllUsersAsync();
        Task UpdateUserAsync(UsersDTO user);
        Task DeleteUserAsync(int id);
        Task<UsersDTO> GetUserByEmailAsync(string email);
        Task ChangePassword(string email);
        Task VerifyToken(string token);
        Task ChangePassword(ChangePasswordDTO user);


    }
}
