using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccesLayer
{
    public class ContextDAL : IDisposable
    {
        #region Context stuff
        SqlConnection _connection;
        public ContextDAL()
        {
            _connection = new SqlConnection();
        }
        public string ConnectionString
        {
            get { return _connection.ConnectionString; }
            set { _connection.ConnectionString = value; }
        }
        void EnsureConnected()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                // there is nothing to do if I am connected
            }
            else if (_connection.State == System.Data.ConnectionState.Broken)
            {
                _connection.Close();
                _connection.Open();
            }
            else if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
            else
            {
                // other states need no processing
            }


        }

        bool Log(Exception ex)
        {
            Console.WriteLine(ex.ToString());

            return false;
        }
        public void Dispose()
        {
            _connection.Dispose();
        }
        #endregion

        #region User stuff
        
        
        
        
        #endregion
    }

}

