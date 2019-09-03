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
    public class HashHistoryDataAccess
    {
       
            private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            static ErrorLogger Logger = new ErrorLogger();

            public bool HashHistoryGetByUserID(DataHashHistory hashHistory)
            {
                bool noError = true;

                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                   

                    using (SqlCommand command = new SqlCommand("dbo.sp_HashHistoryGetByUserID", connection))
                        {
                            
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            
                            command.Parameters.AddWithValue("@UserID", hashHistory.UserID);
                           


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

