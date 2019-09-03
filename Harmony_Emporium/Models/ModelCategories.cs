using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harmony_Emporium.Models
{
    public class ModelCategories
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryPhotoURL { get; set; }
        public DateTime CategoryCreateDate{get;set;}
    }
}