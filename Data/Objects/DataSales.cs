using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Objects
{
   public class DataSales
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
