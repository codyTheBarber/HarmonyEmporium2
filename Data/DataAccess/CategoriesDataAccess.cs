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
    public class CategoriesDataAccess
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        static ErrorLogger Logger = new ErrorLogger();

        public List<DataCategories> GetAllCategories()
        {
            List<DataCategories> allCategories = new List<DataCategories>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("dbo.sp_CategoriesGetAll", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            DataCategories dCategories = new DataCategories();
                            dCategories.CategoryID = reader.GetInt32(0);
                            dCategories.CategoryName = reader.GetString(1);
                            dCategories.CategoryCreateDate = reader.GetDateTime(2);
                            dCategories.CategoryPhotoURL = reader.GetString(3);

                            allCategories.Add(dCategories);
                        }
                    }
                    
                }
            }
            catch (Exception _exception)
            {
                Logger.LogError(_exception);
            }
            return allCategories;
        }


    }
}
