using System;
using System.Collections.Generic;
using System.Text;

namespace Task6
{
    public class EncryptionClass
    {
        private string MakeKeywordLengthEqualToMessageLength(int messageLength, string keyWord)
        {
            int lengthDifference = messageLength / keyWord.Length;
                        
            StringBuilder keyWordStringBuilder = new StringBuilder();

            for (int i = 0; i < lengthDifference; i++)
            {
                keyWordStringBuilder.Append(keyWord);
            }
            foreach (var elem in keyWord)
            {
                if (keyWordStringBuilder.Length != messageLength)
                {
                    keyWordStringBuilder.Append(elem);
                    
                }
            }

            return keyWordStringBuilder.ToString();
        }
        
        public List<char> Encryption(string messageForEncryption, string keyWord, char[,] vigenereTableInMatrix)
        {
            List<char> codeOfMessage = new List<char>();

            keyWord = MakeKeywordLengthEqualToMessageLength(messageForEncryption.Length, keyWord);
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
            
            keyWord = MakeKeywordLengthEqualToMessageLength(messageForDecryption.Count, keyWord);
            
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