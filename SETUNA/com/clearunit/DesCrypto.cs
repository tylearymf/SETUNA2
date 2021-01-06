using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace com.clearunit
{
    // Token: 0x02000029 RID: 41
    internal class DesCrypto
    {
        // Token: 0x060001A1 RID: 417 RVA: 0x00009936 File Offset: 0x00007B36
        public static byte[] DesEncrypto(string target, byte[] key, byte[] iv)
        {
            return DesCrypto.Crypto(Encoding.Unicode.GetBytes(target), key, iv, DesCrypto.CryptoMode.Encrypt);
        }

        // Token: 0x060001A2 RID: 418 RVA: 0x0000994B File Offset: 0x00007B4B
        public static byte[] DesDecrypto(byte[] target, byte[] key, byte[] iv)
        {
            return DesCrypto.Crypto(target, key, iv, DesCrypto.CryptoMode.Decrypt);
        }

        // Token: 0x060001A3 RID: 419 RVA: 0x00009958 File Offset: 0x00007B58
        private static byte[] Crypto(byte[] target, byte[] key, byte[] iv, DesCrypto.CryptoMode mode)
        {
            byte[] result;
            try
            {
                var tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
                var memoryStream = new MemoryStream();
                ICryptoTransform transform;
                if (mode == DesCrypto.CryptoMode.Encrypt)
                {
                    transform = tripleDESCryptoServiceProvider.CreateEncryptor(key, iv);
                }
                else
                {
                    transform = tripleDESCryptoServiceProvider.CreateDecryptor(key, iv);
                }
                var cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
                cryptoStream.Write(target, 0, target.Length);
                cryptoStream.Close();
                result = memoryStream.ToArray();
                memoryStream.Close();
            }
            catch
            {
                var array = new byte[1];
                result = array;
            }
            return result;
        }

        // Token: 0x0200002A RID: 42
        public enum CryptoMode
        {
            // Token: 0x040000C5 RID: 197
            Encrypt,
            // Token: 0x040000C6 RID: 198
            Decrypt
        }
    }
}
