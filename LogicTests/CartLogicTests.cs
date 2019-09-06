using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Tests
{
    [TestClass()]
    public class CartLogicTests
    {
        [TestMethod()]
        public void CalculateTotalTest()
        {
            //Arrange
            CartLogic logic = new CartLogic();
            List<LogicCart> cartItems = new List<LogicCart>();
            LogicCart item1 = new LogicCart() { BrandID = 1, BrandName = "Billy", BrandPhotoURL = "", RetailPrice = 50, CartItemQuantity = 2 };
            cartItems.Add(item1);
            Objects.LogicFees fees = new Objects.LogicFees() { Tax = .10m, ShippingFee = 10.0m };
            decimal ExpectedValue = 2 * 50 + 10 + 10;
            //Act
            decimal Actual = logic.CalculateTotal(cartItems, fees);

            //Assert

            Assert.AreEqual(Actual, ExpectedValue);
        }
    
    
        [TestMethod()]
        public void CalculateTotalTest1()
        {
            //Arrange
            CartLogic logic = new CartLogic();
            List<LogicCart> cartItems = new List<LogicCart>();
            
            Objects.LogicFees fees = new Objects.LogicFees() { Tax = .10m, ShippingFee = 10.0m };
            decimal ExpectedValue = 2 * 0 + 0 + 10;
            //Act
            decimal Actual = logic.CalculateTotal(cartItems, fees);

            //Assert

            Assert.AreEqual(Actual, ExpectedValue);
        }
        [TestMethod()]
        public void CalculateTotalTest2()
        {
            //Arrange
            CartLogic logic = new CartLogic();
            

            Objects.LogicFees fees = new Objects.LogicFees() { Tax = .10m, ShippingFee = 10.0m };
            decimal ExpectedValue = 2 * 0 + 0 + 10;
            //Act
            decimal Actual = logic.CalculateTotal(null, fees);

            //Assert

            Assert.AreEqual(Actual, ExpectedValue);
        }


        /*----------------------------------------------------------------------------------------------*/


        public void CalculateTotalTest3()
        {
            //Arrange
            CartLogic logic = new CartLogic();


            Objects.LogicFees fees = new Objects.LogicFees() { Tax = .10m, ShippingFee = 10.0m };
            decimal ExpectedValue = 2 * 0 + 0 + 10;
            //Act
            decimal Actual = logic.CalculateTotal(null, fees);

            //Assert

            Assert.AreEqual(Actual, ExpectedValue);
        }



        public void CalculateTotalTest4()
        {
            //Arrange
            CartLogic logic = new CartLogic();


            Objects.LogicFees fees = new Objects.LogicFees() { Tax = .10m, ShippingFee = 10.0m };
            decimal ExpectedValue = 2 * 0 + 0 + 10;
            //Act
            decimal Actual = logic.CalculateTotal(null, fees);

            //Assert

            Assert.AreEqual(Actual, ExpectedValue);
        }



        public void CalculateTotalTest6()
        {
            //Arrange
            CartLogic logic = new CartLogic();


            Objects.LogicFees fees = new Objects.LogicFees() { Tax = .10m, ShippingFee = 10.0m };
            decimal ExpectedValue = 2 * 0 + 0 + 10;
            //Act
            decimal Actual = logic.CalculateTotal(null, fees);

            //Assert

            Assert.AreEqual(Actual, ExpectedValue);
        }




       
    }
}