using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Logger;
using Data.Objects;
using System.Data;

namespace Data.DataAccess
{
    public class CartItemsDataAccess
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        static ErrorLogger Logger = new ErrorLogger();

        public List<DataCartItems> GetCartItems(int UserID)
        {
            List<DataCartItems> cartItems = new List<DataCartItems>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("dbo.sp_CartItemsGetAllByUserID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            DataCartItems dCartItem = new DataCartItems();

                            dCartItem.ProductID = reader.GetInt32(0);
                            dCartItem.ProductName = reader.GetString(1);
                            dCartItem.SupplierID = reader.GetInt32(2);
                            dCartItem.OnSale = reader.GetBoolean(3);
                            dCartItem.Description = reader.GetString(4);
                            dCartItem.RetailPrice = reader.GetDecimal(5);
                            dCartItem.WholeSalePrice = reader.GetDecimal(6);
                            dCartItem.ProductPhotoURL = reader.GetString(7);
                            dCartItem.BrandID = reader.GetInt32(8);
                            dCartItem.BrandName = reader.GetString(9);
                            dCartItem.BrandPhotoURL = reader.GetString(10);
                            dCartItem.SupplierName = reader.GetString(11);
                            dCartItem.UserID = reader.GetInt32(12);
                            dCartItem.InStockQuantity = reader.GetInt32(13);
                            dCartItem.CartItemQuantity = reader.GetInt32(14);

                            cartItems.Add(dCartItem);

                        }
                    }
                }
            }
            catch (Exception exception)
            {

                Logger.LogError(exception);
            }

            return cartItems;

        }
        public bool CartItemsDeleteProduct(DataCartItems cartItems)
        {
            bool noError = true;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("dbo.sp_CartItemsDeleteProduct", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", cartItems.UserID);
                        command.Parameters.AddWithValue("@ProductID", cartItems.ProductID);

                       
                        command.ExecuteNonQuery();
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }
            catch (Exception exception)
            {

                Logger.LogError(exception);
            }

            return noError;
        }
        public bool CartItemsInsertProduct(DataCartItems cartItems)
        {
            bool noError = true;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("dbo.sp_CartItemsInsertProduct", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", cartItems.UserID);
                        command.Parameters.AddWithValue("@ProductID", cartItems.ProductID);
                        command.Parameters.AddWithValue("@Quantity", cartItems.CartItemQuantity);
                        command.ExecuteNonQuery();

                        connection.Close();
                        connection.Dispose();
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception);
                noError = false;
            }

            return noError;
        }
        
        public bool CartItemsUpdateQuantity(List<DataCartItems> cartItems)
        {
            bool noError = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    
                    foreach(DataCartItems item in cartItems)
                    {
                        using (SqlCommand command = new SqlCommand("dbo.sp_CartItemsUpdateQuantity", connection))
                        {

                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@UserID", item.UserID);
                            command.Parameters.AddWithValue("@ProductID", item.ProductID);
                            command.Parameters.AddWithValue("@CartItemQuantity", item.CartItemQuantity);

                            
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception exception)
            {

                Logger.LogError(exception);
            }

            return noError;
        }
        public bool SingleCartItemUpdate(DataCartItems cartItem)


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

                            command.Parameters.AddWithValue("@UserID", cartItem.UserID);
                            command.Parameters.AddWithValue("@ProductID", cartItem.ProductID);
                            command.Parameters.AddWithValue("@Quantity", cartItem.CartItemQuantity);


                            command.ExecuteNonQuery();
                            connection.Close();
                            connection.Dispose();
                        }
                    
                }
            }
            catch (Exception exception)
            {

                Logger.LogError(exception);
            }

            return noError;
        }
        public bool ClearCart(int UserID)
        {
            bool noError = true;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("dbo.sp_CartItemsDeleteByUserID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID",UserID);

                        
                        command.ExecuteNonQuery();
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception);
            }
            return noError;
        }
    }
}
