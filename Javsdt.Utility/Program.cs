using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Javsdt.Utility
{
    class Program
    {

        public static void ConvertPrivate(string privXmlFilename, string privPkcs8Filename)
        {
            StringBuilder sb = new StringBuilder();
            string line;
            var xmlIn = new StreamReader(privXmlFilename);
            while ((line = xmlIn.ReadLine()) != null)
            {
                sb.Append(line);
            }
            var xmlKey = sb.ToString();
            var rsa = RSA.Create();
            rsa.FromXmlString(xmlKey);
            var bcKeyPair = DotNetUtilities.GetRsaKeyPair(rsa);
            var pkcs8Gen = new Pkcs8Generator(bcKeyPair.Private);
            var pemObj = pkcs8Gen.Generate();
            var pkcs8Out = new StreamWriter(privPkcs8Filename, false);
            var pemWriter = new PemWriter(pkcs8Out);
            pemWriter.WriteObject(pemObj);
            pkcs8Out.Close();
        }
        public static void ConvertPublic(string pkcs1File, string privPkcs8Filename)
        {
            StreamReader reader = new StreamReader(pkcs1File);
            PemReader pemReader = new PemReader(reader);
            AsymmetricCipherKeyPair keyPair = (AsymmetricCipherKeyPair)pemReader.ReadObject();
            AsymmetricKeyParameter privateKey = keyPair.Private;
            RSA rsa = DotNetUtilities.ToRSA((RsaPrivateCrtKeyParameters)privateKey);
            string xmlRsa = rsa.ToXmlString(true);
            Console.WriteLine(xmlRsa); ;
        }

        public static void Main(string[] args)
        {
            var xmlFile = "2.xml";
            var pkcs8File = "privkey.pk8";
            ConvertPublic(xmlFile, pkcs8File);
        }

    }

}
