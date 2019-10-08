using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task8
{
    public class EncryptionClass
    {
        public Dictionary<char, char> CreateKeyPairs(string inputStr)
        {
            StringBuilder firstPartOfString = new StringBuilder();
            StringBuilder secondPartOfString = new StringBuilder();

            for (int i = 0; i < inputStr.Length/2; i++)
            {
                firstPartOfString.Append(inputStr[i]);
            }
            
            for (int i = inputStr.Length/2; i < inputStr.Length; i++)
            {
                secondPartOfString.Append(inputStr[i]);
            }
            
            Dictionary<char, char> keyPairs = new Dictionary<char, char>();
            for (int i = 0; i < inputStr.Length/2; i++)
            {
                keyPairs.Add(firstPartOfString[i], secondPartOfString[i]);
            }

            return keyPairs;
        }
        
        public List<char> Encryption(string messageForEncryption, Dictionary<char, char> keyPairs)
        {
            List<char> codeOfMessage = new List<char>();
            
            for (int i = 0; i < messageForEncryption.Length; i++)
            {
                if (keyPairs.ContainsKey(messageForEncryption[i]))
                {
                    codeOfMessage.Add(keyPairs[messageForEncryption[i]]);
                }
                else
                {
                    codeOfMessage.Add(keyPairs.FirstOrDefault(x => x.Value == messageForEncryption[i]).Key);
                }
            }
            
            return codeOfMessage;
        }

        public StringBuilder Decryption(List<char> messageForDecryption, Dictionary<char, char> keyPairs)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < messageForDecryption.Count; i++)
            {
                if (keyPairs.ContainsKey(messageForDecryption[i]))
                {
                    result.Append(keyPairs[messageForDecryption[i]]);
                }
                else
                {
                    result.Append(keyPairs.FirstOrDefault(x => x.Value == messageForDecryption[i]).Key);
                }
            }
            return result;
        }
    }
}