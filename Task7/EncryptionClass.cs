using System;
using System.Collections.Generic;
using System.Text;

namespace Task7
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

        private int ModuloAddition(int messageCharNum, int keyCharNum, int mod)
        {
            return (messageCharNum + keyCharNum) % mod;
        }

        private int ModuloSubtraction(int keyCharNum, int cipherCharNum, int mod)
        {
            return cipherCharNum - keyCharNum < 0 ? cipherCharNum - keyCharNum + mod : cipherCharNum - keyCharNum;
        }
        
        public List<char> Encryption(string messageForEncryption, string keyWord,
            Dictionary<int, char> alphabetCodes, int alphabetLength)
        {
            string keyWordWithEqualLength = MakeKeywordLengthEqualToMessageLength(messageForEncryption.Length, keyWord);
            List<int> codeOfKeyWord = new List<int>();
            foreach (var elem in keyWordWithEqualLength)
            {
                foreach (var decimalCode in alphabetCodes)
                {
                    if (decimalCode.Value == elem)
                    {
                        codeOfKeyWord.Add(decimalCode.Key);
                    }
                }
            }
            
            List<int> newCodes = new List<int>();

            for (int i = 0; i < messageForEncryption.Length; i++)
            {
                int code = -1;
                foreach (var numCode in alphabetCodes)
                {
                    
                    if (numCode.Value == messageForEncryption[i])
                    {
                        code = numCode.Key;
                        //Console.WriteLine(code);
                    }
                }
                newCodes.Add(ModuloAddition(code, codeOfKeyWord[i], alphabetLength));
            }

            List<char> result = new List<char>();
            foreach (var elem in newCodes)
            {
                foreach (var numCode in alphabetCodes)
                {
                    if (numCode.Key == elem)
                    {
                        result.Add(numCode.Value);
                    }
                }
            }
            
            return result;
        }

        public StringBuilder Decryption(List<char> messageForDecryption, string keyWord,
            Dictionary<int, char> alphabetCodes, int alphabetLength)
        {
            string keyWordWithEqualLength = MakeKeywordLengthEqualToMessageLength(messageForDecryption.Count, keyWord);

            List<int> codeOfKeyWord = new List<int>();
            foreach (var elem in keyWordWithEqualLength)
            {
                foreach (var decimalCode in alphabetCodes)
                {
                    if (decimalCode.Value == elem)
                    {
                        codeOfKeyWord.Add(decimalCode.Key);
                    }
                }
            }
            
            List<int> newCodes = new List<int>();

            for (int i = 0; i < messageForDecryption.Count; i++)
            {
                int code = -1;
                foreach (var numCode in alphabetCodes)
                {
                    if (numCode.Value == messageForDecryption[i])
                    {
                        code = numCode.Key;
                    }
                }
                newCodes.Add(ModuloSubtraction(codeOfKeyWord[i], code, alphabetLength));
            }

            //List<char> result = new List<char>();
            StringBuilder result = new StringBuilder();
            foreach (var elem in newCodes)
            {
                foreach (var numCode in alphabetCodes)
                {
                    if (numCode.Key == elem)
                    {
                        result.Append(numCode.Value);
                    }
                }
            }
            
            return result;
        }
    }
}