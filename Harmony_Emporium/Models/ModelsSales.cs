using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harmony_Emporium.Models
{
    public class ModelsSales
    {
        public int SaleD { get; set; }
        public int ProductOnSale { get; set; }
        public int CategoryOnSale { get; set; }
        public int BrandOnSale { get; set; }
        public string SaleName { get; set; }
        public decimal PercentOff { get; set; }
        public bool Active { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}