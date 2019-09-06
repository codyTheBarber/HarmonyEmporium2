using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;




namespace Logger
{
    public class ErrorLogger
    {
        //make it private we dont want people to access except us readonly meanes the value cant be changed 
        // connection string is a foreign key relationship to our database
        //so we cant actually do anything with the string  but is is in the address that lives in our database

        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        // exception is there where our code breaks we cacn get information from it
        //Exception itself lives within the c# at least the turkoise colored they have objects and methods in them
        public void LogError(Exception exception)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                /*a command to sql, or an SqlCommand ()
                and we're just going to call it command
            so an SQLCommand takes in 2 things
                the command itself, and a connection to the command*/
                //making a command to sql using our connection
                //the command is being executed is a stored procedure
                using (SqlCommand command = new SqlCommand("dbo.sp_ErrorLogCreate", connection))
                {
                    //this is where we define what kind of command we're going to make
                    //we want to fire off a stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    //were passing the stored procedure the params it needs to fire off
                    command.Parameters.AddWithValue("@TimeStamp", DateTime.Now);
                    command.Parameters.AddWithValue("@Message", exception.Message);
                    command.Parameters.AddWithValue("@StackTrace", exception.StackTrace);
                    command.Parameters.AddWithValue("@Source", exception.Source);
                    command.Parameters.AddWithValue("@TargetSite", exception.TargetSite.ToString());

                    connection.Open();
                    command.ExecuteNonQuery();
                }


            }

        }

    }
}



