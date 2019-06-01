using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using NLib.Security;

namespace EncDecSample
{
    class Program
    {
        static void Main(string[] args)
        {
            test();
        }

        public static void test()
        {
            string password = @"my password";

            string secretpassword = @"my secret";
            string salt = "my salt!";

            // create secret key
            byte[] commonKey = NCrypt.CreateSeckey(secretpassword,System.Text.Encoding.UTF8.GetBytes(salt));
            Console.WriteLine("commonKey : " + System.Convert.ToBase64String(commonKey));

            // Encrypt
            byte[] vector = NCrypt.IV;
            string cipherText = NCrypt.Encrypt(commonKey, vector, password);
            Console.WriteLine("cipherText : " + cipherText);

            // Decrypt
            string planeText = NCrypt.Decrypt(commonKey, vector,cipherText);
            Console.WriteLine("planeText : " + planeText);
        }
    }

}
