using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Objects;
using Harmony_Emporium.Models;

namespace Harmony_Emporium
{/**/
    public class Mapper
    {
        #region User MAPPER 
        public DataUsers Map(ModelUser mUser)
        {
            DataUsers dUser = new DataUsers();
            dUser.UserID = mUser.UserID;
            dUser.RoleID = mUser.RoleID;
            dUser.Email = mUser.Email;
            dUser.Hash = mUser.Hash;
            dUser.Salt = mUser.Salt;
            dUser.Address = mUser.Address;
            dUser.FirstName = mUser.FirstName;
            dUser.LastName = mUser.LastName;
            dUser.Birthday = mUser.Birthday;
            dUser.Phone = mUser.Phone;
            dUser.AccountCreateDate = mUser.AccountCreateDate;

            return dUser;
        }
        public ModelUser Map(DataUsers dUser)
        {
            ModelUser mUser = new ModelUser();
            mUser.UserID = dUser.UserID;
            mUser.RoleID = dUser.RoleID;
            mUser.Email = dUser.Email;
            mUser.Hash = dUser.Hash;
            mUser.Salt = dUser.Salt;
            mUser.Address = dUser.Address;
            mUser.FirstName = dUser.FirstName;
            mUser.LastName = dUser.LastName;
            mUser.Birthday = dUser.Birthday;
            mUser.Phone = dUser.Phone;
            mUser.AccountCreateDate = dUser.AccountCreateDate;
            mUser.PhotoURL = dUser.Hash;

            return mUser;
        }
        public List<ModelUser> Map(List<DataUsers> allUsers)
        {
            List<ModelUser> returnUsers = new List<ModelUser>();
            foreach (DataUsers dUser in allUsers)
            {
                ModelUser user = new ModelUser();

                user.UserID = dUser.UserID;
                user.RoleID = dUser.RoleID;
                user.Email = dUser.Email;
                user.Address = dUser.Address;
                user.FirstName = dUser.FirstName;
                user.LastName = dUser.LastName;
                user.Birthday = dUser.Birthday;
                user.Phone = dUser.Phone;
                user.AccountCreateDate = dUser.AccountCreateDate;

                returnUsers.Add(user);
            }
            return returnUsers;
        }


        #endregion        

        #region Role MAPPER
        public List<ModelRoles> Map(List<DataRoles> allRoles)
        {
            List<ModelRoles> returnRoles = new List<ModelRoles>();
            foreach (DataRoles dRoles in allRoles)
            {
                ModelRoles roles = new ModelRoles();
                roles.RoleID = dRoles.RoleID;
                roles.RoleName = dRoles.RoleName;
                returnRoles.Add(roles);

            }
            return returnRoles;

        }


        #endregion

        #region ProductMapper

        public List<ModelProducts> Map(List<DataProducts> allProducts)
        {
            List<ModelProducts> returnProducts = new List<ModelProducts>();
            foreach (DataProducts dProduct in allProducts)
            {
                ModelProducts product = new ModelProducts();

                product.ProductID = dProduct.ProductID;
                product.SupplierID = dProduct.SupplierID;
                product.CategoryID = dProduct.CategoryID;
                product.BrandID = dProduct.BrandID;
                product.ProductName = dProduct.ProductName;
                product.RetailPrice = dProduct.RetailPrice;
                product.WholeSalePrice = dProduct.WholeSalePrice;
                product.OnSale = dProduct.OnSale;
                product.Quantity = dProduct.Quantity;
                product.Color = dProduct.Color;
                product.Description = dProduct.Description;
                product.ProductCreateDate = dProduct.ProductCreateDate;
                product.ProductPhotoURL = dProduct.ProductPhotoURL;
                //

                returnProducts.Add(product);
            }
            return returnProducts;
        }
        public ModelProducts Map(DataProducts dProduct)
        {
            ModelProducts returnProduct = new ModelProducts();

            returnProduct.ProductID = dProduct.ProductID;
            returnProduct.ProductName = dProduct.ProductName;
            returnProduct.SupplierID = dProduct.SupplierID;
            returnProduct.SupplierName = dProduct.SupplierName;
            returnProduct.CategoryID = dProduct.CategoryID;
            returnProduct.CategoryName = dProduct.CategoryName;
            returnProduct.BrandID = dProduct.BrandID;
            returnProduct.BrandName = dProduct.BrandName;
            returnProduct.RetailPrice = dProduct.RetailPrice;
            returnProduct.WholeSalePrice = dProduct.WholeSalePrice;
            returnProduct.OnSale = dProduct.OnSale;
            returnProduct.Quantity = dProduct.Quantity;
            returnProduct.Color = dProduct.Color;
            returnProduct.Description = dProduct.Description;
            returnProduct.ProductCreateDate = dProduct.ProductCreateDate;
            returnProduct.ProductPhotoURL = dProduct.ProductPhotoURL;
            returnProduct.BrandPhotoURL = dProduct.BrandPhotoURL;

            return returnProduct;
        }
        public DataProducts Map(ModelProducts mProduct)
        {
            DataProducts returnProduct = new DataProducts();

            returnProduct.ProductID = mProduct.ProductID;
            returnProduct.ProductName = mProduct.ProductName;
            returnProduct.SupplierID = mProduct.SupplierID;
            returnProduct.SupplierName = mProduct.SupplierName;
            returnProduct.CategoryID = mProduct.CategoryID;
            returnProduct.CategoryName = mProduct.CategoryName;
            returnProduct.BrandID = mProduct.BrandID;
            returnProduct.BrandName = mProduct.BrandName;
            returnProduct.RetailPrice = mProduct.RetailPrice;
            returnProduct.WholeSalePrice = mProduct.WholeSalePrice;
            returnProduct.OnSale = mProduct.OnSale;
            returnProduct.Quantity = mProduct.Quantity;
            returnProduct.Color = mProduct.Color;
            returnProduct.Description = mProduct.Description;
            returnProduct.ProductCreateDate = mProduct.ProductCreateDate;
            returnProduct.ProductPhotoURL = mProduct.ProductPhotoURL;
            returnProduct.BrandPhotoURL = mProduct.BrandPhotoURL;

            return returnProduct;
        }
        #endregion

        #region Brands Mapper

        public List<ModelBrands> Map(List<DataBrands> allBrands) //it takes in data does something and returns //void does stuff but doesnt return anything
        {
            List<ModelBrands> returnBrands = new List<ModelBrands>();
            foreach (DataBrands dBrands in allBrands)
            {
                ModelBrands brands = new ModelBrands();
                brands.BrandID = dBrands.BrandID;
                brands.BrandName = dBrands.BrandName;
                brands.BrandCreateDate = dBrands.BrandCreateDate;
                brands.BrandPhotoURL = dBrands.BrandPhotoURL;
                brands.WebsiteURL = dBrands.WebsiteURL;

                returnBrands.Add(brands);

            }
            return returnBrands;

        }

        #endregion

        #region Categories Mapper

        public List<ModelCategories> Map(List<DataCategories> allCategories)
        {
            List<ModelCategories> returnCategories = new List<ModelCategories>();
            foreach (DataCategories dCategories in allCategories)
            {
                ModelCategories categories = new ModelCategories();
                categories.CategoryID = dCategories.CategoryID;
                categories.CategoryName = dCategories.CategoryName;
                categories.CategoryCreateDate = dCategories.CategoryCreateDate;
                categories.CategoryPhotoURL = dCategories.CategoryPhotoURL;
                returnCategories.Add(categories);

            }
            return returnCategories;

        }
        #endregion

        #region Cart Items
        public List<ModelCart> Map(List<DataCartItems> allCartItems)
        {
            List<ModelCart> returnCart = new List<ModelCart>();

            foreach (DataCartItems cartItems in allCartItems)
            {
                ModelCart item = new ModelCart();

                item.ProductID = cartItems.ProductID;
                item.SupplierID = cartItems.SupplierID;
                item.BrandID = cartItems.BrandID;
                item.UserID = cartItems.UserID;
                item.InStockQuantity = cartItems.InStockQuantity;
                item.CartItemQuantity = cartItems.CartItemQuantity;
                item.RetailPrice = cartItems.RetailPrice;
                item.WholeSalePrice = cartItems.WholeSalePrice;
                item.ProductName = cartItems.ProductName;
                item.BrandName = cartItems.BrandName;
                item.SupplierName = cartItems.SupplierName;
                item.ProductPhotoURL = cartItems.ProductPhotoURL;
                item.Description = cartItems.Description;
                item.OnSale = cartItems.OnSale;

                returnCart.Add(item);

            }

            return returnCart;
        }
        public List<DataCartItems> Map(List<ModelCart> modelCartItems)
        {

            List<DataCartItems> dCartItems = new List<DataCartItems>();

            foreach (ModelCart mItems in modelCartItems)
            {
                DataCartItems DataItem = new DataCartItems();

                DataItem.ProductID = mItems.ProductID;
                DataItem.SupplierID = mItems.SupplierID;
                DataItem.BrandID = mItems.BrandID;
                DataItem.UserID = mItems.UserID;
                DataItem.InStockQuantity = mItems.InStockQuantity;
                DataItem.CartItemQuantity = mItems.CartItemQuantity;
                DataItem.RetailPrice = mItems.RetailPrice;
                DataItem.WholeSalePrice = mItems.WholeSalePrice;
                DataItem.ProductName = mItems.ProductName;
                DataItem.BrandName = mItems.BrandName;
                DataItem.SupplierName = mItems.SupplierName;
                DataItem.ProductPhotoURL = mItems.ProductPhotoURL;
                DataItem.Description = mItems.Description;
                DataItem.OnSale = mItems.OnSale;

                dCartItems.Add(DataItem);

            }

            return dCartItems;
        }

        public DataCartItems Map(ModelCart mCartItem)
        {
            DataCartItems dCartItem = new DataCartItems();

            dCartItem.ProductID = mCartItem.ProductID;
            dCartItem.SupplierID = mCartItem.SupplierID;
            dCartItem.BrandID = mCartItem.BrandID;
            dCartItem.UserID = mCartItem.UserID;
            dCartItem.InStockQuantity = mCartItem.InStockQuantity;
            dCartItem.CartItemQuantity = mCartItem.CartItemQuantity;
            dCartItem.RetailPrice = mCartItem.RetailPrice;
            dCartItem.WholeSalePrice = mCartItem.WholeSalePrice;
            dCartItem.ProductName = mCartItem.ProductName;
            dCartItem.BrandName = mCartItem.BrandName;
            dCartItem.SupplierName = mCartItem.SupplierName;
            dCartItem.ProductPhotoURL = mCartItem.ProductPhotoURL;
            dCartItem.Description = mCartItem.Description;
            dCartItem.OnSale = mCartItem.OnSale;

            return dCartItem;
        }




        #endregion

        #region Supplier

        public List<ModelSuppliers> Map(List<DataSuppliers> allSuppliers)
        {
            List<ModelSuppliers> returnSuppliers = new List<ModelSuppliers>();
            foreach (DataSuppliers dSupplier in allSuppliers)
            {
                ModelSuppliers supplier = new ModelSuppliers();

                supplier.SupplierID = dSupplier.SupplierID;
                supplier.SupplierName = dSupplier.SupplierName;
                supplier.ContactName = dSupplier.ContactName;
                supplier.ContactEmail = dSupplier.ContactEmail;
                supplier.Address = dSupplier.Address;
                supplier.SupplierCreateDate = dSupplier.SupplierCreateDate;
                supplier.SuppliersPhotoURL = dSupplier.SuppliersPhotoURL;
                supplier.WebsiteURL = dSupplier.WebsiteURL;

                returnSuppliers.Add(supplier);
            }
            return returnSuppliers;
        }
        public ModelSuppliers Map(DataSuppliers dSupplier)
        {
            ModelSuppliers returnSupplier = new ModelSuppliers();

            returnSupplier.SupplierID = dSupplier.SupplierID;
            returnSupplier.SupplierName = dSupplier.SupplierName;
            returnSupplier.ContactName = dSupplier.ContactName;
            returnSupplier.SupplierName = dSupplier.SupplierName;
            returnSupplier.ContactEmail = dSupplier.ContactEmail;
            returnSupplier.Address = dSupplier.Address;
            returnSupplier.SupplierCreateDate = dSupplier.SupplierCreateDate;
            returnSupplier.SuppliersPhotoURL = dSupplier.SuppliersPhotoURL;
            returnSupplier.WebsiteURL = dSupplier.WebsiteURL;     

            return returnSupplier;
        }
        public DataSuppliers Map(ModelSuppliers mSupplier)
        {
            DataSuppliers returnSupplier = new DataSuppliers();

             returnSupplier.SupplierID = mSupplier.SupplierID;
             returnSupplier.SupplierName = mSupplier.SupplierName;
             returnSupplier.ContactName = mSupplier.ContactName;
             returnSupplier.SupplierName = mSupplier.SupplierName;
             returnSupplier.ContactEmail = mSupplier.ContactEmail;
             returnSupplier.Address = mSupplier.Address;
             returnSupplier.SupplierCreateDate = mSupplier.SupplierCreateDate;
             returnSupplier.SuppliersPhotoURL = mSupplier.SuppliersPhotoURL;
             returnSupplier.WebsiteURL = mSupplier.WebsiteURL;     


            return returnSupplier;
        }


        #endregion

        #region Fees
        public DataFees Map(ModelFees mFee)
        {
            DataFees dFee = new DataFees();
            dFee.FeeID = mFee.FeeID;
            dFee.Tax = mFee.ShippingFee;
            dFee.ShippingFee = mFee.ShippingFee;
            dFee.RateCreationDate= mFee.RateCreationDate;
            dFee.Active= mFee.Active;

            return dFee;
        }
        public ModelFees Map(DataFees dFee)
        {
            ModelFees mFee = new ModelFees();
            mFee.FeeID = dFee.FeeID;
            mFee.Tax = dFee.ShippingFee;
            mFee.ShippingFee = dFee.ShippingFee;
            mFee.RateCreationDate = dFee.RateCreationDate;
            mFee.Active = dFee.Active;

            return mFee;
        }
        public List<ModelFees> Map(List<DataFees> dataFees)
        {
            List<ModelFees> returnFees = new List<ModelFees>();

            foreach (DataFees dFee in dataFees)
            {
                ModelFees mFee = new ModelFees();

                mFee.FeeID = dFee.FeeID;
                mFee.Tax = dFee.ShippingFee;
                mFee.ShippingFee = dFee.ShippingFee;
                mFee.RateCreationDate = dFee.RateCreationDate;
                mFee.Active = dFee.Active;
                
                returnFees.Add(mFee);
            }

            return returnFees;
        }




        #endregion
    }
}