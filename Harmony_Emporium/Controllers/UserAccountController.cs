using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Objects;
using Data;
using Data.DataAccess;
using Harmony_Emporium.Models;
using Logic;
using Harmony_Emporium;
using Harmony_Emporium.Models.ViewModels;


namespace Harmony_Emporium.Controllers
{

    public class UserAccountController : Controller
    {
        static Mapper mapper = new Mapper();
        static UserDataAccess UsersDAL = new UserDataAccess();
        static RolesDataAccess RolesDAL = new RolesDataAccess();
        static CartItemsDataAccess CartDAL = new CartItemsDataAccess();
        static LoginLogic loginLogic = new LoginLogic(); //creating a new instance of loginlogic
        static EncryptCredentials encrypt = new EncryptCredentials();

        // GET: UserAccount
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Message = "Register for an Account";
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel registerAccount)
        {
            if (registerAccount.Password == registerAccount.ConfirmPassword)
            {
                UserViewModel viewModel = new UserViewModel();
                viewModel.SingleUser.Email = registerAccount.Email;
                string salt = viewModel.SingleUser.Salt = encrypt.CreateSalt();
                viewModel.SingleUser.Hash = encrypt.GenerateHash(registerAccount.Password, salt);
                viewModel.SingleUser.FirstName = registerAccount.FirstName;
                viewModel.SingleUser.LastName = registerAccount.LastName;
                viewModel.SingleUser.Birthday = registerAccount.Birthday;
                viewModel.SingleUser.Phone = registerAccount.Phone;
                viewModel.SingleUser.Address = registerAccount.Address;
                UsersDAL.CreateUser(mapper.Map(viewModel.SingleUser));
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Login(string Email, string Password)
        {
            ViewBag.Message = "Login";
            UserViewModel viewModel = new UserViewModel();
            viewModel.AllRoles = mapper.Map(RolesDAL.GetAllRoles());
            ViewBag.AllRoles = viewModel.AllRoles;
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                UserViewModel viewModel = new UserViewModel();
                CartViewModel cartModel = new CartViewModel();
                EncryptCredentials encrypt = new EncryptCredentials();
                ModelUser userAccount = new ModelUser();

                userAccount = mapper.Map(UsersDAL.GetCredentials(loginUser.Email));
                viewModel.SingleUser.Email = loginUser.Email;
                viewModel.SingleUser.Hash = encrypt.GenerateHash(loginUser.Password, userAccount.Salt);

                if (loginLogic.ValidatePassword(viewModel.SingleUser.Hash, userAccount.Hash))
                {
                    Session["UserID"] = userAccount.UserID;
                    Session["RoleID"] = userAccount.RoleID;
                    Session["Email"] = userAccount.Email;
                    Session["Cart"] = mapper.Map(CartDAL.GetCartItems((int)Session["UserID"]));

                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public ActionResult Settings()
            {
                ViewBag.Message = "Settings";
                return RedirectToAction("Index", "Home");
            }
            public ActionResult LogOut()
            {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
        }
    }