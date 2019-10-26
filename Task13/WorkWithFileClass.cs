using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task13
{
    public class WorkWithFileClass
    {
        public string ReadFile()
        {
            string inputFilePath = Directory.GetCurrentDirectory() + "/input.txt";
            
            using (StreamReader reader = new StreamReader(inputFilePath, Encoding.Default))
            {
                return reader.ReadToEnd();
            }
        }
        
        public Dictionary<int, string> GetBinaryCodeOfAlphabet()
        {
            string inputFilePath = Directory.GetCurrentDirectory() + "/alphabet.txt";

            using (StreamReader reader = new StreamReader(inputFilePath, Encoding.Default))
            {
                string alphabet = reader.ReadToEnd();
                Dictionary<int, string> output = new Dictionary<int, string>();

                for (int i = 0; i < alphabet.Length; i++)
                {
                    StringBuilder code = new StringBuilder(Convert.ToString(i, 2));
                    while (code.Length != 7)
                    {
                        code = code.Insert(0, "0");
                    }
                    output.Add(i, code.ToString());
                }
                
                return output;
            }
        }
        
        public Dictionary<int, char> GetDecimalCodeAndLetterOfAlphabet()
        {
            string inputFilePath = Directory.GetCurrentDirectory() + "/alphabet.txt";

            using (StreamReader reader = new StreamReader(inputFilePath, Encoding.Default))
            {
                string alphabet = reader.ReadToEnd();
                Dictionary<int, char> output = new Dictionary<int, char>();

                for (int i = 0; i < alphabet.Length; i++)
                {
                    output.Add(i, alphabet[i]);
                }
                
                return output;
            }
        }
        
        public void OutputResultToFile(List<string> encryptedMessage, StringBuilder decryptedMessage)
        {
            string outputFilePath = Directory.GetCurrentDirectory() + "/output.txt";

            File.WriteAllText(outputFilePath, String.Empty);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine("Encrypted message:");
                foreach (var elem in encryptedMessage)
                {
                    writer.Write(elem);
                }

                writer.WriteLine();
                string decryptedMessageForOutput = decryptedMessage.ToString();
                writer.WriteLine("Decrypted message:");
                foreach (var elem in decryptedMessageForOutput)
                {
                    writer.Write(elem);
                }
            }

        }
    }
}