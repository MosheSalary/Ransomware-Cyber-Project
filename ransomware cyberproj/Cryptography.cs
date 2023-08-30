using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ransomware_cyberproj
{
    // Init all the project
    public class AesCrypter
    {
        public Tuple<byte[], byte[]> KeyAndIv; // This tuple holds the encryption key and initialization vector (IV).
        AesManaged myAes; // The AES encryption algorithm instance.
        ICryptoTransform encryptor; // The encryptor transform.
        ICryptoTransform decryptor; // The decryptor transform.

        public AesCrypter(Tuple<byte[], byte[]> KeyAndIv)
        {
            // Initialize the AES algorithm instance with the provided key and IV.
            myAes = new AesManaged();
            myAes.Key = KeyAndIv.Item1;
            myAes.IV = KeyAndIv.Item2;

            // Create encryptor and decryptor transforms for later use.
            encryptor = myAes.CreateEncryptor(KeyAndIv.Item1, KeyAndIv.Item2);
            decryptor = myAes.CreateDecryptor(KeyAndIv.Item1, KeyAndIv.Item2);
        }

        // Encrypts a stream of data using the AES algorithm.
        public Stream Encrypt(Stream s)
        {
            CryptoStream cryptoStream = new CryptoStream(s, encryptor, CryptoStreamMode.Read);

            return cryptoStream;
        }

        // Encrypts a byte array using the AES algorithm.
        public byte[] Encrypt(byte[] inputBytes)
        {
            using (MemoryStream input = new MemoryStream(inputBytes))
            using (CryptoStream cryptoStream = new CryptoStream(input, encryptor, CryptoStreamMode.Read))
            using (MemoryStream output = new MemoryStream())
            {
                cryptoStream.CopyTo(output);
                return output.ToArray(); // Returns the encrypted byte array.
            }
        }

        // Decrypts a stream of data using the AES algorithm.
        public Stream Decrypt(Stream s)
        {
            CryptoStream cryptoStream = new CryptoStream(s, decryptor, CryptoStreamMode.Read);

            return cryptoStream;
        }

        // Decrypts a byte array using the AES algorithm.
        public byte[] Decrypt(byte[] inputBytes)
        {
            using (MemoryStream input = new MemoryStream(inputBytes))
            using (CryptoStream cryptoStream = new CryptoStream(input, decryptor, CryptoStreamMode.Read))
            using (MemoryStream output = new MemoryStream())
            {
                cryptoStream.CopyTo(output);
                return output.ToArray(); // Returns the decrypted byte array.
            }
        }

        // Generates a new random encryption key and IV.
        static public Tuple<byte[], byte[]> GenerateNewKeyAndIV()
        {
            using (AesManaged myAse = new AesManaged())
            {
                Tuple<byte[], byte[]> keyAndIv;
                myAse.GenerateKey(); // Generates a random encryption key.
                myAse.GenerateIV(); // Generates a random initialization vector.
                keyAndIv = Tuple.Create<byte[], byte[]>(myAse.Key, myAse.IV);
                return keyAndIv; // Returns the new key and IV as a tuple.
            }
        }
    }
}
