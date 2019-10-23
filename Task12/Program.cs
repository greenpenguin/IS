using System.Xml;

namespace Task12
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WorkWithFileClass workWithFileClass = new WorkWithFileClass();
            WorkWithConsoleClass workWithConsoleClass = new WorkWithConsoleClass();
            EncryptionClass encryptionClass = new EncryptionClass();

            var keyWord = workWithConsoleClass.InputKeyWordFromConsole();
            var inputStr = workWithFileClass.ReadFile();
            var binaryCodeOfAlphabet = workWithFileClass.GetBinaryCodeOfAlphabet();
            var decimalCodeAndLetterOfAlphabet = workWithFileClass.GetDecimalCodeAndLetterOfAlphabet();

            var encryptedMessage =
                encryptionClass.Encryption(inputStr, keyWord, binaryCodeOfAlphabet, decimalCodeAndLetterOfAlphabet);

            var decryptedMessage = encryptionClass.Decryption(encryptedMessage, keyWord, binaryCodeOfAlphabet,
                decimalCodeAndLetterOfAlphabet);
            workWithFileClass.OutputResultToFile(encryptedMessage, decryptedMessage);

        }
    }
}