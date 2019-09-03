using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harmony_Emporium.Models.ViewModels
{
    public class CategoriesViewModel
    {
        public ModelCategories SingleCategory { get; set; }
        public List<ModelCategories> AllCategories { get; set; }


        public CategoriesViewModel()//CONSTURCTOR
        {
            SingleCategory = new ModelCategories();
            AllCategories = new List<ModelCategories>();

        }
    }
}