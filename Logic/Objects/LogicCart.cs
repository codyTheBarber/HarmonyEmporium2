using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LogicCart
    {
        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public int BrandID { get; set; }
        public int UserID { get; set; }
        public int InStockQuantity { get; set; }
        public int CartItemQuantity { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal WholeSalePrice { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string SupplierName { get; set; }
        public string ProductPhotoURL { get; set; }
        public string BrandPhotoURL { get; set; }
        public string Description { get; set; }
        public bool OnSale { get; set; }
    }
}
