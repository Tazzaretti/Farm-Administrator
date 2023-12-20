using Data.Interfaces;
using Models.DTOs;
using Models.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _usuarioRepository;

        public AdminService(IUserRepository userRepository, IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
            _usuarioRepository = userRepository;
        }

        public async Task InsertAdmin(AdminDTO admin)
        {
            if (admin != null)
            {
                UsersDTO usuario = await _usuarioRepository.GetUserById(admin.IdUser);

                UsersDTO modifiedUser = new UsersDTO()
                {
                    IdUser = usuario.IdUser,
                    Email = usuario.Email,
                    Password = usuario.Password,
                    UserType = 3
                };
                await _usuarioRepository.UpdateUser(modifiedUser);

                await _adminRepository.InsertAdmin(admin);
            }
            else
            {
                throw new Exception("El admin es null");
            }
        }
        public async Task<AdminDTO> GetByIdAsync(int id)
        {
            Admins admin = await _adminRepository.GetAdminById(id);

            if (admin != null)
            {
                AdminDTO request = new AdminDTO
                {
                    IdAdmin = admin.IdAdmin,
                    IdUser = admin.IdUser,
                    AdminType = admin.AdminType,
                };
                return request;
            }
            else
            {
                return null;
            }


        }

        public async Task<List<AdminDTO>> GetAllAdmins()
        {
            List<AdminDTO> listOfAdmins = await _adminRepository.GetAllAdmins();

            if (listOfAdmins != null)
            {
                return listOfAdmins;

            }
            else
            {
                throw new Exception("Error al traer todos los admins");
            }
        }

        public async Task DeleteAdmin(int id)
        {
            // Llama al método del repositorio para eliminar un usuario por su ID
            Admins admin = await _adminRepository.GetAdminById(id);
            if (admin != null)
            {
                UsersDTO usuario = await _usuarioRepository.GetUserById(admin.IdUser);

                UsersDTO modifiedUser = new UsersDTO()
                {
                    IdUser = usuario.IdUser,
                    Email = usuario.Email,
                    Password = usuario.Password,
                    UserType = 1
                };

                await _usuarioRepository.UpdateUser(modifiedUser);
            }
            await _adminRepository.DeleteAdmin(id);


        }
        public async Task DeleteAdminAndUser(int id)
        {
            try
            {
                await _adminRepository.DeleteAdminAndUser(id);
            }
            catch (Exception ex)
            {
                throw new Exception("error en el servicio" + ex);
            }
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                await _adminRepository.DeleteUser(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

    }
}
