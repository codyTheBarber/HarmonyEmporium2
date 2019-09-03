using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class FeeDAL
    {
        #region Direct Properties
        public int FeeID { get; set; }
        public decimal Tax { get; set; }
        public decimal ShippingFee { get; set; }
        public DateTime RateCreationDate { get; set; }
        public DateTime RateEndDate { get; set; }
       
        #endregion direct properties

        #region indirect properties

        #endregion indirect properties

       
    }
}
