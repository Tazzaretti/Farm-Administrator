using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class AddFuelConsumptionDTO
    {
        public int IdMachine { get; set; }
        public DateTime RecordDate { get; set; }
        public decimal LitersQuantity { get; set; }
    }
}
