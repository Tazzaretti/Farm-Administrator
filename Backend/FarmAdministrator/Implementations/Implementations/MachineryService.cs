using Data.Interfaces;
using Microsoft.Extensions.Logging;
using Models.DTOs;
using Models.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class MachineryService : IMachineryService
    {
        private readonly IMachineryRepository _machineryRepository;
        private readonly ILogger<MachineryService> _logger;

        public MachineryService(IMachineryRepository machineryRepository, ILogger<MachineryService> logger)
        {
            _machineryRepository = machineryRepository;
            _logger = logger;
        }

        public async Task<bool> AddMachinery(AddMachineryDTO machineryDTO, int userId)
        {
            try
            {
                // Crear una nueva instancia de Machinery y asignar los valores del DTO
                var newMachinery = new Machinery
                {
                    Name = machineryDTO.Name,
                    Brand = machineryDTO.Brand,
                    Model = machineryDTO.Model,
                    MachineType = machineryDTO.MachineType,
                    YearManufactured = machineryDTO.YearManufactured,
                    WorkingHours = machineryDTO.WorkingHours,
                    IdState = machineryDTO.IdState,
                    Isactive = true // Establecer isactive como true
                };

                // Llamar al método del repositorio para agregar la maquinaria
                return await _machineryRepository.AddMachinery(newMachinery, userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding machinery");
                throw; // Relanzar la excepción para su manejo en capas superiores
            }
        }

        public async Task<bool> DeleteMachinery(int machineId)
        {
            try
            {
                return await _machineryRepository.DeleteMachinery(machineId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting machinery");
                throw;
            }
        }

        public async Task<Machinery> GetMachineryById(int machineId)
        {
            try
            {
                return await _machineryRepository.GetMachineryById(machineId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting machinery by ID");
                throw;
            }
        }

        public async Task<bool> UpdateMachinery(UpdateMachineryDTO machineryDTO)
        {
            try
            {
                // Buscar la maquinaria a actualizar por su ID
                var machineryToUpdate = await _machineryRepository.GetMachineryById(machineryDTO.IdMachine);
                if (machineryToUpdate == null)
                {
                    return false; // La maquinaria no fue encontrada
                }

                // Actualizar las propiedades de la maquinaria solo si el valor del DTO no es null
                if (!String.IsNullOrEmpty(machineryDTO.Name))
                    machineryToUpdate.Name = machineryDTO.Name;
                if (!String.IsNullOrEmpty(machineryDTO.Brand))
                    machineryToUpdate.Brand = machineryDTO.Brand;
                if (!String.IsNullOrEmpty(machineryDTO.Model))
                    machineryToUpdate.Model = machineryDTO.Model;
                if (machineryDTO.WorkingHours != 0)
                    machineryToUpdate.WorkingHours = machineryDTO.WorkingHours;
                if (machineryDTO.IdState != 0)
                    machineryToUpdate.IdState = machineryDTO.IdState;

                // Llamar al método del repositorio para actualizar la maquinaria
                return await _machineryRepository.UpdateMachinery(machineryToUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating machinery");
                throw; // Relanzar la excepción para su manejo en capas superiores
            }
        }


        public async Task<List<Machinery>> GetMachinesByUserId(int userId)
        {
            try
            {
                return await _machineryRepository.GetMachinesByUserId(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting machines by user ID");
                throw;
            }
        }

        public async Task<bool> AddFuelConsumption(AddFuelConsumptionDTO consumption)
        {
            var newConsumption = new HistoryFuelConsumption
            {
                IdMachine = consumption.IdMachine,
                RecordDate = consumption.RecordDate,
                LitersQuantity  = consumption.LitersQuantity
            };
            try
            {
                bool response =  await _machineryRepository.AddFuelConsumption(newConsumption);
                return response;
            }catch (Exception ex)
            {
                _logger.LogError(ex, "Error ocurred while trying to add new consumption from service");
                throw;
            }
        }

        public async Task<List<HistoryFuelConsumption>> GetConsumesForMachine (int machineId)
        {
            try
            {
                List<HistoryFuelConsumption> result = await _machineryRepository.GetConsumesForMachine(machineId);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ocurred while trying to get consumptions for machine from service");
                throw;
            }
        }

        public async Task<bool> AddMaintenance(AddMaintenanceRepairsDTO maintenance)
        {
            var newMaintenance = new MaintenanceRepairs
            {
                IdMachine = maintenance.IdMachine,
                Date = maintenance.Date,
                Description = maintenance.Description,
                WorkedHours = maintenance.WorkedHours,
                SparePartsUsed = maintenance.SparePartsUsed,
                Cost = maintenance.Cost
            };

            try
            {
                return await _machineryRepository.AddMaintenance(newMaintenance);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ocurred while trying to add new maintenance from service");
                throw;
            }
        }
        public async Task<List<MaintenanceRepairs>> GetMaintenancesForMachine(int machineId)
        {
            try
            {
                List<MaintenanceRepairs> result = await _machineryRepository.GetMaintenancesForMachine(machineId);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ocurred while trying to get maintenances/repairs for machine from service");
                throw;
            }
        }
    }
}
