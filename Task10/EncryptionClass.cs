using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task10
{
    public class EncryptionClass
    {
        public char[,] CreateEncryptionMatrix(string keyWord, string inputMessage)
        {
            int numOfString = inputMessage.Length / keyWord.Length;

            // нужна еще одна строка, если сообщение целиком не может быть
            // занесено в матрицу целиком
            if (inputMessage.Length % keyWord.Length != 0)
            {
                numOfString++;
            }
            
            // добавим еще строку для ключевого слова в первой строке
            numOfString++;
            
            char[,] encryptionFirstMatrix = new char[numOfString, keyWord.Length];

            // добавляем ключевое слово в первую строку начальной матрицы
            for (int k = 0; k < keyWord.Length; k++)
            {
                encryptionFirstMatrix[0, k] = keyWord[k];
            }
            
            // добавляем посимвольно сообщение в матрицу
            int im = 0;
            for (int i = 1; i < encryptionFirstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < encryptionFirstMatrix.GetLength(1); j++)
                {
                    for (; im < inputMessage.Length; )
                    {
                        encryptionFirstMatrix[i,j] = inputMessage[im];
                        im++;
                        break;
                    }
                }
            }
            
            // по столбцам разбиваем матрицу с сообщением в словарь, где
            // ключ - буква ключевого слова, значение - элементы столбца матрицы
            Dictionary<char, List<char>> columnsWithKeyChar = new Dictionary<char, List<char>>();
            for (int j = 0; j < encryptionFirstMatrix.GetLength(1); j++)
            {
                List<char> listForAdding = new List<char>();
                for (int i = 1; i < encryptionFirstMatrix.GetLength(0); i++)
                {
                    listForAdding.Add(encryptionFirstMatrix[i, j]);
                }
                columnsWithKeyChar.Add(encryptionFirstMatrix[0, j], listForAdding);
            }

            // создаем лист для отсортированного по алфавиту ключевого слова
            // заносим в него посимвольно отсортированные символы ключевого слова
            List<char> sortedKeyWordCharList = new List<char>();
            foreach (var elem in keyWord.OrderBy(pair => pair))
            {
                sortedKeyWordCharList.Add(elem);
            }
            
            // создаем матрицу для шифрования, убираем из нее одну строку, чтобы убрать ключевое слово в первой строке
            numOfString--;
            char[,] encryptionSecondMatrix = new char[numOfString, keyWord.Length];
            
            //заполняем эту матрицу в соответствии с алфавитным порядком ключевого слова
            int columnId = 0;
            foreach (var sortedElem in sortedKeyWordCharList)
            {
                foreach (var elem in columnsWithKeyChar)
                {
                    if (elem.Key == sortedElem)
                    {
                        int elemListId = 0;
                        
                        for (; columnId < encryptionSecondMatrix.GetLength(1); )
                        {
                            int i = 0;
                            for (; i < encryptionSecondMatrix.GetLength(0); )
                            {
                                for (; elemListId < elem.Value.Count; )
                                {
                                    encryptionSecondMatrix[i,columnId] = elem.Value[elemListId];
                                    elemListId++;
                                    break;
                                }

                                i++;
                                
                            }

                            columnId++;
                            break;
                        }
                    }
                }
            }
            
            return encryptionSecondMatrix;

        }
        
        public StringBuilder Encryption(char[,] encryptionMatrix)
        {
            StringBuilder result = new StringBuilder();
            
            for (int i = 0; i < encryptionMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < encryptionMatrix.GetLength(1); j++)
                {
                    result.Append(encryptionMatrix[i, j]);
                }
            }
            
            return result;
        }

        public char[,] CreateDecryptionMatrix(string keyWord, string inputMessage)
        {
            int numOfString = inputMessage.Length / keyWord.Length;

            // нужна еще одна строка, если сообщение целиком не может быть
            // занесено в матрицу целиком
            if (inputMessage.Length % keyWord.Length != 0)
            {
                numOfString++;
            }
            
            // добавим еще строку для ключевого слова в первой строке
            numOfString++;
            
            char[,] encryptionFirstMatrix = new char[numOfString, keyWord.Length];

            // создаем лист для отсортированного по алфавиту ключевого слова
            // заносим в него посимвольно отсортированные символы ключевого слова
            List<char> sortedKeyWordCharList = new List<char>();
            foreach (var elem in keyWord.OrderBy(pair => pair))
            {
                sortedKeyWordCharList.Add(elem);
            }
            
            // добавляем ключевое слово в первую строку начальной матрицы
            for (int k = 0; k < sortedKeyWordCharList.Count; k++)
            {
                encryptionFirstMatrix[0, k] = sortedKeyWordCharList[k];
            }
            
            // добавляем посимвольно сообщение в матрицу
            int im = 0;
            for (int i = 1; i < encryptionFirstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < encryptionFirstMatrix.GetLength(1); j++)
                {
                    for (; im < inputMessage.Length; )
                    {
                        encryptionFirstMatrix[i,j] = inputMessage[im];
                        im++;
                        break;
                    }
                }
            }
            
            // по столбцам разбиваем матрицу с сообщением в словарь, где
            // ключ - буква ключевого слова, значение - элементы столбца матрицы
            Dictionary<char, List<char>> columnsWithKeyChar = new Dictionary<char, List<char>>();
            for (int j = 0; j < encryptionFirstMatrix.GetLength(1); j++)
            {
                List<char> listForAdding = new List<char>();
                for (int i = 1; i < encryptionFirstMatrix.GetLength(0); i++)
                {
                    listForAdding.Add(encryptionFirstMatrix[i, j]);
                }
                columnsWithKeyChar.Add(encryptionFirstMatrix[0, j], listForAdding);
            }

            // создаем матрицу для шифрования, убираем из нее одну строку, чтобы убрать ключевое слово в первой строке
            numOfString--;
            char[,] encryptionSecondMatrix = new char[numOfString, keyWord.Length];
            
            //заполняем эту матрицу в соответствии с изначальным порядком ключевого слова
            int columnId = 0;
            foreach (var elemOfKeyWord in keyWord)
            {
                foreach (var elem in columnsWithKeyChar)
                {
                    if (elem.Key == elemOfKeyWord)
                    {
                        int elemListId = 0;
                        
                        for (; columnId < encryptionSecondMatrix.GetLength(1); )
                        {
                            int i = 0;
                            for (; i < encryptionSecondMatrix.GetLength(0); )
                            {
                                for (; elemListId < elem.Value.Count; )
                                {
                                    encryptionSecondMatrix[i,columnId] = elem.Value[elemListId];
                                    elemListId++;
                                    break;
                                }

                                i++;
                                
                            }

                            columnId++;
                            break;
                        }
                    }
                }
            }
            
            return encryptionSecondMatrix;

        }
        
        public StringBuilder Decryption(char[,] decryptionMatrix)
        {
            StringBuilder result = new StringBuilder();
            
            for (int i = 0; i < decryptionMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < decryptionMatrix.GetLength(1); j++)
                {
                    result.Append(decryptionMatrix[i, j]);
                }
            }
            
            return result;
        }
    }
}