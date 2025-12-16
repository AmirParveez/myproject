using System;
using System.Text;
using System.Security.Cryptography;

namespace api.Helpers
{
    public static class CryptoHelper
    {
        private static readonly byte[] Salt = Encoding.UTF8.GetBytes("Ivan Medvedev");

        private static byte[] GetUtf16Bytes(string text)
        {
            return Encoding.Unicode.GetBytes(text);
        }

        private static byte[] DeriveBytes(string password, int size)
        {
            using (var sha1 = SHA1.Create())
            {
                byte[] data = GetUtf16Bytes(password);
                byte[] combined = new byte[data.Length + Salt.Length];

                Buffer.BlockCopy(data, 0, combined, 0, data.Length);
                Buffer.BlockCopy(Salt, 0, combined, data.Length, Salt.Length);

                byte[] derived = sha1.ComputeHash(combined);

                while (derived.Length < size)
                {
                    derived = sha1.ComputeHash(derived);
                }

                if (derived.Length > size)
                {
                    byte[] trimmed = new byte[size];
                    Buffer.BlockCopy(derived, 0, trimmed, 0, size);
                    derived = trimmed;
                }

                return derived;
            }
        }

        public static string Encrypt(string plainText, string password)
        {
            byte[] key = DeriveBytes(password, 32);
            byte[] iv = DeriveBytes(password, 16);
            byte[] plaintextBytes = GetUtf16Bytes(plainText);

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = key;
                aes.IV = iv;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    byte[] encrypted = encryptor.TransformFinalBlock(plaintextBytes, 0, plaintextBytes.Length);
                    return Convert.ToBase64String(encrypted);
                }
            }
        }
    }
}
