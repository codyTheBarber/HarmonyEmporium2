 using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Logger;
using Data.Objects;

namespace Data.DataAccess
{
    public class ProductsDataAccess
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        static ErrorLogger Logger = new ErrorLogger();

        public bool ProductsUpdateByID(DataProducts product)
        {
           
            bool noError = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("dbo.sp_CartItemsUpdateQuantity", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SupplierID", product.SupplierID);
                        command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                        command.Parameters.AddWithValue("@BrandID", product.BrandID);
                        command.Parameters.AddWithValue("@ProductName", product.ProductName);
                        command.Parameters.AddWithValue("@RetailPrice", product.RetailPrice);
                        command.Parameters.AddWithValue("@WholeSalePrice", product.WholeSalePrice);
                        command.Parameters.AddWithValue("@OnSale", product.OnSale);
                        command.Parameters.AddWithValue("@Quantity", product.Quantity);
                        command.Parameters.AddWithValue("@Color", product.Color);
                        command.Parameters.AddWithValue("@Description", product.Description);
                        command.Parameters.AddWithValue("@ProductCreateDate", product.ProductCreateDate);
                        command.Parameters.AddWithValue("@ProductPhotoURL", product.ProductPhotoURL);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exception)
            {
                noError = false;
                Logger.LogError(exception);
            }
            return noError;
        }

        public List<DataProducts> ProductsGetAll()
        {
            List<DataProducts> allProducts = new List<DataProducts>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("dbo.sp_ProductsGetAll", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            DataProducts dProducts = new DataProducts();

                            dProducts.ProductID = reader.GetInt32(0);
                            dProducts.SupplierID = reader.GetInt32(1);
                            dProducts.CategoryID = reader.GetInt32(2);
                            dProducts.BrandID = reader.GetInt32(3);
                            dProducts.ProductName = reader.GetString(4);
                            dProducts.RetailPrice = reader.GetDecimal(5);
                            dProducts.WholeSalePrice = reader.GetDecimal(6);
                            dProducts.OnSale = reader.GetBoolean(7);
                            dProducts.Quantity = reader.GetInt32(8);
                            dProducts.Color = reader.GetString(9);
                            dProducts.Description = reader.GetString(10);
                            dProducts.ProductCreateDate = reader.GetDateTime(11);
                            dProducts.ProductPhotoURL = reader.GetString(12);
                            allProducts.Add(dProducts);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception);
            }

            return allProducts;
        }
        public DataProducts ProductGetByID(int ProductID)
        {
            DataProducts dProduct = new DataProducts();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("dbo.sp_ProductsGetByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ProductID", ProductID);
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {


                            dProduct.ProductID = reader.GetInt32(0);
                            dProduct.ProductName = reader.GetString(1);
                            dProduct.SupplierID = reader.GetInt32(2);
                            dProduct.SupplierName = reader.GetString(3);
                            dProduct.CategoryID = reader.GetInt32(4);
                            dProduct.CategoryName = reader.GetString(5);
                            dProduct.BrandID = reader.GetInt32(6);
                            dProduct.BrandName = reader.GetString(7);
                            dProduct.RetailPrice = reader.GetDecimal(8);
                            dProduct.WholeSalePrice = reader.GetDecimal(9);
                            dProduct.OnSale = reader.GetBoolean(10);
                            dProduct.Quantity = reader.GetInt32(11);
                            dProduct.Color = reader.GetString(12);
                            dProduct.Description = reader.GetString(13);
                            dProduct.ProductCreateDate = reader.GetDateTime(14);
                            dProduct.ProductPhotoURL = reader.GetString(15);
                            dProduct.BrandPhotoURL = reader.GetString(16);

                        }
                    }
                }
            }
            catch (Exception exception)
            {

                Logger.LogError(exception);
            }

            return dProduct;

        }

        public List<DataProducts> ProductGetByCategoryID(int CategoryID)
        {
            List<DataProducts> categoryProducts = new List<DataProducts>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("dbo.sp_ProductsGetByCategoryID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            DataProducts dProduct = new DataProducts();


                            dProduct.ProductID = reader.GetInt32(0);
                            dProduct.ProductName = reader.GetString(1);
                            dProduct.SupplierID = reader.GetInt32(2);
                            dProduct.SupplierName = reader.GetString(3);
                            dProduct.CategoryID = reader.GetInt32(4);
                            dProduct.CategoryName = reader.GetString(5);
                            dProduct.BrandID = reader.GetInt32(6);
                            dProduct.BrandName = reader.GetString(7);
                            dProduct.RetailPrice = reader.GetDecimal(8);
                            dProduct.WholeSalePrice = reader.GetDecimal(9);
                            dProduct.OnSale = reader.GetBoolean(10);
                            dProduct.Quantity = reader.GetInt32(11);
                            dProduct.Color = reader.GetString(12);
                            dProduct.Description = reader.GetString(13);
                            dProduct.ProductCreateDate = reader.GetDateTime(14);
                            dProduct.ProductPhotoURL = reader.GetString(15);
                            dProduct.BrandPhotoURL = reader.GetString(16);

                            categoryProducts.Add(dProduct);
                        }
                    }
                }
            }
            catch (Exception exception)
            {

                Logger.LogError(exception);
            }

            return categoryProducts;

        }

        public List<DataProducts> ProductsGetByBrandID(int BrandID)
        {
            List<DataProducts> brandProducts = new List<DataProducts>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("dbo.sp_ProductsGetByBrandID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BrandID", BrandID);
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            DataProducts dProduct = new DataProducts();


                            dProduct.ProductID = reader.GetInt32(0);
                            dProduct.ProductName = reader.GetString(1);
                            dProduct.SupplierID = reader.GetInt32(2);
                            dProduct.SupplierName = reader.GetString(3);
                            dProduct.CategoryID = reader.GetInt32(4);
                            dProduct.CategoryName = reader.GetString(5);
                            dProduct.BrandID = reader.GetInt32(6);
                            dProduct.BrandName = reader.GetString(7);
                            dProduct.RetailPrice = reader.GetDecimal(8);
                            dProduct.WholeSalePrice = reader.GetDecimal(9);
                            dProduct.OnSale = reader.GetBoolean(10);
                            dProduct.Quantity = reader.GetInt32(11);
                            dProduct.Color = reader.GetString(12);
                            dProduct.Description = reader.GetString(13);
                            dProduct.ProductCreateDate = reader.GetDateTime(14);
                            dProduct.ProductPhotoURL = reader.GetString(15);
                            dProduct.BrandPhotoURL = reader.GetString(16);

                            brandProducts.Add(dProduct);
                        }
                    }
                }
            }
            catch (Exception exception)
            {

                Logger.LogError(exception);
            }

            return brandProducts;

        }




        public bool ProductsDeleteByID(int productID)
        {
            bool noError = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("dbo.sp_ProductsDeleteByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ProductID", productID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exception)
            {
                noError = false;
                Logger.LogError(exception);
            }
            return noError;

        }
        public bool CreateProduct(DataProducts product)
        {
            bool noError = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("dbo.sp_ProductCreate", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SupplierID", product.SupplierID);
                        command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                        command.Parameters.AddWithValue("@BrandID", product.BrandID);
                        command.Parameters.AddWithValue("@ProductName", product.ProductName);
                        command.Parameters.AddWithValue("@RetailPrice", product.RetailPrice);
                        command.Parameters.AddWithValue("@WholeSalePrice", product.WholeSalePrice);
                        command.Parameters.AddWithValue("@OnSale", product.OnSale);
                        command.Parameters.AddWithValue("@Quantity", product.Quantity);
                        command.Parameters.AddWithValue("@Color", product.Color);
                        command.Parameters.AddWithValue("@Description", product.Description);
                        command.Parameters.AddWithValue("@ProductCreateDate", product.ProductCreateDate);
                        command.Parameters.AddWithValue("@ProductPhotoURL", product.ProductPhotoURL);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exception)
            {
                noError = false;
                Logger.LogError(exception);
            }
            return noError;
        }
    }
}
