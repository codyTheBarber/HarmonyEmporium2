using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Objects
{
    public class DataBrands
    {//  get and set is and auto property they are accessors that access data from the database
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public DateTime BrandCreateDate { get; set; }
        public string BrandPhotoURL { get; set; }
        public string WebsiteURL { get; set; }
    }
}
