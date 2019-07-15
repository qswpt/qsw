using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common.Utils
{
    public static class CryptoUtil
    {
        private const string TEXT = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private const string EXPONENT = "010001";
        private const string MODULUS = "BECA095A9D6509E1E78AA35D7198D95DF8B308CDA5E0D202E27452D56C312A5DB35CD62E159CD1A5CDD614316495F514947AD64AE7D0FD357958E7A66DBAA4DBAA005AF246C07E992FB4C988E5751328B6D2359CB99C38CDEC45AEBD36D9210F3517C577ECDA31A48F36D46F8A872C55623DFC2C905988D6BF84BCD0D0D7A33B";
        private const string PUBLIC_KEY = "<RSAKeyValue><Modulus>vsoJWp1lCeHniqNdcZjZXfizCM2l4NIC4nRS1WwxKl2zXNYuFZzRpc3WFDFklfUUlHrWSufQ/TV5WOembbqk26oAWvJGwH6ZL7TJiOV1Eyi20jWcuZw4zexFrr022SEPNRfFd+zaMaSPNtRviocsVWI9/CyQWYjWv4S80NDXozs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        private const string PRIVATE_KEY = "<RSAKeyValue><Modulus>vsoJWp1lCeHniqNdcZjZXfizCM2l4NIC4nRS1WwxKl2zXNYuFZzRpc3WFDFklfUUlHrWSufQ/TV5WOembbqk26oAWvJGwH6ZL7TJiOV1Eyi20jWcuZw4zexFrr022SEPNRfFd+zaMaSPNtRviocsVWI9/CyQWYjWv4S80NDXozs=</Modulus><Exponent>AQAB</Exponent><P>+TwQmV0aLrDkl49BimCZMFrdSFJn9Hy6eR3WURhUtCub4WhYW0gBNfFVceAU1xc25YoyUZ2VZwbuBPX/EmGd3Q==</P><Q>w/fVZXxH65y150csuR6NTz0xkrzcBL/who46JDRB9aUk/OhZNwX1jWfeocO3NAd0gW1Xo+Rqmu4OFC/iqHPv9w==</Q><DP>hDqby+IbS/5JqSc17IaHf6IVmJMv2AR8oll0JR41gklIsHQ9vGAdVFMvs/Tg2aTVWT7Sp35lj32btkIVC9mCeQ==</DP><DQ>Nb4g6s0TmD0I8d1mGXqUfFem4bwjhrXwy6XzsfwW3rwkkatS1DExL09+EdTvyDgHLnuDHnJE/ios+EJNoa7x7w==</DQ><InverseQ>ES3xEJbhoihAqSaqpEVDWSkdQRmvdZ0R/U9eqJ/BH+h5T3+EVyk9V06xbeDrG+YzqGryYhjz5t1gkgRwfSzmVA==</InverseQ><D>c1imixg5a94eJF1cMz+buwqPAzWBogiWId797XY5y0lXFTuQJRToUvu8//xUuaywQox5XlQEr/FSagOzRQfgfriBa/t4FedBIva5AVMF4YzlwmnOuF5PXbX5sg38fS6mnZHXHczElxxtkQCKraFGiYwXLRpIHKxFdeZoHCgMHnE=</D></RSAKeyValue>";

        public static string SHA1(string text)
        {
            using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
            {
                byte[] bytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
                return Convert.ToBase64String(bytes);
            }
        }

        public static string SHA256(string text)
        {
            using (SHA256CryptoServiceProvider sha = new SHA256CryptoServiceProvider())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(text));
                return Convert.ToBase64String(bytes);
            }
        }

        public static string AesEncryptBase64(string text, string key)
        {
            using (RijndaelManaged rm = new RijndaelManaged())
            {
                rm.Key = Encoding.UTF8.GetBytes(key);
                rm.Mode = CipherMode.ECB;
                rm.Padding = PaddingMode.PKCS7;

                using (ICryptoTransform cTransform = rm.CreateEncryptor())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(text);
                    byte[] results = cTransform.TransformFinalBlock(bytes, 0, bytes.Length);

                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        public static string AesDecryptBase64(string text, string key)
        {
            try
            {
                using (RijndaelManaged rm = new RijndaelManaged())
                {
                    rm.Key = Encoding.UTF8.GetBytes(key);
                    rm.Mode = CipherMode.ECB;
                    rm.Padding = PaddingMode.PKCS7;

                    using (ICryptoTransform cTransform = rm.CreateDecryptor())
                    {
                        byte[] bytes = Convert.FromBase64String(text);
                        byte[] results = cTransform.TransformFinalBlock(bytes, 0, bytes.Length);

                        return Encoding.UTF8.GetString(results);
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public static string AesEncryptHex(string text, string key)
        {
            using (RijndaelManaged rm = new RijndaelManaged())
            {
                rm.Key = Encoding.UTF8.GetBytes(key);
                rm.Mode = CipherMode.ECB;
                rm.Padding = PaddingMode.PKCS7;

                using (ICryptoTransform cTransform = rm.CreateEncryptor())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(text);
                    byte[] results = cTransform.TransformFinalBlock(bytes, 0, bytes.Length);

                    return ConvertUtil.BytesToHexString(results);
                }
            }
        }

        public static string AesDecryptHex(string text, string key)
        {
            try
            {
                using (RijndaelManaged rm = new RijndaelManaged())
                {
                    rm.Key = Encoding.UTF8.GetBytes(key);
                    rm.Mode = CipherMode.ECB;
                    rm.Padding = PaddingMode.PKCS7;

                    using (ICryptoTransform cTransform = rm.CreateDecryptor())
                    {
                        byte[] bytes = ConvertUtil.HexStringToBytes(text);
                        byte[] results = cTransform.TransformFinalBlock(bytes, 0, bytes.Length);

                        return Encoding.UTF8.GetString(results);
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public static string RsaEncryptBase64(string text, string publicKey)
        {
            using (RSACryptoServiceProvider crypto = new RSACryptoServiceProvider(1024))
            {
                crypto.FromXmlString(publicKey);

                byte[] bytes = Encoding.UTF8.GetBytes(text);
                byte[] results = crypto.Encrypt(bytes, true);

                return Convert.ToBase64String(results);
            }
        }

        public static string RsaDecryptBase64(string text, string privateKey)
        {
            try
            {
                using (RSACryptoServiceProvider crypto = new RSACryptoServiceProvider(1024))
                {
                    crypto.FromXmlString(privateKey);

                    byte[] bytes = Convert.FromBase64String(text);
                    byte[] results = crypto.Decrypt(bytes, true);

                    return Encoding.UTF8.GetString(results);
                }
            }
            catch
            {
                return null;
            }
        }

        public static string RsaEncryptHex(string text, string publicKey)
        {
            using (RSACryptoServiceProvider crypto = new RSACryptoServiceProvider(1024))
            {
                crypto.FromXmlString(publicKey);

                byte[] bytes = Encoding.UTF8.GetBytes(text);
                byte[] results = crypto.Encrypt(bytes, true);

                return ConvertUtil.BytesToHexString(results);
            }
        }

        public static string RsaDecryptHex(string text, string privateKey)
        {
            try
            {
                using (RSACryptoServiceProvider crypto = new RSACryptoServiceProvider(1024))
                {
                    crypto.FromXmlString(privateKey);

                    byte[] bytes = ConvertUtil.HexStringToBytes(text);
                    byte[] results = crypto.Decrypt(bytes, true);

                    return Encoding.UTF8.GetString(results);
                }
            }
            catch
            {
                return null;
            }
        }

        public static string GetRandomNum(int length)
        {
            string text = "0123456789";

            Random r = new Random();
            StringBuilder stringBuilder = new StringBuilder(32);
            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append(text.Substring(r.Next(text.Length), 1));
            }

            return stringBuilder.ToString();
        }

        public static string GetRandomChar(int length)
        {
            Random r = new Random();
            StringBuilder stringBuilder = new StringBuilder(32);
            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append(TEXT.Substring(r.Next(TEXT.Length), 1));
            }

            return stringBuilder.ToString();
        }

        public static string GetRandomAesKey()
        {
            Random r = new Random();
            StringBuilder stringBuilder = new StringBuilder(32);
            for (int i = 0; i < 32; i++)
            {
                stringBuilder.Append(TEXT.Substring(r.Next(TEXT.Length), 1));
            }

            return stringBuilder.ToString();
        }

        public static string[] GetRandomRsaKey()
        {
            //var rsaProvider = new RSACryptoServiceProvider(1024);
            //RSAParameters parameter = rsaProvider.ExportParameters(true);
            //var x = ConvertUtil.BytesToHexString(parameter.Exponent);
            //var y = ConvertUtil.BytesToHexString(parameter.Modulus);
            //var z = rsaProvider.ToXmlString(false);
            //var zz = rsaProvider.ToXmlString(true);

            using (RSACryptoServiceProvider crypto = new RSACryptoServiceProvider(1024))
            {
                return new string[] { crypto.ToXmlString(false), crypto.ToXmlString(true) };
            }
        }
    }
}
