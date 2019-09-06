using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harmony_Emporium.Models
{
    public class ModelFees
    {
        public int FeeID { get; set; }
        public decimal Tax { get; set; }
        public decimal ShippingFee { get; set; }
        public DateTime RateCreationDate { get; set; }
        public bool Active { get; set; }
    }
}