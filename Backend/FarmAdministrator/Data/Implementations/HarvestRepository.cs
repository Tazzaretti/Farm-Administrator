using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class HarvestRepository : IHarvestRepository
    {
        FarmAdministratorContext _context;

        public HarvestRepository(FarmAdministratorContext context)
        {
            _context = context;
        }

        public async Task<bool> AddHarvest(HarvestDTO harvest)
        {
            Plots ifPlotExists = await _context.Plots.FirstOrDefaultAsync(e => e.IdPlot == harvest.IdPlot);

            if (ifPlotExists != null)
            {
                Harvests newHarvest = new Harvests
                {
                    IdPlanting = harvest.IdPlanting,
                    Season = harvest.Season,
                    Method = harvest.Method,
                    Ripeness = harvest.Ripeness,
                    Yield = harvest.Yield,
                    Notes = harvest.Notes,
                    Size = harvest.Size,
                    StartDate = harvest.StartDate,
                    EndDate = harvest.EndDate,
                    Cost = harvest.Cost,
                    IdCrop = harvest.Crop,
                    IdPlot = harvest.IdPlot,

                };

                _context.Harvests.Add(newHarvest);
                await _context.SaveChangesAsync();
                return true;
            }
            else 
            { 
                return false; 
            }
        }

        public async Task<bool> DeleteHarvest(int harvestId)
        {
            var HarvestToDelete = await _context.Harvests.FindAsync(harvestId);

            if (HarvestToDelete == null)
            {
                throw new Exception("No se encontro la cosecha");

            }

            try
            {
                _context.Harvests.Remove(HarvestToDelete);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                // En caso de error, deshacer la transacción
                throw new Exception("No se pudo cargar los datos en la base de datos. Desde el repository");
            }
        }

        public async Task<bool> ModifyHarvest(HarvestDTO harvest)
        {
            Harvests ifExists = await _context.Harvests.FirstOrDefaultAsync(e => e.IdHarvest == harvest.IdHarvest);

            if (ifExists != null)
            {
                ifExists.IdPlanting = harvest.IdPlanting;
                ifExists.Season = harvest.Season;
                ifExists.Method = harvest.Method;
                ifExists.Ripeness = harvest.Ripeness;
                ifExists.Yield = harvest.Yield;
                ifExists.Notes = harvest.Notes;
                ifExists.Size = harvest.Size;
                ifExists.StartDate = harvest.StartDate;
                ifExists.EndDate = harvest.EndDate;
                ifExists.Cost = harvest.Cost;
                ifExists.IdPlot = harvest.IdPlot;

                _context.Entry(ifExists).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<List<HarvestDTO>> GetPlotHarvests(int IdPlot)
        {
            Plots ifPlotExist = await _context.Plots.FirstOrDefaultAsync(a => a.IdPlot == IdPlot);

            if (ifPlotExist == null)
            {
                throw new Exception("El Plot no existe");
            }

            List<Models.Models.Harvests> PlotHarvestsFromDb = await _context.Harvests
                .Where(p => p.IdPlot == IdPlot)
                .ToListAsync();

            // Mapear los objetos de entidad a DTO manualmente
            List<HarvestDTO> plotHarvests = PlotHarvestsFromDb
                .Select(harvest => new HarvestDTO
                {
                    // Asignar las propiedades necesarias de la entidad a las del DTO
                    IdHarvest = harvest.IdHarvest,
                    IdPlanting = harvest.IdPlanting,
                    Season = harvest.Season,
                    Method = harvest.Method,
                    Ripeness = harvest.Ripeness,
                    Yield = harvest.Yield,
                    Notes = harvest.Notes,
                    Size = harvest.Size,
                    StartDate = harvest.StartDate,
                    EndDate = harvest.EndDate,
                    Cost = harvest.Cost,
                    IdPlot = harvest.IdPlot,
                    // ...
                })
                .ToList();

            return plotHarvests;
        }

        public async Task<HarvestDTO> GetHarvestById(int id)
        {
            Harvests ifExists = await _context.Harvests.FirstOrDefaultAsync(e => e.IdHarvest == id);

            if (ifExists != null)
            {
                Harvests harvestsById = await _context.Harvests.FindAsync(id);

                HarvestDTO result = new HarvestDTO()
                {
                    IdPlanting = harvestsById.IdPlanting,
                    Season = harvestsById.Season,
                    Method = harvestsById.Method,
                    Ripeness = harvestsById.Ripeness,
                    Yield = harvestsById.Yield,
                    Notes = harvestsById.Notes,
                    Size = harvestsById.Size,
                    StartDate = harvestsById.StartDate,
                    EndDate = harvestsById.EndDate,
                    Cost = harvestsById.Cost,
                    IdPlot = harvestsById.IdPlot,
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
