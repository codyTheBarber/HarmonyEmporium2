using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BusinessLogicLayer
{
  public class LoginValidation
    {
        public string ValidatePassword(string userHash, string dbHash)
        {
            return userHash = dbHash;
        }

    }
}
