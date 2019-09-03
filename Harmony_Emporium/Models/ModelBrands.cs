using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harmony_Emporium.Models
{
    public class ModelBrands
    {
        /*The model represents the data, and does nothing else*/
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public DateTime BrandCreateDate { get; set; }
        public string BrandPhotoURL { get; set; }
        public string WebsiteURL { get; set; }
    }
}