using System;
using System.Collections.Generic;
using System.Text;

namespace Task12
{
    public class RegisterClass
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

        public string Register(string inputString, int lengthOfMessage, Dictionary<int, string> binaryCodeOfAlphabet, 
            Dictionary<int, char> decimalCodeAndLetterOfAlphabet)
        {
            // перевод введенного ключа в двоичный код
            List<string> binaryCodeOfInputString = new List<string>();
            foreach (var elem in inputString)
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
                        binaryCodeOfInputString.Add(binaryCode.Value);
                    }
                }
            }

            /*foreach (var elem in binaryCodeOfInputString)
            {
                Console.Write(elem);
            }
            Console.WriteLine();*/
            
            // создание единой строки из полученного листа
            StringBuilder outputStr = new StringBuilder();

            foreach (var elem in binaryCodeOfInputString)
            {
                outputStr.Append(elem);
            }

            // пока длина генерируемой строки меньше длины сообщения, которое будем шифровать,
            // производим регистровый сдвиг
            for (int i = 0; i < outputStr.ToString().Length; i++)
            {
                if (outputStr.ToString().Length < lengthOfMessage)
                {
                    outputStr.Append(Xor(outputStr.ToString()[i], 
                        outputStr.ToString()[outputStr.ToString().Length - 1]));
                }
            }
            /*foreach (var elem in outputStr.ToString())
            {
                Console.Write(elem);
            }*/

            return outputStr.ToString();
        }
    }
}