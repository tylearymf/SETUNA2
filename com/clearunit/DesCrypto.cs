namespace com.clearunit
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    internal class DesCrypto
    {
        private static byte[] Crypto(byte[] target, byte[] key, byte[] iv, CryptoMode mode)
        {
            byte[] buffer;
            try
            {
                ICryptoTransform transform;
                TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
                MemoryStream stream = new MemoryStream();
                if (mode == CryptoMode.Encrypt)
                {
                    transform = provider.CreateEncryptor(key, iv);
                }
                else
                {
                    transform = provider.CreateDecryptor(key, iv);
                }
                CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
                stream2.Write(target, 0, target.Length);
                stream2.Close();
                buffer = stream.ToArray();
                stream.Close();
            }
            catch
            {
                buffer = new byte[1];
            }
            return buffer;
        }

        public static byte[] DesDecrypto(byte[] target, byte[] key, byte[] iv) => 
            Crypto(target, key, iv, CryptoMode.Decrypt);

        public static byte[] DesEncrypto(string target, byte[] key, byte[] iv) => 
            Crypto(Encoding.Unicode.GetBytes(target), key, iv, CryptoMode.Encrypt);

        public enum CryptoMode
        {
            Encrypt,
            Decrypt
        }
    }
}

