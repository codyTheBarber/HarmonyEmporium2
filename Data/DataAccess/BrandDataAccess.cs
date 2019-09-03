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

namespace Data.DataAccess
{
   public class BrandDataAccess
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        static ErrorLogger Logger = new ErrorLogger();
        public List<DataBrands> GetBrands()
        {
            List<DataBrands> allBrands = new List<DataBrands>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("dbo.sp_BrandsGetAll", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            DataBrands dBrands = new DataBrands();
                            dBrands.BrandID = reader.GetInt32(0);
                            dBrands.BrandName = reader.GetString(1);
                            dBrands.BrandCreateDate = reader.GetDateTime(2);
                            dBrands.BrandPhotoURL = reader.GetString(3);
                            dBrands.WebsiteURL = reader.GetString(4);


                            allBrands.Add(dBrands);

                        }
                    }
                    
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception);
            }

            return allBrands;
        }
    }
}
