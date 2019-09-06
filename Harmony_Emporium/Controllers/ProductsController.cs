using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Harmony_Emporium.Models.ViewModels;
using Data.DataAccess;
using Data;

namespace Harmony_Emporium.Controllers
{
    public class ProductsController : Controller
    {
        static Mapper mapper = new Mapper();
        static ProductsDataAccess ProductsDAL = new ProductsDataAccess();


        public ActionResult AllProducts(ProductsViewModel allProducts)
        {
            ViewBag.Message = "All Products";
            ProductsViewModel viewModel = new ProductsViewModel();
            viewModel.AllProducts = mapper.Map(ProductsDAL.ProductsGetAll());
            return View();
        }
        public ActionResult Product(int key)
        {
            ProductsViewModel viewModel = new ProductsViewModel();
            viewModel.SingleProduct = mapper.Map(ProductsDAL.ProductGetByID(key));
            return View(viewModel);
        }
        public ActionResult CreateProduct(ProductsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsDAL.CreateProduct(mapper.Map(viewModel.SingleProduct)); 
            }
            return RedirectToAction("AllProducts","Products");
        }
        public ActionResult DeleteProduct(int productID)
        {
            ProductsDAL.ProductsDeleteByID(productID);

            return RedirectToAction("AllProducts", "Products");
        }
        [HttpGet]
        public ActionResult EditProduct(int key)
        {
            ProductsViewModel viewModel = new ProductsViewModel();
            viewModel.SingleProduct = mapper.Map(ProductsDAL.ProductGetByID(key));
            return View();
        }
        [HttpPost]
        public ActionResult EditProduct(ProductsViewModel viewModel)
        {


            return View();
        }
    }
}
