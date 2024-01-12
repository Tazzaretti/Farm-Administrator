using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Data.Implementations
{
    public class ApplicationRepository : IApplicationRepository
    {
        FarmAdministratorContext _context;

        public ApplicationRepository(FarmAdministratorContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAplication(ApplicationDTO application)
        {
            Plots ifPlotExists = await _context.Plots.FirstOrDefaultAsync(e => e.IdPlot == application.IdPlot);

            if (ifPlotExists != null)
            {
                Applications newApplication = new Applications
                {
                    CropType = application.CropType,
                    StartDate = application.StartDate,
                    EndDate = application.EndDate,
                    Method = application.Method,
                    Notes = application.Notes,
                    ProductType = application.ProductType,
                    Dose = application.Dose,
                    Brand = application.Brand,
                    Cost = application.Cost,
                    IdPlot = application.IdPlot,
                };

                _context.Applications.Add(newApplication);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteApplication(int applicationId)
        {
            var applicationToDelete = await _context.Harvests.FindAsync(applicationId);

            if (applicationToDelete == null)
            {
                throw new Exception("No se encontro la aplicacion");

            }

            try
            {
                _context.Harvests.Remove(applicationToDelete);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                // En caso de error, deshacer la transacción
                throw new Exception("No se pudo cargar los datos en la base de datos. Desde el repository");
            }
        }

        public async Task<bool> ModifyApplication(ApplicationDTO application)
        {
            Applications ifExists = await _context.Applications.FirstOrDefaultAsync(e => e.IdApplication == application.IdApplication);

            if (ifExists != null)
            {
                ifExists.CropType = application.CropType;
                ifExists.StartDate = application.StartDate;
                ifExists.EndDate = application.EndDate;
                ifExists.Method = application.Method;
                ifExists.Notes = application.Notes;
                ifExists.ProductType = application.ProductType;
                ifExists.Dose = application.Dose;
                ifExists.Brand = application.Brand;
                ifExists.Cost = application.Cost;
                ifExists.IdPlot = application.IdPlot;

                _context.Entry(ifExists).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<ApplicationDTO>> GetPlotApplications(int IdPlot)
        {
            Plots ifPlotExist = await _context.Plots.FirstOrDefaultAsync(a => a.IdPlot == IdPlot);

            if (ifPlotExist == null)
            {
                throw new Exception("El Plot no existe");
            }

            List<Models.Models.Applications> PlotApplicationsFromDb = await _context.Applications
                .Where(p => p.IdPlot == IdPlot)
                .ToListAsync();

            // Mapear los objetos de entidad a DTO manualmente
            List<ApplicationDTO> plotApplications = PlotApplicationsFromDb
                .Select(application => new ApplicationDTO
                {
                    // Asignar las propiedades necesarias de la entidad a las del DTO
                    CropType = application.CropType,
                    StartDate = application.StartDate,
                    EndDate = application.EndDate,
                    Method = application.Method,
                    Notes = application.Notes,
                    ProductType = application.ProductType,
                    Dose = application.Dose,
                    Brand = application.Brand,
                    Cost = application.Cost,
                    IdPlot = application.IdPlot,
                    // ...
                })
                .ToList();

            return plotApplications;
        }

        public async Task<ApplicationDTO> GetApplicationById(int id)
        {
            Applications ifExists = await _context.Applications.FirstOrDefaultAsync(e => e.IdApplication == id);

            if (ifExists != null)
            {
                Applications ApplicationsById = await _context.Applications.FindAsync(id);

                ApplicationDTO result = new ApplicationDTO()
                {
                    CropType = ApplicationsById.CropType,
                    StartDate = ApplicationsById.StartDate,
                    EndDate = ApplicationsById.EndDate,
                    Method = ApplicationsById.Method,
                    Notes = ApplicationsById.Notes,
                    ProductType = ApplicationsById.ProductType,
                    Dose = ApplicationsById.Dose,
                    Brand = ApplicationsById.Brand,
                    Cost = ApplicationsById.Cost,
                    IdPlot = ApplicationsById.IdPlot,
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
