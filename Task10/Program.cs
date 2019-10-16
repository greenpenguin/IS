using System;
using System.Text;

namespace Task10
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WorkWithFileClass workWithFileClass = new WorkWithFileClass();
            WorkWithConsoleClass workWithConsoleClass = new WorkWithConsoleClass();
            EncryptionClass encryptionClass = new EncryptionClass();

            string keyWord = workWithConsoleClass.InputKeyWordFromConsole();
            var encryptionMatrix = encryptionClass.CreateEncryptionMatrix(keyWord,
                workWithFileClass.ReadFile());
            var encryptedString = encryptionClass.Encryption(encryptionMatrix);

            var decryptionMatrix = encryptionClass.CreateDecryptionMatrix(keyWord, encryptedString.ToString());
            var decryptedString = encryptionClass.Decryption(decryptionMatrix);
            workWithFileClass.OutputResultToFile(encryptedString, decryptedString);
        }
    }
}