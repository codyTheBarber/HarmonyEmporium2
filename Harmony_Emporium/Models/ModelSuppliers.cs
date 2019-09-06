using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harmony_Emporium.Models
{
    public class ModelSuppliers
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string Address { get; set; }
        public DateTime SupplierCreateDate { get; set; }
        public string SuppliersPhotoURL { get; set; }
        public string WebsiteURL { get; set; }

    }
}