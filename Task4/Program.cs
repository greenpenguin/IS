using System;
using System.IO;

namespace Task4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WorkWithFileClass workWithFileClass = new WorkWithFileClass();
            EncryptionClass encryptionClass = new EncryptionClass();

            var encryptedMessage =
                encryptionClass.Encryption(workWithFileClass.ReadFile(), workWithFileClass.CreateMatrixOfKeys());
            
            var decryptedMessage = 
                encryptionClass.Decryption(encryptedMessage, workWithFileClass.CreateMatrixOfKeys());

            workWithFileClass.OutputResultToFile(encryptedMessage, decryptedMessage);

            /*char[,] alfrus = workWithFileClass.CreateMatrixOfKeys();
            string message = workWithFileClass.ReadFile(inputFilePath);
            
            var code = encryptionClass.Encryption(message, alfrus);
            foreach (var item in code)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine(encryptionClass.Decryption(code, alfrus));*/
        }
    }
}