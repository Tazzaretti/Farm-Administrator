using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class AddMachineryDTO
    {
        public int IdMachine { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string MachineType { get; set; }
        public DateTime? YearManufactured { get; set; } = null;
        public int? WorkingHours { get; set; }
        public int IdState { get; set; }
    }
}
