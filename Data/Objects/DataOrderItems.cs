using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Objects
{
    public class DataOrderItems
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int SaleID { get; set; }
        public DateTime TimeOfOrder { get; set; }
        public int Quantity { get; set; }
    }
}
