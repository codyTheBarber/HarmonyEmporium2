using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harmony_Emporium.Models.ViewModels
{
    public class ProductsViewModel
    {
        public ModelProducts SingleProduct { get; set; }
        public List<ModelProducts> AllProducts { get; set; }
        public List<ModelProducts> CategoryProducts { get; set; }
        public List<ModelProducts> BrandProducts { get; set; }
        public List<ModelProducts> OnSaleProducts { get; set; }
        public List<ModelProducts> FeedProducts { get; set; }

        public ProductsViewModel()
        {
            SingleProduct = new ModelProducts();
            AllProducts = new List<ModelProducts>();
            CategoryProducts = new List<ModelProducts>();
            BrandProducts = new List<ModelProducts>();
            OnSaleProducts = new List<ModelProducts>();
            FeedProducts = new List<ModelProducts>();
        }
    }

}
