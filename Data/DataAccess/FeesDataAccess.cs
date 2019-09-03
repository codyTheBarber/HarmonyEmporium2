using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Logger;
using Data.Objects;

namespace Data
{
    public class FeesDataAccess
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        static ErrorLogger Logger = new ErrorLogger();

        public bool FeeCreate(DataFees fees)
        {
            bool noError = true;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {


                    using (SqlCommand command = new SqlCommand("dbo.sp_FeeCreate", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Tax", fees.Tax);
                        command.Parameters.AddWithValue("@ShippingFee", fees.ShippingFee);
                        command.Parameters.AddWithValue("@RateCreationDate", fees.RateCreationDate);


                        connection.Open();
                        
                    }
                }
            }
            catch (Exception exception)
            {

                Logger.LogError(exception);
            }

            return noError;
        }
        public DataFees FeeGetByID(int FeeID)
        {
            DataFees dFee = new DataFees();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {


                    using (SqlCommand command = new SqlCommand("dbo.sp_FeeGetByID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FeeID", FeeID);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            dFee.FeeID = reader.GetInt32(0);
                            dFee.Tax = reader.GetDecimal(1);
                            dFee.ShippingFee = reader.GetDecimal(2);
                            dFee.RateCreationDate = reader.GetDateTime(3);

                        }
                        
                        
                    }
                }
            }
            catch (Exception exception)
            {

                Logger.LogError(exception);
            }

            return dFee;
        }
        public bool FeeUpdateByID(DataFees fees)
        {
            bool noError = true;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {


                    using (SqlCommand command = new SqlCommand("dbo.sp_FeeUpdateByID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Tax", fees.Tax);
                        command.Parameters.AddWithValue("@ShippingFee", fees.ShippingFee);
                        command.Parameters.AddWithValue("@Active", fees.Active);

                        connection.Open();
                        
                    }
                }
            }
            catch (Exception exception)
            {

                Logger.LogError(exception);
            }

            return noError;
        }
        public List<DataFees> FeeGetAll()
        {
            List<DataFees> dFees = new List<DataFees>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {


                    using (SqlCommand command = new SqlCommand("dbo.sp_FeesGetAll", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            DataFees dFee = new DataFees();

                            dFee.FeeID = reader.GetInt32(0);
                            dFee.Tax = reader.GetDecimal(1);
                            dFee.ShippingFee = reader.GetDecimal(2);
                            dFee.RateCreationDate = reader.GetDateTime(3);

                            dFees.Add(dFee);
                        }


                    }
                }
            }
            catch (Exception exception)
            {

                Logger.LogError(exception);
            }

            return dFees;
        }
    }
}
