namespace Task13
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WorkWithConsoleClass workWithConsoleClass = new WorkWithConsoleClass();
            WorkWithFileClass workWithFileClass = new WorkWithFileClass();
            EncryptionClass encryptionClass = new EncryptionClass();
            CongruentialGeneratorClass congruentialGeneratorClass = new CongruentialGeneratorClass();

            int a = workWithConsoleClass.InputA();
            int c = workWithConsoleClass.InputC();
            int startValue = workWithConsoleClass.InputStartValue();
            int m = workWithConsoleClass.InputM();

            var inputFile = workWithFileClass.ReadFile();
            var keyWord = congruentialGeneratorClass.CongruentialGenerator(a, c, m, startValue, inputFile.Length);
            var binaryCodeOfAlphabet = workWithFileClass.GetBinaryCodeOfAlphabet();
            var decimalCodeAndLetterOfAlphabet = workWithFileClass.GetDecimalCodeAndLetterOfAlphabet();
            
            var encryptedMessage =
                encryptionClass.Encryption(inputFile, keyWord, binaryCodeOfAlphabet, decimalCodeAndLetterOfAlphabet);

            var decryptedMessage = encryptionClass.Decryption(encryptedMessage, keyWord, binaryCodeOfAlphabet,
                decimalCodeAndLetterOfAlphabet);
            workWithFileClass.OutputResultToFile(encryptedMessage, decryptedMessage);
        }
    }
}