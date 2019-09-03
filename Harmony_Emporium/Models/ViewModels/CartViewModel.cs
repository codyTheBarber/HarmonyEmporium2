using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harmony_Emporium.Models.ViewModels
{
    public class CartViewModel
    {
        public ModelCart CartProduct { get; set; }
        public List<ModelCart> Cart { get; set; }

        public CartViewModel()//CONSTURCTOR
        {
            Cart = new List<ModelCart>();
            CartProduct = new ModelCart();
        }
    }
}