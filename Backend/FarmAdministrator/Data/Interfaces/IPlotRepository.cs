using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPlotRepository
    {
        Task<bool> CreatePlot(PlotDTO plot);
        Task<bool> DeletePlot(int plotId);
        Task<PlotDTO> GetPlotById(int id);
        Task<bool> ModifyPlot(PlotDTO plot);
        Task<List<PlotDTO>> GetUserPlots(int idUser);

    }
}
