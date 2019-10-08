using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task6
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

        public char[,] CreateVigenereTableFromFile()
        {
            string vigenereTableFilePath = Directory.GetCurrentDirectory() + "/VigenereTable.txt";
            char[,] vigenereTableInMatrix = new char[33, 33];
            using (StreamReader reader = new StreamReader(vigenereTableFilePath, Encoding.Default))
            {
                for (int i = 0; i < vigenereTableInMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < vigenereTableInMatrix.GetLength(1); j++)
                    {
                        vigenereTableInMatrix[i, j] = (char) reader.Read();
                    }
                }
            }
            
            return vigenereTableInMatrix;
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