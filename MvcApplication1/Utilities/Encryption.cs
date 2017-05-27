using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MvcApplication1.Utilities
{
    public class Encryption
    {
        //password hashing method
        #region Hashing
        public string HashString(string data)
        {
            byte[] dataAsBytes = Encoding.UTF32.GetBytes(data);


            //HMACSHA512 alg = new HMACSHA512();


            SHA512 myHashingAlg = SHA512.Create();
            byte[] digestAsBytes = myHashingAlg.ComputeHash(dataAsBytes);

            return Convert.ToBase64String(digestAsBytes);
        }
        #endregion
    }
}