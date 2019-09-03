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



namespace Data
{

    public class UserDataAccess
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        static ErrorLogger Logger = new ErrorLogger();

        public bool CreateUser(DataUsers user)//creating an instance of DataUsers called user 
                                              //if sucessful no erros it will return true
        {
            bool noError = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {                   

                    using (SqlCommand command = new SqlCommand("dbo.sp_UserCreate", connection))
                    {
                        
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                       
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("Hash", user.Hash);
                        command.Parameters.AddWithValue("@Salt", user.Salt);
                        command.Parameters.AddWithValue("@Address", user.Address);
                        command.Parameters.AddWithValue("@FirstName", user.FirstName);
                        command.Parameters.AddWithValue("LastName", user.LastName);
                        command.Parameters.AddWithValue("@Birthday", DateTime.Now);
                        command.Parameters.AddWithValue("@Phone", user.Phone);
                        command.Parameters.AddWithValue("@AccountCreateDate", DateTime.Now);                       
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
        public bool UserDeleteByID(int UserID)
        {
            bool noError = true;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                   

                    using (SqlCommand command = new SqlCommand("dbo.sp_UserDeleteByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID",UserID);
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
        public List<DataUsers> GetAllUsers()
        {
            List<DataUsers> allUsers = new List<DataUsers>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("dbo.sp_UsersGetAll", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            DataUsers dUser = new DataUsers();

                            dUser.UserID = reader.GetInt32(0);
                            dUser.RoleID = reader.GetInt32(1);
                            dUser.Email = reader.GetString(2);
                            dUser.Address = reader.GetString(3);
                            dUser.FirstName = reader.GetString(4);
                            dUser.LastName = reader.GetString(5);
                            dUser.Birthday = reader.GetDateTime(6);
                            dUser.Phone = reader.GetString(7);
                            dUser.AccountCreateDate = reader.GetDateTime(8);

                            allUsers.Add(dUser);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception);
            }

            return allUsers;
        }
        public bool GetUser(DataUsers user)
 
        {
            bool noError = true;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("dbo.sp_UserGetByID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", user.UserID);


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
        //Get Hash and Salt from User by Email for Password Validation
        public DataUsers GetCredentials(string Email)//TAKES in UserEmail,returns DataUser
     
        {
            DataUsers userByEmail = new DataUsers();//new instance of DataUsers

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open(); //opens connection string to database
                    using (SqlCommand command = new SqlCommand("dbo.sp_UsersGetCredentialsByEmail", connection))
                    {
                        
                        command.CommandType = CommandType.StoredProcedure;                    
                        command.Parameters.AddWithValue("@Email", Email);//passing email as parameter for stored procedure

                        SqlDataReader reader = command.ExecuteReader();//creating instance of SQLDataReader
                        while (reader.Read())//executes until SQLDataReader is finished reading
                        {
                            userByEmail.UserID = reader.GetInt32(0);
                            userByEmail.RoleID = reader.GetInt32(1);
                            userByEmail.Email = reader.GetString(2);
                            userByEmail.Hash = reader.GetString(3);
                            userByEmail.Salt = reader.GetString(4);

                        }                       
                        command.ExecuteNonQuery();//executes stored procedure
                    }
                }//<---closes and disposes of connection
            }
            catch (Exception exception)//catches the error
            {
                //gun being fired off
                Logger.LogError(exception);//passes the info Logger.LogError
            }
            return userByEmail;// returns DataUser with Hash and Salt
        }
        public bool UpdateUser(DataUsers user)
        {
            bool noError = true;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("dbo.sp_UserUpdateByID", connection))
                    {                       
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", user.UserID);
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@Address", user.Address);
                        command.Parameters.AddWithValue("@FirstName", user.FirstName);
                        command.Parameters.AddWithValue("@LastName", user.LastName);
                        command.Parameters.AddWithValue("@Birthday", user.Birthday);
                        command.Parameters.AddWithValue("@Phone", user.Phone);
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
        public bool UpdateUserPassword(DataUsers user)
        {
            bool noError = true;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {                  

                    using (SqlCommand command = new SqlCommand("dbo.sp_UserUpdatePasswordByID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;                        
                        command.Parameters.AddWithValue("@UserID", user.UserID);
                        command.Parameters.AddWithValue("@Hash", user.Hash);
                        command.Parameters.AddWithValue("@Salt", user.Salt);     
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
        public bool UpdateRole(DataUsers user)
        {
            bool noError = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("dbo.sp_UserUpdateRole", connection))
                    {                      
                        command.CommandType = System.Data.CommandType.StoredProcedure;                  
                        command.Parameters.AddWithValue("@UserID", user.UserID);
                        command.Parameters.AddWithValue("@RoleID", user.RoleID);
                       
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