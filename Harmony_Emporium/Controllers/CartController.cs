using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Harmony_Emporium.Models.ViewModels;
using Data.DataAccess;
using Data.Objects;
using Logic.Objects;
using Logic;

namespace Harmony_Emporium.Controllers
{

    public class CartController : Controller
    {
        // GET: CartItems
        static CartItemsDataAccess CartDAL = new CartItemsDataAccess();
        static FeesDataAccess FeesDAL = new FeesDataAccess();
        static Mapper mapper = new Mapper();

        [HttpGet]
        //if user is logged in go to cart page, else user to login page
        public ActionResult MyCart(bool Limit)// <--method
        {
            if (Session["UserID"] != null && (int)Session["RoleID"] >= 1 && (int)Session["RoleID"] <= 4)
            {
                CartViewModel viewModel = new CartViewModel();               
                viewModel.Cart = mapper.Map(CartDAL.GetCartItems((int)Session["UserID"]));
                //determing if error message needs to be displayed
                if (Limit)
                {
                    ViewBag.Limit = Limit;
                }
                else
                {
                    ViewBag.Limit = false;
                }
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Login", "UserAccount");
            }
        }


        public ActionResult ConfirmationsPage()
        {
            ViewBag.Message = "Thank for shopping at Harmony Emporium, Your Order is now being processed";
            return View();
        }
        //key is productID
        public ActionResult AddItem(int key, int Quantity)
        {
            if (Session["UserID"] != null && (int)Session["RoleID"] >= 1 && (int)Session["RoleID"] <= 4)
            {
                List<DataCartItems> dataCart = CartDAL.GetCartItems((int)Session["UserID"]);
                foreach (DataCartItems item in dataCart)
                {//this if statment will basically look at the cart item and add 1 if the item already exsists
                    if (item.ProductID == key)
                    {
                        item.CartItemQuantity = item.CartItemQuantity += 1;
                        CartDAL.SingleCartItemUpdate(item);
                        return RedirectToAction("Index", "Home");
                    }
                }
                CartViewModel userCart = new CartViewModel();
                userCart.CartProduct.ProductID = key;
                userCart.CartProduct.CartItemQuantity = Quantity;
                userCart.CartProduct.UserID = (int)Session["UserID"];
                CartDAL.CartItemsInsertProduct(mapper.Map(userCart.CartProduct));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "UserAccount");
            }
        }
        [HttpPost]
        public ActionResult UpdateQuanity(CartViewModel cartItems)
        {
            //boolean value to determn if a give value is over the stock quantity 
            bool Limit = false;
            //determing if cart item quantity is greater than what is currently in stock and setting the item quantity 
            //accordingly          
            if (cartItems.CartProduct.CartItemQuantity > cartItems.CartProduct.InStockQuantity)
            {
                cartItems.CartProduct.CartItemQuantity = cartItems.CartProduct.InStockQuantity;
                Limit = true;
            }
            CartDAL.SingleCartItemUpdate(mapper.Map(cartItems.CartProduct));
            //setting limit value to show error message 
            return RedirectToAction("MyCart", "Cart", new { Limit = Limit}) ;
            
        }

        public ActionResult ClearCart()
        {
            CartDAL.ClearCart((int)Session["UserID"]);
            return RedirectToAction("MyCart", "Cart", new { Limit = false });
        }
        public ActionResult CheckOut()
        {
            CartLogic cartTotal = new CartLogic();
                
            CartViewModel viewModel = new CartViewModel();
            viewModel.SingleFee = mapper.Map(FeesDAL.GetActiveFee());
            viewModel.Cart = mapper.Map(CartDAL.GetCartItems((int)Session["UserID"]));
            return View(viewModel);
        }
        public ActionResult PurchaseCart(CartViewModel viewModel)
        {
            CartDAL.ClearCart((int)Session["UserID"]);
            return View("ConfirmationPage", "Cart");
        }

        public ActionResult RemoveItem(int UserID, int ProductID)
        {
            CartViewModel tempCart = new CartViewModel();
            tempCart.CartProduct.UserID = UserID;
            tempCart.CartProduct.ProductID = ProductID;
            CartDAL.CartItemsDeleteProduct(mapper.Map(tempCart.CartProduct));
            return RedirectToAction("MyCart", "Cart", new { Limit = false });
        }
    }
}