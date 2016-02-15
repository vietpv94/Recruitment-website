using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Base
{
    /// <summary>
    /// Summary description for Utilities
    /// </summary>
    public class Utilities
    {
        public Utilities()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static string Md5Encrypt(string strInput)
        {
            var algorithmType = default(HashAlgorithm);
            var enCoder = new ASCIIEncoding();
            byte[] valueByteArr = enCoder.GetBytes(strInput);
            byte[] hashArray = null;

            // Encrypt Input string 
            algorithmType = new MD5CryptoServiceProvider();
            hashArray = algorithmType.ComputeHash(valueByteArr);

            //  return hashArray.Aggregate("", (current, b) => current + string.Format("{0:x2}", b));
            //Convert byte hash to HEX
            var sb = new StringBuilder();
            foreach (byte b in hashArray)
            {
                sb.AppendFormat("{0:X2}", b);
            }
            return sb.ToString();
        }

    }
}