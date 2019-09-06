using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harmony_Emporium.Models.ViewModels
{
    public class CartViewModel
    {
        public ModelFees SingleFee { get; set; }
        public List<ModelFees> AllFee { get; set; }
        public ModelCart CartProduct { get; set; }
        public List<ModelCart> Cart { get; set; }
        public decimal CartTotal { get; set; }
        public decimal Discount { get; set; }


        public CartViewModel()//CONSTURCTOR
        {
            SingleFee = new ModelFees();
            AllFee = new List<ModelFees>();
            Cart = new List<ModelCart>();
            CartProduct = new ModelCart();
        }
    }
}