using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class OrderDAL
    {
        #region Direct Properties
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int FeeID { get; set; }
        public bool OnSale { get; set; }
        public string CashOrCard { get; set; }
        public decimal GrandTotal { get; set; }
        public DateTime TimeOfOrder { get; set; }
        #endregion
      
    }
}
