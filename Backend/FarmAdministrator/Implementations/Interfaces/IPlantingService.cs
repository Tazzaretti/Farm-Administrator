using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPlantingService
    {
        Task<bool> AddPlanting(PlantingDTO planting);
        Task<bool> DeletePlanting(int idPlanting);
        Task<PlantingDTO> GetPlantingById(int idPlanting);
        Task<List<PlantingDTO>> GetPlotPlantings(int IdPlot);
        Task ModifyPlanting(PlantingDTO planting);
    }
}
