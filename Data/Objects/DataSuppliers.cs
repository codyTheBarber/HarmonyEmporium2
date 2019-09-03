using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Objects
{
    public class DataSuppliers
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string Address { get; set; }
        public DateTime SupplierCreateDate { get; set; }
        public string SupplierPhotoURL { get; set; }
        public string WebsiteURL { get; set; }

    }
}
