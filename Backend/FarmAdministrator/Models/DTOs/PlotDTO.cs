using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class PlotDTO
    {
        public int IdPlot { get; set; }
        public string PlotName { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public int? Size { get; set; }
        public int? GroundType { get; set; }
        public string Owner { get; set; }
        public string Notes { get; set; }
        public int? State { get; set; }
        public int IdUser { get; set; }
    }
}
