using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class HarvestDTO
    {
        public int IdHarvest { get; set; }
        public int? IdPlanting { get; set; }
        public string Season { get; set; }
        public string Method { get; set; }
        public string Ripeness { get; set; }
        public int? Yield { get; set; }
        public string Notes { get; set; }
        public int? Size { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Cost { get; set; }
        public int IdPlot { get; set; }
    }
}
