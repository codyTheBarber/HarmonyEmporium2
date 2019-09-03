using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Objects
{
    public class DataFees
    {
        public int FeeID { get; set; }
        public decimal Tax { get; set; }
        public decimal ShippingFee { get; set; }
        public DateTime RateCreationDate { get; set; }
       
        public bool Active { get; set; }
     
    }
}
