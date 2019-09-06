using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Harmony_Emporium.Models.ViewModels;
using Data.DataAccess;

namespace Harmony_Emporium.Controllers
{
    public class SuppliersController : Controller
    {
        static Mapper mapper = new Mapper();
        static SupplierDataAccess SuppliersDAL = new SupplierDataAccess();

        public ActionResult SupplierDetails(int key)
        {
            SupplierViewModel viewModel = new SupplierViewModel();
            viewModel.SingleSupplier = mapper.Map(SuppliersDAL.SuppliersGetByID(key));
            return View(viewModel);
        }

        // GET: Suppliers
        public ActionResult AllSuppliers()
        {
            SupplierViewModel viewModel = new SupplierViewModel();
            switch ((int)Session["RoleID"])
            {
                case 2:
                    viewModel.AllSuppliers = mapper.Map(SuppliersDAL.GetSuppliers());
                    return View(viewModel);
                case 3:
                    viewModel.AllSuppliers = mapper.Map(SuppliersDAL.GetSuppliers());
                    return View(viewModel);
                case 4:
                    viewModel.AllSuppliers = mapper.Map(SuppliersDAL.GetSuppliers());
                    return View(viewModel);
                default:
                    return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public ActionResult EditSupplier(int key)
        {
            SupplierViewModel viewModel = new SupplierViewModel();
            switch ((int)Session["RoleID"])
            {
                case 3:
                    viewModel.SingleSupplier = mapper.Map(SuppliersDAL.SuppliersGetByID(key));
                    return View(viewModel);
                case 4:
                    viewModel.SingleSupplier = mapper.Map(SuppliersDAL.SuppliersGetByID(key));
                    return View(viewModel);
                default:
                    return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult EditSupplier(SupplierViewModel viewModel)
        {
            SuppliersDAL.SuppliersUpdate(mapper.Map(viewModel.SingleSupplier));
            return RedirectToAction("AllSuppliers");
        }
        public ActionResult DeleteSupplier(int key)
        {
            SuppliersDAL.SuppliersDeleteByID(key);
            return RedirectToAction("AllSuppliers");
        }
        [HttpGet]
        public ActionResult CreateSupplier()
        {

            SupplierViewModel viewModel = new SupplierViewModel();

            switch ((int)Session["RoleID"])
            {
                case 3: return View(viewModel);
                case 4: return View(viewModel);
                default: return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult CreateSupplier(SupplierViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.SingleSupplier.SupplierCreateDate = DateTime.Now;
                SuppliersDAL.CreateSupplier(mapper.Map(viewModel.SingleSupplier));
            }
            return RedirectToAction("AllSuppliers");
        }
    }
}