using System;

namespace Task7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WorkWithConsole workWithConsole = new WorkWithConsole();
            WorkWithFileClass workWithFileClass = new WorkWithFileClass();
            EncryptionClass encryptionClass = new EncryptionClass();

            var inputMessage = workWithFileClass.ReadFile();

            int alphabetLength = workWithFileClass.GetAlphabetLength();

            var numCodeOfAlphabet = workWithFileClass.GetNumCodeOfAlphabet();

            var keyWord = workWithConsole.InputKeyWordFromConsole();
            //Console.Write(encryptionClass.ModuloAddition(18, 20, 32) + " " + encryptionClass.ModuloSubtraction(20, 6, 32));
            var encryptedMessage = encryptionClass.Encryption(inputMessage, keyWord, numCodeOfAlphabet, alphabetLength);
            var decryptedMessage = encryptionClass.Decryption(encryptedMessage, keyWord, numCodeOfAlphabet, alphabetLength);
            
            workWithFileClass.OutputResultToFile(encryptedMessage, decryptedMessage);
        }
    }
}