using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task4
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
        
        public char[,] CreateMatrixOfKeys()
        {
            string alphabetFilePath = Directory.GetCurrentDirectory() + "/alphabet.txt";
            
            using (StreamReader reader = new StreamReader(alphabetFilePath, Encoding.Default))
            {
                char[,] matrixOfKeys = new char[10, 10];
                for (int i = 0; i < matrixOfKeys.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixOfKeys.GetLength(1); j++)
                    {
                        matrixOfKeys[i, j] = (char)reader.Read();
                        
                    }
                }
                /*Console.WriteLine(matrixOfKeys.Length);
                for (int i = 0; i < matrixOfKeys.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixOfKeys.GetLength(1); j++)
                    {
                        Console.Write(matrixOfKeys[i, j] + "|");
                        
                    }
                    Console.WriteLine();
                }*/
                return matrixOfKeys;
            }
        }

        public void OutputResultToFile(List<int> encryptedMessage, StringBuilder decryptedMessage)
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