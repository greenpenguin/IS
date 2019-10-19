using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task9
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
        
        public List<string> Encryption(string messageForEncryption, string keyWord, Dictionary<int, string> binaryCodeOfAlphabet, 
            Dictionary<int, char> decimalCodeAndLetterOfAlphabet)
        {
            
            /*foreach (var elem in binaryCodeOfAlphabet)
            {
                Console.Write(elem + " ");
            }*/
            string keyWordWithMessageLength = MakeKeywordLengthEqualToMessageLength(messageForEncryption.Length, keyWord);
            List<string> binaryCodeOfKeyWord = new List<string>();
            foreach (var elem in keyWordWithMessageLength)
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
                        binaryCodeOfKeyWord.Add(binaryCode.Value);
                    }
                }
            }

            /*foreach (var elem in binaryCodeOfKeyWord)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();*/

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
            
            /*foreach (var elem in binaryCodeOfMessage)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();*/
            
            List<string> result = new List<string>();

            for (int i = 0; i < binaryCodeOfMessage.Count; i++)
            {
                StringBuilder strForAdding = new StringBuilder();
                for (int j = 0; j < binaryCodeOfMessage[i].Length; j++)
                {
                    if (binaryCodeOfMessage[i][j] == '0')
                    {
                        if (binaryCodeOfKeyWord[i][j] == '0')
                        {
                            strForAdding.Append('0');
                        }
                        else if (binaryCodeOfKeyWord[i][j] == '1')
                        {
                            strForAdding.Append('1');
                        }
                    }
                    else if (binaryCodeOfMessage[i][j] == '1')
                    {
                        if (binaryCodeOfKeyWord[i][j] == '0')
                        {
                            strForAdding.Append('1');
                        }
                        else if (binaryCodeOfKeyWord[i][j] == '1')
                        {
                            strForAdding.Append('0');
                        }
                    }
                }
                
                result.Add(strForAdding.ToString());
            }
            
            return result;
        }

        public StringBuilder Decryption(List<string> messageForDecryption, string keyWord, Dictionary<int, string> binaryCodeOfAlphabet, 
            Dictionary<int, char> decimalCodeAndLetterOfAlphabet)
        {
            string keyWordWithMessageLength = MakeKeywordLengthEqualToMessageLength(messageForDecryption.Count, keyWord);
            List<string> binaryCodeOfKeyWord = new List<string>();
            foreach (var elem in keyWordWithMessageLength)
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
                        binaryCodeOfKeyWord.Add(binaryCode.Value);
                    }
                }
            }

            /*foreach (var elem in binaryCodeOfKeyWord)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();*/

            /*List<string> binaryCodeOfMessage = new List<string>();
            foreach (var elem in messageForDecryption)
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
            }*/
            
            /*foreach (var elem in binaryCodeOfMessage)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();*/
            
            List<string> codeOfMessage = new List<string>();

            for (int i = 0; i < messageForDecryption.Count; i++)
            {
                StringBuilder strForAdding = new StringBuilder();
                for (int j = 0; j < messageForDecryption[i].Length; j++)
                {
                    if (messageForDecryption[i][j] == '0')
                    {
                        if (binaryCodeOfKeyWord[i][j] == '0')
                        {
                            strForAdding.Append('0');
                        }
                        else if (binaryCodeOfKeyWord[i][j] == '1')
                        {
                            strForAdding.Append('1');
                        }
                    }
                    else if (messageForDecryption[i][j] == '1')
                    {
                        if (binaryCodeOfKeyWord[i][j] == '0')
                        {
                            strForAdding.Append('1');
                        }
                        else if (binaryCodeOfKeyWord[i][j] == '1')
                        {
                            strForAdding.Append('0');
                        }
                    }
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