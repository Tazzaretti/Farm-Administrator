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
    public class PlotRepository : IPlotRepository
    {
        private readonly FarmAdministratorContext _context;

        public PlotRepository(FarmAdministratorContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePlot(PlotDTO plot)
        {
            try
            {
                Users ifUserExist = await _context.Users.FirstOrDefaultAsync(e => e.IdUser == plot.IdUser);

                if (ifUserExist != null)
                {
                    Plots newPlot = new Plots
                    {
                        IdUser = ifUserExist.IdUser,
                        PlotName = plot.PlotName,
                        Size = plot.Size,
                        GroundType = plot.GroundType,
                        Owner = plot.Owner,
                        Notes = plot.Notes,
                        State = plot.State
                    };
                    _context.Plots.Add(newPlot);
                    await _context.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // En caso de error, deshacer la transacción

                // Registrar o reenviar la excepción
                Console.WriteLine(ex.Message);

                return false; // Falló la operación
            }

        }

        public async Task<bool> DeletePlot(int plotId)
        {
            var plotToDelete = await _context.Plots.FindAsync(plotId);

            if (plotToDelete == null)
            {
                throw new Exception("No se encontro el lote");

            }

            try
            {
                _context.Plots.Remove(plotToDelete);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                // En caso de error, deshacer la transacción
                throw new Exception("No se pudo cargar los datos en la base de datos. Desde el repository");
            }
        }

        public async Task<PlotDTO> GetPlotById(int id)
        {
            Plots ifExists = await _context.Plots.FirstOrDefaultAsync(e => e.IdPlot == id);

            if (ifExists != null)
            {
                Plots plotById = await _context.Plots.FindAsync(id);

                PlotDTO result = new PlotDTO()
                {
                    IdUser = plotById.IdUser,
                    PlotName = plotById.PlotName,
                    Size = plotById.Size,
                    GroundType = plotById.GroundType,
                    Owner = plotById.Owner,
                    Notes = plotById.Notes,
                    State = plotById.State
                };
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> ModifyPlot(PlotDTO plot)
        {
            Plots ifExists = await _context.Plots.FirstOrDefaultAsync(e => e.IdPlot == plot.IdPlot);

            if (ifExists != null)
            {
                ifExists.PlotName = plot.PlotName;
                ifExists.Size = plot.Size;
                ifExists.GroundType = plot.GroundType;
                ifExists.Owner = plot.Owner;
                ifExists.Notes = plot.Notes;
                ifExists.State = plot.State;

                _context.Entry(ifExists).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<List<PlotDTO>> GetUserPlots(int idUser)
        {
            Users ifUserExist = await _context.Users.FirstOrDefaultAsync(a => a.IdUser == idUser);

            if (ifUserExist == null)
            {
                throw new Exception("El usuario no existe");
            }

            List<Models.Models.Plots> userPlotsFromDb = await _context.Plots
                .Where(p => p.IdUser == idUser)
                .ToListAsync();

            // Mapear los objetos de entidad a DTO manualmente
            List<PlotDTO> userPlots = userPlotsFromDb
                .Select(plot => new PlotDTO
                {
                    // Asignar las propiedades necesarias de la entidad a las del DTO
                    IdPlot = plot.IdPlot,
                    PlotName = plot.PlotName,
                    Size = plot.Size,
                    GroundType = plot.GroundType,
                    Owner = plot.Owner,
                    Notes = plot.Notes,
                    State = plot.State,
                    IdUser = plot.IdUser
                    // ...
                })
                .ToList();

            return userPlots;
        }
    }
}
