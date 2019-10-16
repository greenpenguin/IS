using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task10
{
    public class WorkWithFileClass
    {
        public string ReadFile()
        {
            string inputFilePath = Directory.GetCurrentDirectory() + "/input.txt";

            using (StreamReader reader = new StreamReader(inputFilePath, Encoding.Default))
            {
                string outputStr = reader.ReadToEnd();
                StringBuilder outputStringBuilder = new StringBuilder();

                foreach (var elem in outputStr)
                {
                    outputStringBuilder.Append(char.ToUpper(elem));
                }
                return outputStringBuilder.ToString();
            }
        }
        
        public void OutputResultToFile(StringBuilder encryptedMessage, StringBuilder decryptedMessage)
        {
            string outputFilePath = Directory.GetCurrentDirectory() + "/output.txt";

            File.WriteAllText(outputFilePath, String.Empty);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                string encryptedMessageForOutput = encryptedMessage.ToString();
                writer.WriteLine("Encrypted message:");
                foreach (var elem in encryptedMessageForOutput)
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