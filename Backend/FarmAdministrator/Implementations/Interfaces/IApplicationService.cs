using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IApplicationService
    {
        Task<bool> AddAplication(ApplicationDTO application);
        Task<bool> DeleteApplication(int idApplication);
        Task<ApplicationDTO> GetApplicationById(int idApplication);
        Task ModifyApplication(ApplicationDTO application);
        Task<List<ApplicationDTO>> GetPlotApplications(int plotId);
    }
}
