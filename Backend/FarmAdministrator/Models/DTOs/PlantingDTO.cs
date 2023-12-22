using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class PlantingDTO
    {
        public int IdPlanting { get; set; }
        public int Crop { get; set; }
        public string Season { get; set; }
        public int? Deep { get; set; }
        public string Distance { get; set; }
        public int? Size { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Cost { get; set; }
        public int IdPlot { get; set; }
    }
}
