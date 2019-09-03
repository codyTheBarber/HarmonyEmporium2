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
    public class UserAdministrationController : Controller
    {
        static Mapper mapper = new Mapper();
        static UserDataAccess UsersDAL = new UserDataAccess();

        public ActionResult AllUsers()
        { 
                ViewBag.Message = "User Accounts";
                UserViewModel viewModel = new UserViewModel();
                viewModel.AllUsers = mapper.Map(UsersDAL.GetAllUsers());
                return View(viewModel);
        }
        public ActionResult DeleteUser(int UserID)
        {

            UsersDAL.UserDeleteByID(UserID);
            return RedirectToAction("AllUsers");
        }
        public ActionResult UpdateUserRole(UserViewModel viewModel)
        {
            UsersDAL.UpdateRole(mapper.Map(viewModel.SingleUser));
            return RedirectToAction("AllUsers");
        }

    }
}