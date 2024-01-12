using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class PlantingRepository : IPlantingRepository
    {
        FarmAdministratorContext _context;

        public PlantingRepository(FarmAdministratorContext context)
        {
            _context = context;
        }

        public async Task<bool> AddPlanting(PlantingDTO planting)
        {
            Plots ifPlotExists = await _context.Plots.FirstOrDefaultAsync(e => e.IdPlot == planting.IdPlot);

            if (ifPlotExists != null)
            {
                Plantings newPlanting = new Plantings
                {
                    Crop = planting.Crop,
                    Season = planting.Season,
                    Deep = planting.Deep,
                    Distance = planting.Distance,
                    Size = planting.Size,
                    StartDate = planting.StartDate,
                    EndDate = planting.EndDate,
                    Cost = planting.Cost,
                    IdPlot = planting.IdPlot,
                };

                _context.Plantings.Add(newPlanting);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeletePlanting(int plantingId)
        {
            var plantingToDelete = await _context.Plantings.FindAsync(plantingId);

            if (plantingToDelete == null)
            {
                throw new Exception("No se encontro la siembra");

            }

            try
            {
                _context.Plantings.Remove(plantingToDelete);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                // En caso de error, deshacer la transacción
                throw new Exception("No se pudo cargar los datos en la base de datos. Desde el repository");
            }
        }

        public async Task<bool> ModifyPlanting(PlantingDTO planting)
        {
            Plantings ifExists = await _context.Plantings.FirstOrDefaultAsync(e => e.IdPlanting == planting.IdPlanting);

            if (ifExists != null)
            {
                ifExists.Crop = planting.Crop;
                ifExists.Season = planting.Season;
                ifExists.Deep = planting.Deep;
                ifExists.Distance = planting.Distance;
                ifExists.Size = planting.Size;
                ifExists.StartDate = planting.StartDate;
                ifExists.EndDate = planting.EndDate;
                ifExists.Cost = planting.Cost;
                ifExists.IdPlot = planting.IdPlot;

                _context.Entry(ifExists).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<List<PlantingDTO>> GetPlotPlantings(int IdPlot)
        {
            Plots ifPlotExist = await _context.Plots.FirstOrDefaultAsync(a => a.IdPlot == IdPlot);

            if (ifPlotExist == null)
            {
                throw new Exception("El Plot no existe");
            }

            List<Models.Models.Plantings> PlotPlantingsFromDb = await _context.Plantings
                .Where(p => p.IdPlot == IdPlot)
                .ToListAsync();

            // Mapear los objetos de entidad a DTO manualmente
            List<PlantingDTO> plotPlantings = PlotPlantingsFromDb
                .Select(planting => new PlantingDTO
                {
                    // Asignar las propiedades necesarias de la entidad a las del DTO
                    Crop = planting.Crop,
                    Season = planting.Season,
                    Deep = planting.Deep,
                    Distance = planting.Distance,
                    Size = planting.Size,
                    StartDate = planting.StartDate,
                    EndDate = planting.EndDate,
                    Cost = planting.Cost,
                    IdPlot = planting.IdPlot,
                    // ...
                })
                .ToList();

            return plotPlantings;
        }

        public async Task<PlantingDTO> GetPlantingById(int id)
        {
            Plantings ifExists = await _context.Plantings.FirstOrDefaultAsync(e => e.IdPlanting == id);

            if (ifExists != null)
            {
                Plantings PlantingsById = await _context.Plantings.FindAsync(id);

                PlantingDTO result = new PlantingDTO()
                {
                    Crop = PlantingsById.Crop,
                    Season = PlantingsById.Season,
                    Deep = PlantingsById.Deep,
                    Distance = PlantingsById.Distance,
                    Size = PlantingsById.Size,
                    StartDate = PlantingsById.StartDate,
                    EndDate = PlantingsById.EndDate,
                    Cost = PlantingsById.Cost,
                    IdPlot = PlantingsById.IdPlot,
                };
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
