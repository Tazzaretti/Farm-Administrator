using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class UpdateMachineryDTO
    {
        public int IdMachine { get; set; }
        public string Name { get; set; } = ""; // Default empty string
        public string Brand { get; set; } = ""; // Default empty string
        public string Model { get; set; } = ""; // Default empty string
        public int? WorkingHours { get; set; }
        public int IdState { get; set; } // May need validation for required field
    }
}
