using Data.DataAccess;
using Harmony_Emporium.Models.ViewModels;
using System;
using System.Web.Mvc;

namespace Harmony_Emporium.Controllers
{
    public class ProductsController : Controller
    {
        static Mapper mapper = new Mapper();
        static ProductsDataAccess ProductsDAL = new ProductsDataAccess();
        static CategoriesDataAccess CategoriesDAL = new CategoriesDataAccess();
        static BrandDataAccess BrandsDAL = new BrandDataAccess();
        static SupplierDataAccess SuppliersDAL = new SupplierDataAccess();

        public ActionResult ProductsList()
        {
            ViewBag.Message = "All Products";
            ProductsViewModel viewModel = new ProductsViewModel();

            if ((int)Session["RoleID"] >= 2 && (int)Session["RoleID"] <= 4)
            {
                    viewModel.AllProducts = mapper.Map(ProductsDAL.ProductsGetAll());
                    return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult AllProducts()
        {
            ViewBag.Message = "All Products";
            ProductsViewModel viewModel = new ProductsViewModel();
            viewModel.AllProducts = mapper.Map(ProductsDAL.ProductsGetAll());
            return View(viewModel);
        }

        public ActionResult Product(int key)
        {
            ProductsViewModel viewModel = new ProductsViewModel();
            viewModel.SingleProduct = mapper.Map(ProductsDAL.ProductGetByID(key));
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            ProductsViewModel viewModel = new ProductsViewModel();
            viewModel.AllSuppliers = mapper.Map(SuppliersDAL.GetSuppliers());
            viewModel.AllBrands = mapper.Map(BrandsDAL.GetBrands());
            viewModel.AllCategories = mapper.Map(CategoriesDAL.GetAllCategories());
            switch ((int)Session["RoleID"])
            {
                case 3:
                    return View(viewModel);
                case 4:
                    return View(viewModel);
                default:
                    return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult CreateProduct(ProductsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.SingleProduct.ProductCreateDate = DateTime.Now;
                ProductsDAL.CreateProduct(mapper.Map(viewModel.SingleProduct));
            }
            return RedirectToAction("ProductsList", "Products");
        }
        public ActionResult DeleteProduct(int productID)
        {
            ProductsDAL.ProductsDeleteByID(productID);
            return RedirectToAction("ProductsList", "Products");
        }
        [HttpGet]
        public ActionResult EditProduct(int key)
        {
            ProductsViewModel viewModel = new ProductsViewModel();

            switch ((int)Session["RoleID"])
            {
                case 3:
                    viewModel.SingleProduct = mapper.Map(ProductsDAL.ProductGetByID(key));
                    return View(viewModel);
                case 4:
                    viewModel.SingleProduct = mapper.Map(ProductsDAL.ProductGetByID(key));
                    return View(viewModel);
                default: return RedirectToAction("AllProducts");
            }
        }
        [HttpPost]
        public ActionResult EditProduct(ProductsViewModel viewModel)
        {
            ProductsDAL.ProductsUpdateByID(mapper.Map(viewModel.SingleProduct));
            return RedirectToAction("ProductsList");
        }
    }
}
