namespace Task1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WorkWithFileClass workWithFileClass = new WorkWithFileClass();
            WorkWithConsoleClass workWithConsoleClass = new WorkWithConsoleClass();
            EncryptionClass encryptionClass = new EncryptionClass();

            var inputMessage = workWithFileClass.ReadFile();

            int m = workWithFileClass.GetAlphabetLength();

            int n = workWithConsoleClass.ReadNFromConsole();

            while (encryptionClass.GCD(n, m) != 1)
            {
                n = workWithConsoleClass.ReadAnotherNFromConsole();
            }

            int k = workWithConsoleClass.ReadKFromConsole();

            var numCodeOfAlphabet = workWithFileClass.GetNumCodeOfAlphabet();

            var encryptedMessage = encryptionClass.Encryption(inputMessage, numCodeOfAlphabet, n, k, m);
            var decryptedMessage = encryptionClass.Decryption(encryptedMessage, numCodeOfAlphabet, k, n, m);
            
            workWithFileClass.OutputResultToFile(encryptedMessage, decryptedMessage);
        }
    }
}