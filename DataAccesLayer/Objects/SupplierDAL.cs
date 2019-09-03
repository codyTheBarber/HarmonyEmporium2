using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class SupplierDAL
    {
        #region Direct Properties
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string Address { get; set; }
        public DateTime SupplierCreateDate { get; set; }
        public string SuppliersPhotoURL { get; set; }
        public string WebsiteURL { get; set; }

        #endregion direct properties

        #region indirect properties

        #endregion indirect properties

     
    }
}