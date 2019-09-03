using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Logic
{
    public class EncryptCredentials
    {
        //MAKING 2 METHODs FOR SALTING AND HASHING
        public string CreateSalt()
        {
            int size = 64; //size is how long the salt will be
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider(); //rng is instance of RNGCryptoServiceProvider
            byte[] buffer = new byte[size]; //an array that contains 64 bytes called buffer
            rng.GetBytes(buffer); //fills buffer with randomized non-zero values

            return Convert.ToBase64String(buffer); //returns buffer 
        }
        public string GenerateHash(string password, string salt)
        {
            password += salt;  //appending salt onto password
            HashAlgorithm hashAlg = new SHA256CryptoServiceProvider(); //creating an instance of SHA256 hash algorithm
            byte[] bytValue = Encoding.UTF8.GetBytes(password); //encodes password into a sequence of bytes called bytValue
            byte[] bytHash = hashAlg.ComputeHash(bytValue); //performs hashing algorithm on bytValue

            return Convert.ToBase64String(bytValue); //returns bytHash 
        }

    }
}
