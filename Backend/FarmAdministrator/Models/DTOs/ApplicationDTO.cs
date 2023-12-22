using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ApplicationDTO
    {
        public int IdApplication { get; set; }
        public string CropType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Method { get; set; }
        public string Notes { get; set; }
        public string ProductType { get; set; }
        public int? Dose { get; set; }
        public string Brand { get; set; }
        public decimal? Cost { get; set; }
        public int IdPlot { get; set; }
    }
}
