using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPlotService
    {
        Task<bool> CreatePlot(PlotDTO plot);
        Task<bool> DeletePlot(int plotId);
        Task<PlotDTO> GetPlotById(int id);
        Task ModifyPlot(PlotDTO plot);
        Task<List<PlotDTO>> GetUserPlots(int idUser);
    }
}
