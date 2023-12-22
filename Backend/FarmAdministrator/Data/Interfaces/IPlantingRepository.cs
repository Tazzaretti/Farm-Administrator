using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPlantingRepository
    {
        Task<bool> AddPlanting(PlantingDTO planting);
        Task<bool> DeletePlanting(int plantingId);
        Task<bool> ModifyPlanting(PlantingDTO planting);
        Task<List<PlantingDTO>> GetPlotPlantings(int IdPlot);
        Task<PlantingDTO> GetPlantingById(int id);
    }
}
