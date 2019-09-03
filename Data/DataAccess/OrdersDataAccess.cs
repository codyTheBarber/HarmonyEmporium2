using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Logger;
using Data.Objects;

namespace Data
{
    public class OrdersDataAccess
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        static ErrorLogger Logger = new ErrorLogger();

        public bool OrderGetAll(DataOrders order)
        {
            bool noError = true;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("dbo.sp_OrderGetAll", connection))
                    {
                        
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        
                        command.Parameters.AddWithValue("@OrderID", order.OrderID);



                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exception)
            {
                
                Logger.LogError(exception);
            }

            return noError;
        }
        public bool OrderGetByID(DataOrders order)
        {
            bool noError = true;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("dbo.sp_OrderGetByID", connection))
                    {
                        
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        
                        command.Parameters.AddWithValue("@OrderID", order.OrderID);



                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception);
            }

            return noError;
        }
        public bool OrderGetDetailByID(DataOrders order)
        {
            bool noError = true;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("dbo.sp_OrderGetDetailByID", connection))
                    {
                        
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        
                        command.Parameters.AddWithValue("@OrderID", order.OrderID);



                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exception)
            {
                
                Logger.LogError(exception);
            }

            return noError;
        }
        public bool OrderItemsGetByOrderID(DataOrders order)
        {
            bool noError = true;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("dbo.sp_OrderItemsGetByOrderID", connection))
                    {
                        
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        
                        command.Parameters.AddWithValue("@OrderID", order.OrderID);



                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exception)
            {
               
                Logger.LogError(exception);
            }

            return noError;
        }
        public bool OrderItemsGetByUserID(DataOrders order)
        {
            bool noError = true;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("dbo.sp_OrderItemsGetByUserID", connection))
                    {
                        
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        
                        command.Parameters.AddWithValue("@OrderID", order.OrderID);



                        connection.Open();
                        command.ExecuteNonQuery();
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
  


