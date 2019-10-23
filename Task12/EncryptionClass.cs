using System;
using System.Collections.Generic;
using System.Text;

namespace Task12
{
    public class EncryptionClass
    {
        private char Xor(char firstBit, char secondBit)
        {
            if (((firstBit == '0') && (secondBit == '0')) || ((firstBit == '1') && (secondBit == '1')))
            {
                return '0';
            }
            else
            {
                return '1';
            }
        }
        
        public List<string> Encryption(string messageForEncryption, string keyWord, Dictionary<int, string> binaryCodeOfAlphabet, 
            Dictionary<int, char> decimalCodeAndLetterOfAlphabet)
        {
            List<string> binaryCodeOfMessage = new List<string>();
            foreach (var elem in messageForEncryption)
            {
                int elemId = -1;
                foreach (var decimalCode in decimalCodeAndLetterOfAlphabet)
                {
                    if (decimalCode.Value == elem)
                    {
                        elemId = decimalCode.Key;
                    }
                }

                foreach (var binaryCode in binaryCodeOfAlphabet)
                {
                    if (binaryCode.Key == elemId)
                    {
                        binaryCodeOfMessage.Add(binaryCode.Value);
                    }
                }
            }
            
            StringBuilder binaryCodeOfMessageInOneLine = new StringBuilder();
            foreach (var elem in binaryCodeOfMessage)
            {
                binaryCodeOfMessageInOneLine.Append(elem);
            }
            
            RegisterClass registerClass = new RegisterClass();
            var binaryCodeOfKeyWord = registerClass.Register(keyWord, binaryCodeOfMessageInOneLine.Length, binaryCodeOfAlphabet,
                decimalCodeAndLetterOfAlphabet);
            
            List<string> result = new List<string>();

            for (int i = 0; i < binaryCodeOfMessage.Count; i++)
            {
                StringBuilder strForAdding = new StringBuilder();
                for (int j = 0; j < binaryCodeOfMessage[i].Length; j++)
                {
                    strForAdding.Append(Xor(binaryCodeOfMessage[i][j], binaryCodeOfKeyWord[i]));
                }
                
                result.Add(strForAdding.ToString());
            }
            
            return result;
        }

        public StringBuilder Decryption(List<string> messageForDecryption, string keyWord, Dictionary<int, string> binaryCodeOfAlphabet, 
            Dictionary<int, char> decimalCodeAndLetterOfAlphabet)
        {
            StringBuilder binaryCodeOfMessageInOneLine = new StringBuilder();
            foreach (var elem in messageForDecryption)
            {
                binaryCodeOfMessageInOneLine.Append(elem);
            }
            
            RegisterClass registerClass = new RegisterClass();
            var binaryCodeOfKeyWord = registerClass.Register(keyWord, binaryCodeOfMessageInOneLine.Length, binaryCodeOfAlphabet,
                decimalCodeAndLetterOfAlphabet);
            
            List<string> codeOfMessage = new List<string>();

            for (int i = 0; i < messageForDecryption.Count; i++)
            {
                StringBuilder strForAdding = new StringBuilder();
                for (int j = 0; j < messageForDecryption[i].Length; j++)
                {
                    strForAdding.Append(Xor(messageForDecryption[i][j], binaryCodeOfKeyWord[i]));
                }
                
                codeOfMessage.Add(strForAdding.ToString());
            }
            
            StringBuilder result = new StringBuilder();

            foreach (var elem in codeOfMessage)
            {
                int elemId = -1;
                
                foreach (var binaryCode in binaryCodeOfAlphabet)
                {
                    if (binaryCode.Value == elem)
                    {
                        elemId = binaryCode.Key;
                    }
                }
                
                foreach (var decimalCode in decimalCodeAndLetterOfAlphabet)
                {
                    if (decimalCode.Key == elemId)
                    {
                        result.Append(decimalCode.Value);
                    }
                }
            }
            
            return result;
        }
    }
}