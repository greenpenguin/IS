namespace Task6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WorkWithFileClass workWithFileClass = new WorkWithFileClass();
            WorkWithConsole workWithConsole = new WorkWithConsole();
            EncryptionClass encryptionClass = new EncryptionClass();

            var keyWord = workWithConsole.InputKeyWordFromConsole();
            
            var encryptedMessage =
                encryptionClass.Encryption(workWithFileClass.ReadFile(), keyWord, workWithFileClass.CreateVigenereTableFromFile());
            
            var decryptedMessage = 
                encryptionClass.Decryption(encryptedMessage, keyWord, workWithFileClass.CreateVigenereTableFromFile());

            workWithFileClass.OutputResultToFile(encryptedMessage, decryptedMessage);
        }
    }
}