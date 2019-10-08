using System;
using System.Collections.Generic;
using System.Text;

namespace Task6
{
    public class EncryptionClass
    {
        private string MakeKeywordLengthEqualToMessageLength(string message, string keyWord)
        {
            int lengthDifference = message.Length / keyWord.Length;
                        
            StringBuilder keyWordStringBuilder = new StringBuilder(string.Concat(keyWord, lengthDifference));
            
            foreach (var elem in keyWord)
            {
                while (keyWordStringBuilder.Length != message.Length)
                {
                    keyWordStringBuilder.Append(elem);
                }
            }

            return keyWordStringBuilder.ToString();
        }
        
        public List<char> Encryption(string messageForEncryption, string keyWord, char[,] vigenereTableInMatrix)
        {
            List<char> codeOfMessage = new List<char>();

            keyWord = MakeKeywordLengthEqualToMessageLength(messageForEncryption, keyWord);
            
            for (int i = 0; i < messageForEncryption.Length; i++)
            {
                for (int m = 0; m < vigenereTableInMatrix.GetLength(0); m++)
                {
                    for (int k = 0; k < vigenereTableInMatrix.GetLength(1); k++)
                    {
                        if ((messageForEncryption[i] == vigenereTableInMatrix[m, 0]) &&
                            (keyWord[i] == vigenereTableInMatrix[0, k]))
                        {
                            codeOfMessage.Add(vigenereTableInMatrix[m, k]);
                        }
                    }
                }
            }

            return codeOfMessage;
        }

        public StringBuilder Decryption(List<char> messageForDecryption, string keyWord, char[,] vigenereTableInMatrix)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder messageForDecriptionStringBuilder = new StringBuilder();
            foreach (var elem in messageForDecryption)
            {
                messageForDecriptionStringBuilder.Append(elem);
            }
            
            keyWord = MakeKeywordLengthEqualToMessageLength(messageForDecriptionStringBuilder.ToString(), keyWord);
            
            for (int i = 0; i < messageForDecryption.Count; i++)
            {
                for (int m = 0; m < vigenereTableInMatrix.GetLength(0); m++)
                {
                    for (int k = 0; k < vigenereTableInMatrix.GetLength(1); k++)
                    {
                        if ((messageForDecryption[i] == vigenereTableInMatrix[m, k]) &&
                            (keyWord[i] == vigenereTableInMatrix[0, k]))
                        {
                            result.Append(vigenereTableInMatrix[m, 0]);
                        }
                    }
                }
            }
            
            return result;
        }
    }
}