using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IApplicationRepository
    {
        Task<bool> AddAplication(ApplicationDTO application);
        Task<bool> DeleteApplication(int applicationId);
        Task<bool> ModifyApplication(ApplicationDTO application);
        Task<List<ApplicationDTO>> GetPlotApplications(int IdPlot);
        Task<ApplicationDTO> GetApplicationById(int id);


    }
}
