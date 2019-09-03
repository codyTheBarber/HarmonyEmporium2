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
    public class RolesDataAccess
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        static ErrorLogger Logger = new ErrorLogger();
        public List<DataRoles> GetAllRoles()
        {
            List<DataRoles>allRoles = new List<DataRoles>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("dbo.sp_RolesGetAll", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            DataRoles dURole = new DataRoles();
                            dURole.RoleID = reader.GetInt32(0);
                            dURole.RoleName = reader.GetString(1);

                            
                            allRoles.Add(dURole);

                        }
                    }
                }
            }
            catch (Exception _exception)
            {
                Logger.LogError(_exception);
            }

            return allRoles;
        }
    }
}
