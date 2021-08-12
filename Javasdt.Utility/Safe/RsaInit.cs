using System;
using System.Security.Cryptography;

namespace Javasdt.Utility.Safe
{
    public class RsaInit
    {
        public void New()
        {
            RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
            string PublicKey = rSACryptoServiceProvider.ToXmlString(false); // 获取公匙，用于加密
            Console.WriteLine(PublicKey);

            string PrivateKey = rSACryptoServiceProvider.ToXmlString(true); // 获取公匙和私匙，用于解密
            Console.WriteLine(PrivateKey);
        }
    }
}
