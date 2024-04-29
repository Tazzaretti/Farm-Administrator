using Models.DTOs;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMachineryService
    {
        Task<bool> AddMachinery(AddMachineryDTO machinery, int userId);
        Task<bool> DeleteMachinery(int machineId);
        Task<Machinery> GetMachineryById(int machineId);
        Task<bool> UpdateMachinery(UpdateMachineryDTO machinery);
        Task<List<Machinery>> GetMachinesByUserId(int userId);
        Task<bool> AddFuelConsumption(AddFuelConsumptionDTO consumption);
        Task<List<HistoryFuelConsumption>> GetConsumesForMachine(int machineId);
        Task<bool> AddMaintenance(AddMaintenanceRepairsDTO maintenance);
    }
}
