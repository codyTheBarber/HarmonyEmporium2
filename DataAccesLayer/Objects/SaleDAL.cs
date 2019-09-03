using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class SaleDAL
    {
        #region Direct Properties
        public int SaleID { get; set; }
        public int ProductOnSale { get; set; }
        public int CategoryOnSale { get; set; }
        public int BrandOnSale { get; set; }
        public string SaleName { get; set; }
        public decimal PercentOff { get; set; }
        public bool Active { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
                     
        #endregion direct properties

        #region indirect properties

        #endregion indirect properties

       
    }
}
