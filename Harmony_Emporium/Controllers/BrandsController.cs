using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Harmony_Emporium.Models.ViewModels;
using Data.DataAccess;

namespace Harmony_Emporium.Controllers

{/*Controllers are responsible for controlling the flow of the application execution. When you make a request (means request a page) to MVC application, a controller is responsible for returning the response to that request. The controller can perform one or more actions.*/
    public class BrandsController : Controller
    {

        static ProductsDataAccess ProductsDAL = new ProductsDataAccess();
        static BrandDataAccess brandDAL = new BrandDataAccess();
        static Mapper mapper = new Mapper();
        // GET: Brand
        [HttpGet]
        public ActionResult AllBrands()// <--method
        {
            ViewBag.Message = "All Brands";

            BrandsViewModel viewModel = new BrandsViewModel();//gives me acces to this class
            viewModel.AllBrands = mapper.Map(brandDAL.GetBrands());
            return View(viewModel);
        }
        public ActionResult Products(int key)
        {
            ProductsViewModel viewModel = new ProductsViewModel();
            viewModel.BrandProducts = mapper.Map(ProductsDAL.ProductsGetByBrandID(key));

            return View(viewModel);
        }

    }
}