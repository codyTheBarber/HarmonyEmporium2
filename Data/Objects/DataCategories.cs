using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Objects
{
    public class DataCategories
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryPhotoURL { get; set; }
        public DateTime CategoryCreateDate { get; set; }
    }
}
