using System;
using System.Security.Cryptography;
using System.Text;

/*
 * SimpleCryto
 * By Peter Slade
 * Email: pete@sladehome.com
 * Web: http://www.sladehome.com
 *
 * THIS CODE IS PROVIDED WITHOUT ANY WARRANTY, AND WITHOUT ANY IMPLIED WARRANTIES
 * WITH REGARD TO MERCHANTABILITY OR FITNESS FOR A PARTICULAR PURPOSE.
 *
 * USE AT YOUR OWN RISK. YOU ASSUME ALL LIABILITIES!!!
 *
 */

namespace rozproszone_bazy_danych
    {

    /// 

    /// Simple Cryptographic Services
    /// 


    public class SimpleCrypto
        {

        /// 

        /// Default Constructor
        /// 

        public SimpleCrypto()
            {

            }

        /// 

        /// Generates a cryptographic Hash Key for the provided text data.
        /// Basically a digital fingerprint
        /// 

        /// text to hash
        /// Unique hash representing string
        public static String GetMD5Hash(String dataToHash)
            {
            String hexResult = "";
            string[] tabStringHex = new string[16];
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = Encoding.ASCII.GetBytes(dataToHash);
            byte[] result = md5.ComputeHash(data);
            for (int i = 0; i < result.Length; i++)
                {
                tabStringHex[i] = (result[i]).ToString("x");
                hexResult += tabStringHex[i];
                }
            return hexResult;
            }

        /// 

        /// Encrypts text with Triple DES encryption using the supplied key
        /// 

        /// The text to encrypt
        /// Key to use for encryption
        /// The encrypted string represented as base 64 text
        public static string EncryptTripleDES(string plaintext, string key)
            {
            TripleDESCryptoServiceProvider DES =
                         new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
            DES.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
            DES.Mode = CipherMode.ECB;
            ICryptoTransform DESEncrypt = DES.CreateEncryptor();
            byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(plaintext);
            return Convert.ToBase64String(
                     DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }

        /// 

        /// Decrypts supplied Triple DES encrypted text using the supplied key
        /// 

        /// Triple DES encrypted base64 text
        /// Decryption Key
        /// The decrypted string
        public static string DecryptTripleDES(string base64Text, string key)
            {
            TripleDESCryptoServiceProvider DES =
                                    new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
            DES.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
            DES.Mode = CipherMode.ECB;
            ICryptoTransform DESDecrypt = DES.CreateDecryptor();
            byte[] Buffer = Convert.FromBase64String(base64Text);
            return ASCIIEncoding.ASCII.GetString(
                    DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }

        } // class
    } // namespace