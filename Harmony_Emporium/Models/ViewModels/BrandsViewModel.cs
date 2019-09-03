using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harmony_Emporium.Models.ViewModels
{
    public class BrandsViewModel
    {
        /*ViewModels represent only the data we want to display on view whether it is used for displaying or for taking input from view.*/
        public ModelBrands SingleBrand { get; set; }
        public List<ModelBrands> AllBrands { get; set; }


        public BrandsViewModel()//CONSTURCTOR
        {
            SingleBrand = new ModelBrands();
            AllBrands = new List<ModelBrands>();

        }

    }
}