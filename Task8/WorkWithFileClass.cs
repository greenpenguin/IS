using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task8
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
        
        public string ReadAlphabetFile()
        {
            string inputFilePath = Directory.GetCurrentDirectory() + "/alphabet.txt";
            
            using (StreamReader reader = new StreamReader(inputFilePath, Encoding.Default))
            {
                return reader.ReadToEnd();
            }
        }
        
        public void OutputResultToFile(List<char> encryptedMessage, StringBuilder decryptedMessage)
        {
            string outputFilePath = Directory.GetCurrentDirectory() + "/output.txt";

            File.WriteAllText(outputFilePath, String.Empty);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine("Encrypted message:");
                foreach (var elem in encryptedMessage)
                {
                    writer.Write(elem + " ");
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