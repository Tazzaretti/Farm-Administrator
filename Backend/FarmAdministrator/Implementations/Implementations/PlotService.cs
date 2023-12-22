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
    public class PlotService : IPlotService
    {
        private readonly IPlotRepository _plotRepository;
        public PlotService(IPlotRepository plotRepository)
        {
            _plotRepository = plotRepository;
        }

        public async Task<bool> CreatePlot(PlotDTO plot)
        {
            bool response = await _plotRepository.CreatePlot(plot);

            if (response)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeletePlot(int idPlot)
        {
            bool response = await _plotRepository.DeletePlot(idPlot);
            if (response)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<PlotDTO> GetPlotById(int idPlot)
        {
            PlotDTO plot = await _plotRepository.GetPlotById(idPlot);

            if (plot != null)
            {
                return plot;

            }
            else
            {
                throw new Exception("Error al traer el lote");
            }
        }

        public async Task ModifyPlot(PlotDTO plot)
        {
            if (plot != null)
            {
                bool result = await _plotRepository.ModifyPlot(plot);
                if (!result)
                {
                    throw new Exception("El lote no fue modificado");
                };
            }
            else
            {
                throw new Exception("El plot no existe");
            }

        }

        public async Task<List<PlotDTO>> GetUserPlots(int userId)
        {
            try
            {
                List<PlotDTO> result = await _plotRepository.GetUserPlots(userId);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
