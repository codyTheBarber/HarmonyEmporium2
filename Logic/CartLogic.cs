﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Objects;

namespace Logic
{
    public class CartLogic
    {
        //meaningfull calculation
        public decimal CalculateTotal(List<LogicCart> cartProducts, LogicFees fees)
        {
            decimal total = 0;
            if (cartProducts == null)
            {
                return fees.ShippingFee;
            }
            foreach (LogicCart product in cartProducts)
            {
                total += (product.RetailPrice *= product.CartItemQuantity);
            }            
            total *=(1+ fees.Tax);
            total += fees.ShippingFee;
            return total;
        }
    }
}
