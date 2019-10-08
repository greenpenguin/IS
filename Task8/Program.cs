namespace Task8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WorkWithFileClass workWithFileClass = new WorkWithFileClass();
            EncryptionClass encryptionClass = new EncryptionClass();
            
            var keyPairs = encryptionClass.CreateKeyPairs(workWithFileClass.ReadAlphabetFile());
            
            var encryptedMessage =
                encryptionClass.Encryption(workWithFileClass.ReadFile(), keyPairs);
            
            var decryptedMessage = 
                encryptionClass.Decryption(encryptedMessage, keyPairs);

            workWithFileClass.OutputResultToFile(encryptedMessage, decryptedMessage);
        }
    }
}