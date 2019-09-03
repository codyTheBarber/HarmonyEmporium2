using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class ProductDAL
    {
        #region Direct Properties
        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        public string ProductName { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal WholeSalePrice { get; set; }
        public bool OnSale { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public DateTime ProductCreateDate { get; set; }
        public string ProductPhotoURL { get; set; }


        #endregion direct properties

        #region indirect properties
        
        #endregion indirect properties

       
    }
}
