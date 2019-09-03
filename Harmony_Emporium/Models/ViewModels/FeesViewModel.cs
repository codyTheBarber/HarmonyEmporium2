using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harmony_Emporium.Models.ViewModels
{
    public class FeesViewModel
    {
        public ModelFees SingleFee { get; set; }
        public List<ModelFees> AllFee { get; set; }


        public FeesViewModel()//CONSTURCTOR
        {
            SingleFee = new ModelFees();
            AllFee = new List<ModelFees>();

        }
    }
}