using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BEFOYS.Common.Converts
{
   public class HashPassword
    {
        public static string HushPassword(string password)
        {
            var Salt = Guid.NewGuid().ToString("N");

            var SaltPassword =password + Salt;
            var SaltPasswordBytes = Encoding.UTF8.GetBytes(SaltPassword);
            var SaltPasswordHush = Convert.ToBase64String(SHA512.Create().ComputeHash(SaltPasswordBytes));
            return SaltPasswordHush;
        }
        public static string SaltPassword(string password)
        {
            var Salt = Guid.NewGuid().ToString("N");

            var SaltPassword = password + Salt;
            return SaltPassword;
        }
    }
}
