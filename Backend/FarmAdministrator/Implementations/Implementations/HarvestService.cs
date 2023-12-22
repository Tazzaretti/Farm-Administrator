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
    public class HarvestService : IHarvestService
    {
        private readonly IHarvestRepository _harvestRepository;
        public HarvestService(IHarvestRepository harvestRepository)
        {
            _harvestRepository = harvestRepository;
        }

        public async Task<bool> AddHarvest(HarvestDTO harvest)
        {
            bool response = await _harvestRepository.AddHarvest(harvest);

            if (response)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteHarvest(int idHarvest)
        {
            bool response = await _harvestRepository.DeleteHarvest(idHarvest);
            if (response)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<HarvestDTO> GetHarvestById(int idHarvest)
        {
            HarvestDTO harvest = await _harvestRepository.GetHarvestById(idHarvest);

            if (harvest != null)
            {
                return harvest;

            }
            else
            {
                throw new Exception("Error al traer la aplicacion");
            }
        }

        public async Task ModifyHarvest(HarvestDTO harvest)
        {
            if (harvest != null)
            {
                bool result = await _harvestRepository.ModifyHarvest(harvest);
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

        public async Task<List<HarvestDTO>> GetPlotHarvests(int IdPlot)
        {
            try
            {
                List<HarvestDTO> result = await _harvestRepository.GetPlotHarvests(IdPlot);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
