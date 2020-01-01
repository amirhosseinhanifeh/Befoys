using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BEFOYS.Common.Converts
{
   public class Password
    {
        public static void CreateHash(string password, out string hash, out string salt)
        {
            salt = Guid.NewGuid().ToString("N");
            var saltPassword = password + salt;
            var saltPasswordBytes = Encoding.UTF8.GetBytes(saltPassword);
            hash = Convert.ToBase64String(SHA512.Create().ComputeHash(saltPasswordBytes));
        }

        public static bool CompareHash(string password, string salt, string hash)
        {
            var saltPassword = password + salt;
            var saltPasswordBytes = Encoding.UTF8.GetBytes(saltPassword);
            var saltPasswordHash = Convert.ToBase64String(SHA512.Create().ComputeHash(saltPasswordBytes));

            return saltPasswordHash == hash ? true : false;
        }
    }
}
