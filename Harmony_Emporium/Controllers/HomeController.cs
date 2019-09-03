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
    public class HomeController : Controller
    {

        static ProductsDataAccess productsDAL = new ProductsDataAccess();
        static Mapper mapper = new Mapper();
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome To Harmony Emporium ";

            ProductsViewModel viewModel = new ProductsViewModel();
            viewModel.FeedProducts = mapper.Map(productsDAL.ProductsGetAll());
            return View(viewModel);
        }

    }
}