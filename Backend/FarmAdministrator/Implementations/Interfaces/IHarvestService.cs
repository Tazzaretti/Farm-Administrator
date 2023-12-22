using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IHarvestService
    {
        Task<bool> AddHarvest(HarvestDTO harvest);
        Task<bool> DeleteHarvest(int idHarvest);
        Task<HarvestDTO> GetHarvestById(int idHarvest);
        Task<List<HarvestDTO>> GetPlotHarvests(int IdPlot);
        Task ModifyHarvest(HarvestDTO harvest);
    }
}
