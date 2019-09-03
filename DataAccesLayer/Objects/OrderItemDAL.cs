using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class OrderItemDAL
    {
        #region Direct Properties
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int SaleID { get; set; }
        public DateTime TimeOfOrder { get; set; }
   
        #endregion
     
       
    }
}

 