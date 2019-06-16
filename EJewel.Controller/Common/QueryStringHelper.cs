using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cryptography.Encryption;
namespace EJewel.Controller.Common
{
    /*
     * Partha Ranjan
     * @ 29-01-13
     * This class use to encode decode the string
     * */
    public sealed class QueryStringHelper
    {
       const string passPhrase = "Pas5pr@se";                // can be any string
       const string saltValue = "s@1tValue";                 // can be any string
       const string hashAlgorithm = "SHA1";                  // can be "MD5"
       const int passwordIterations = 2;                     // can be any number
       const string initVector = "@1B2c3D4e5F6g7H8";         // must be 16 bytes
       const int keySize = 256;                              // can be 192 or 128
        // http://www.obviex.com/samples/Encryption.aspx 
        public static string encrypt(string strQueryString)
        {
            return DataEncryption.Encrypt(strQueryString, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
        }

        public static string decrypt(string decryptQueryString)
        {
            return DataEncryption.Decrypt(decryptQueryString, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
        }
    }
}
