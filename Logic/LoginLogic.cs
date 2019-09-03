using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
   public class LoginLogic
    {
        //compares the hash of the user input to the hash stored in the database for user
        public bool ValidatePassword(string userHash, string dbHash)
        {
            return userHash == dbHash; //if userHash= dbhash, returns true; otherwaise false 
        }

    }
}
