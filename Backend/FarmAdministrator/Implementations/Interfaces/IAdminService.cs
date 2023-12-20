using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAdminService
    {
        Task InsertAdmin(AdminDTO admin);
        Task<AdminDTO> GetByIdAsync(int id);
        Task<List<AdminDTO>> GetAllAdmins();
        Task DeleteAdmin(int id);

        Task DeleteAdminAndUser(int id);
        Task DeleteUser(int id);
    }
}
