using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IHarvestRepository
    {
        Task<bool> AddHarvest(HarvestDTO harvest);
        Task<bool> DeleteHarvest(int harvestId);
        Task<bool> ModifyHarvest(HarvestDTO harvest);
        Task<List<HarvestDTO>> GetPlotHarvests(int IdPlot);
        Task<HarvestDTO> GetHarvestById(int id);
    }
}
