using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class MachineryRepository : IMachineryRepository
    {
        private readonly FarmAdministratorContext _context;
        private readonly ILogger<MachineryRepository> _logger;

        public MachineryRepository(FarmAdministratorContext context, ILogger<MachineryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Agrega una nueva maquinaria.
        /// </summary>
        public async Task<bool> AddMachinery(Machinery machinery, int userId)
        {
            try
            {
                // Verificar si el usuario existe
                var userExists = await _context.Users.AnyAsync(u => u.IdUser == userId);
                if (!userExists)
                {
                    return false; // El usuario no existe, por lo tanto, no se puede agregar la maquinaria
                }

                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        // Agregar la maquinaria
                        _context.Machinery.Add(machinery);
                        await _context.SaveChangesAsync();

                        // Agregar la relación entre la máquina y el usuario
                        var machineUserRelationship = new MachineUserRelationship
                        {
                            IdMachine = machinery.IdMachine,
                            IdUser = userId,
                            RelationshipType = 1 //Owner
                                                 // Puedes añadir más propiedades según sea necesario
                        };
                        _context.MachineUserRelationship.Add(machineUserRelationship);
                        await _context.SaveChangesAsync();

                        // Confirmar la transacción
                        await transaction.CommitAsync();

                        return true; // La maquinaria y la relación de máquina-usuario se agregaron con éxito
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error occurred while adding machinery and machine user relationship");
                        // Rollback de la transacción en caso de error
                        await transaction.RollbackAsync();
                        return false; // Error al agregar la maquinaria o la relación de máquina-usuario
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding machinery");
                return false; // Error general al agregar la maquinaria
            }
        }

        /// <summary>
        /// Elimina una maquinaria por su ID.
        /// </summary>
        public async Task<bool> DeleteMachinery(int machineId)
        {
            try
            {
                Machinery machinery = await _context.Machinery.FindAsync(machineId);
                if (machinery == null)
                {
                    return false;
                }

                machinery.Isactive = false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting machinery");
                return false;
            }
        }

        /// <summary>
        /// Obtiene una maquinaria por su ID.
        /// </summary>
        public async Task<Machinery> GetMachineryById(int machineId)
        {
            // Verificar si la maquinaria con el ID especificado existe
            var machineryExists = await _context.Machinery.AnyAsync(m => m.IdMachine == machineId);
            if (!machineryExists)
            {
                return null; // La maquinaria con el ID especificado no existe
            }

            try
            {
                // Recuperar la maquinaria con el ID especificado
                Machinery machineById = await _context.Machinery.FindAsync(machineId);
                return machineById;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting machinery by ID");
                return null;
            }
        }

        /// <summary>
        /// Actualiza una maquinaria.
        /// </summary>
        public async Task<bool> UpdateMachinery(Machinery machinery)
        {
            try
            {
                Machinery existingMachinery = await _context.Machinery.FindAsync(machinery.IdMachine);
                if (existingMachinery == null)
                {
                    return false; // Record not found
                }

                existingMachinery.Name = machinery.Name;
                existingMachinery.Brand = machinery.Brand;
                existingMachinery.Model = machinery.Model;
                existingMachinery.WorkingHours = machinery.WorkingHours;
                existingMachinery.IdState = machinery.IdState;
                // Update other properties as needed

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating machinery");
                return false; // Update failed
            }
        }

        /// <summary>
        /// Agrega una relación entre una máquina y un usuario.
        /// </summary>
        public async Task<bool> AddMachineUserRelationship(MachineUserRelationship machineUserRelationship)
        {
            try
            {
                // Verificar si el usuario y la maquinaria existen
                var userExists = await _context.Users.AnyAsync(u => u.IdUser == machineUserRelationship.IdUser);
                var machineryExists = await _context.Machinery.AnyAsync(m => m.IdMachine == machineUserRelationship.IdMachine);

                if (!userExists || !machineryExists)
                {
                    return false; // El usuario o la maquinaria especificada no existe, por lo tanto, no se puede agregar la relación
                }

                // Validar otros datos de entrada si es necesario

                // Agregar la relación máquina-usuario
                _context.MachineUserRelationship.Add(machineUserRelationship);
                await _context.SaveChangesAsync();

                return true; // La relación se agregó con éxito
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding machine user relationship");
                return false; // Error al agregar la relación
            }
        }

        /// <summary>
        /// Obtiene todas las máquinas asociadas a un usuario por su ID.
        /// </summary>
        public async Task<List<Machinery>> GetMachinesByUserId(int userId)
        {
            try
            {
                // Verificar si el usuario existe
                var userExists = await _context.Users.AnyAsync(u => u.IdUser == userId);
                if (!userExists)
                {
                    return null; // El usuario especificado no existe, por lo tanto, no se pueden obtener las máquinas asociadas
                }

                // Recuperar las máquinas asociadas al usuario con el ID especificado
                var machines = await _context.MachineUserRelationship
                    .Where(r => r.IdUser == userId && r.IdMachineNavigation.Isactive) // Filtrar por IsActive
                    .Select(r => r.IdMachineNavigation)
                    .ToListAsync();

                return machines;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting machines by user ID");
                throw; // Relanzar la excepción para su manejo adicional
            }
        }


        public async Task<bool> AddFuelConsumption(HistoryFuelConsumption consumption)
        {
            var machineExists = await _context.Machinery.AnyAsync(u => u.IdMachine == consumption.IdMachine);

            if (!machineExists)
            {
                return false;
            }

            try
            {
                _context.HistoryFuelConsumption.Add(consumption);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ocurred while trying to add a new consumption");
                throw;
            }
        }

        public async Task<List<HistoryFuelConsumption>> GetConsumesForMachine(int machineId)
        {
            var machineExists = await _context.Machinery.AnyAsync(u => u.IdMachine == machineId);

            if (machineExists == null)
            {
                throw new Exception("The machine doesn't exists");
            }

            
            try
            {
                List<Models.Models.HistoryFuelConsumption> machineConsumes = await _context.HistoryFuelConsumption
                .Where(p => p.IdMachine == machineId).ToListAsync();

                return machineConsumes;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ocurred while trying to get consumptions for machine");
                throw;
            }
        }


        public async Task<bool> AddMaintenance(MaintenanceRepairs maintenance)
        {
            var machineExists = await _context.Machinery.AnyAsync(u => u.IdMachine == maintenance.IdMachine);
            if (!machineExists)
            {
                return false;
            }


            try
            {
                _context.MaintenanceRepairs.Add(maintenance);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ocurred while trying to add new maintenance");
                throw;
            }

        }
    }
}