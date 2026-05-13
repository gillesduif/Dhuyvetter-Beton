using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Hasher
    {
        public static string Hash(string text)
        {
            return Convert.ToBase64String(SHA512.Create().ComputeHash(Encoding.UTF32.GetBytes(text)));
        }
    }
}
