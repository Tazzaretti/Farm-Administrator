using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IMachineryRepository
    {
        Task<bool> AddMachinery(Machinery machinery, int userId);
        Task<bool> DeleteMachinery(int machineId);
        Task<Machinery> GetMachineryById(int machineId);
        Task<bool> UpdateMachinery(Machinery machinery);
        Task<bool> AddMachineUserRelationship(MachineUserRelationship machineUserRelationship);
        Task<List<Machinery>> GetMachinesByUserId(int userId);
        Task<bool> AddFuelConsumption(HistoryFuelConsumption consumption);
        Task<bool> AddMaintenance(MaintenanceRepairs maintenance);
    }
}
