﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Models.Models
{
    public partial class Applications
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

        public virtual Plots IdPlotNavigation { get; set; }
    }
}