using Data.Implementations;
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
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<bool> AddAplication(ApplicationDTO application)
        {
            bool response = await _applicationRepository.AddAplication(application);

            if (response)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteApplication(int idApplication)
        {
            bool response = await _applicationRepository.DeleteApplication(idApplication);
            if (response)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ApplicationDTO> GetApplicationById(int idApplication)
        {
            ApplicationDTO application = await _applicationRepository.GetApplicationById(idApplication);

            if (application != null)
            {
                return application;

            }
            else
            {
                throw new Exception("Error al traer la aplicacion");
            }
        }

        public async Task ModifyApplication(ApplicationDTO application)
        {
            if (application != null)
            {
                bool result = await _applicationRepository.ModifyApplication(application);
                if (!result)
                {
                    throw new Exception("La aplicacion no fue modificado");
                };
            }
            else
            {
                throw new Exception("La aplicacion no existe");
            }

        }

        public async Task<List<ApplicationDTO>> GetPlotApplications(int plotId)
        {
            try
            {
                List<ApplicationDTO> result = await _applicationRepository.GetPlotApplications(plotId);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
