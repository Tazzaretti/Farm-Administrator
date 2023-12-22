using Data.Implementations;
using Data.Interfaces;
using Models.DTOs;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class PlantingService : IPlantingService
    {
        private readonly IPlantingRepository _plantingRepository;
        public PlantingService(IPlantingRepository plantingRepository)
        {
            _plantingRepository = plantingRepository;
        }

        public async Task<bool> AddPlanting(PlantingDTO planting)
        {
            bool response = await _plantingRepository.AddPlanting(planting);

            if (response)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeletePlanting(int idPlanting)
        {
            bool response = await _plantingRepository.DeletePlanting(idPlanting);
            if (response)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<PlantingDTO> GetPlantingById(int idPlanting)
        {
            PlantingDTO planting = await _plantingRepository.GetPlantingById(idPlanting);

            if (planting != null)
            {
                return planting;

            }
            else
            {
                throw new Exception("Error al traer la aplicacion");
            }
        }

        public async Task ModifyPlanting(PlantingDTO planting)
        {
            if (planting != null)
            {
                bool result = await _plantingRepository.ModifyPlanting(planting);
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

        public async Task<List<PlantingDTO>> GetPlotPlantings(int IdPlot)
        {
            try
            {
                List<PlantingDTO> result = await _plantingRepository.GetPlotPlantings(IdPlot);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
