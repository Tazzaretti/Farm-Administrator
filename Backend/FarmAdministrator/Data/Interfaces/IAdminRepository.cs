﻿using Models.DTOs;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IAdminRepository
    {
        Task<bool> InsertAdmin(AdminDTO admin);
        Task<Admins?> GetAdminById(int id);
        Task<List<AdminDTO>> GetAllAdmins();
        Task DeleteAdmin(int id);
        Task DeleteAdminAndUser(int id);
        Task DeleteUser(int id);
    }
}
