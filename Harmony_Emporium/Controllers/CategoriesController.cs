using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Harmony_Emporium.Models.ViewModels;
using Data.DataAccess;

namespace Harmony_Emporium.Controllers
{
    
    public class CategoriesController : Controller
    {
        static CategoriesDataAccess categoriesDAL = new CategoriesDataAccess();
        static ProductsDataAccess ProductsDAL = new ProductsDataAccess();
        static Mapper mapper = new Mapper();

        // GET: Category
        public ActionResult AllCategories()
        {
            ViewBag.Message = "All Categories";

            CategoriesViewModel viewModel = new CategoriesViewModel();//gives me acces to this class
            viewModel.AllCategories = mapper.Map(categoriesDAL.GetAllCategories());
            return View(viewModel);
        }
        public ActionResult Products(int key)
        {
            ProductsViewModel viewModel = new ProductsViewModel();
            viewModel.CategoryProducts = mapper.Map(ProductsDAL.ProductGetByCategoryID(key));

            return View(viewModel);
        }
    }
}