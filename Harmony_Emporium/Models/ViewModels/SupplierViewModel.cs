using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harmony_Emporium.Models.ViewModels
{
    public class SupplierViewModel
    {
        public ModelSuppliers SingleSupplier { get; set; }
        public List<ModelSuppliers> AllSuppliers { get; set; }


        public SupplierViewModel()//CONSTURCTOR
        {
            SingleSupplier = new ModelSuppliers();
            AllSuppliers = new List<ModelSuppliers>();

        }


    }
}