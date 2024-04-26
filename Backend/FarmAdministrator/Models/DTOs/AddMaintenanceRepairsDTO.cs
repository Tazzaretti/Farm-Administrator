using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class AddMaintenanceRepairsDTO
    {
        public int IdMachine { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int? WorkedHours { get; set; }
        public string SparePartsUsed { get; set; }
        public decimal? Cost { get; set; }
    }
}
