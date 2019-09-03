using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace BusinessLogicLayer
{
    public class CredentialsEncryption
    {
    /*int this class you are just creating these methods*/
            
        
        /*GenerateHash takes in a password and salt and creates a hash*/
        static public string GenerateHash(string password, string salt)
        {
            password += salt;
            HashAlgorithm hashAlg = new SHA256CryptoServiceProvider();
            byte[] bytValue = Encoding.UTF8.GetBytes(password);
            byte[] bytHash = hashAlg.ComputeHash(bytValue);
            return Convert.ToBase64String(bytHash);
        }
        /*create salt takes in an int and that's how long your salt will be*/
        static public string CreateSalt(int size)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

    }
    
}
