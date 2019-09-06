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
    public class SupplierDataAccess
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        static ErrorLogger Logger = new ErrorLogger();

        public DataSuppliers SuppliersGetByID(int SupplierID)
        {
            DataSuppliers dSupplier = new DataSuppliers();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("dbo.sp_SuppliersGetByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SupplierID", SupplierID);
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {

                            dSupplier.SupplierID = reader.GetInt32(0);
                            dSupplier.SupplierName = reader.GetString(1);
                            dSupplier.ContactName = reader.GetString(2);
                            dSupplier.ContactEmail = reader.GetString(3);
                            dSupplier.Address = reader.GetString(4);
                            dSupplier.SupplierCreateDate = reader.GetDateTime(5);
                            dSupplier.SuppliersPhotoURL = reader.GetString(6);
                            dSupplier.WebsiteURL = reader.GetString(7);

                        }
                    }
                }
            }
            catch (Exception exception)
            {

                Logger.LogError(exception);
            }

            return dSupplier;

        }
        public bool CreateSupplier(DataSuppliers supplier)
        {
            bool noError = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("dbo.sp_SuppliersCreate", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                        command.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                        command.Parameters.AddWithValue("@ContactEmail", supplier.ContactEmail);
                        command.Parameters.AddWithValue("@Address", supplier.Address);
                        command.Parameters.AddWithValue("@SupplierCreateDate", supplier.SupplierCreateDate);
                        command.Parameters.AddWithValue("@SuppliersPhotoURL", supplier.SuppliersPhotoURL);
                        command.Parameters.AddWithValue("@WebsiteURL", supplier.WebsiteURL);
                        
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
        public List<DataSuppliers> GetSuppliers()
        {
            List<DataSuppliers> allProducts = new List<DataSuppliers>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("dbo.sp_SuppliersGetAll", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            DataSuppliers dSupplier = new DataSuppliers();

                            dSupplier.SupplierID = reader.GetInt32(0);
                            dSupplier.SupplierName = reader.GetString(1);
                            dSupplier.ContactName = reader.GetString(2);
                            dSupplier.ContactEmail = reader.GetString(3);
                            dSupplier.Address = reader.GetString(4);
                            dSupplier.SupplierCreateDate = reader.GetDateTime(5);
                            dSupplier.SuppliersPhotoURL = reader.GetString(6);
                            dSupplier.WebsiteURL = reader.GetString(7);
                            allProducts.Add(dSupplier);
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
        public bool SuppliersUpdate(DataSuppliers supplier)
        {

            bool noError = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("dbo.sp_SuppliersUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);
                        command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                        command.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                        command.Parameters.AddWithValue("@ContactEmail", supplier.ContactEmail);
                        command.Parameters.AddWithValue("@Address", supplier.Address);                       
                        command.Parameters.AddWithValue("@SuppliersPhotoURL", supplier.SuppliersPhotoURL);
                        command.Parameters.AddWithValue("@WebsiteURL", supplier.WebsiteURL);

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
        public bool SuppliersDeleteByID(int supplierID)
        {
            bool noError = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("dbo.sp_SuppliersDeleteByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SupplierID", supplierID);
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
