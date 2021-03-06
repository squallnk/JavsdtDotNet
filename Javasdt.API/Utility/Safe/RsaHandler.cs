using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Javasdt.API.Utility.Safe
{
    public class RsaHandler
    {
        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="privateKeyXml"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RSADecrypt(string content, string privateKeyXml)
        {
            try
            {
                using RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(privateKeyXml);
                byte[] cipherbytes = rsa.Decrypt(Convert.FromBase64String(content), false);
                return Encoding.UTF8.GetString(cipherbytes);
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }

        public static bool IsValidClient(string content, string identityServer, string privateKeyXml)
        {
            return RSADecrypt(content, privateKeyXml) == identityServer;
        }
    }
}
