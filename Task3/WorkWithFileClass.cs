using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task3
{
    public class WorkWithFileClass
    {
        Dictionary<string, double> _charPairCount = new Dictionary<string, double>();
        private double _numOfChar = 0;
        
        public void ReadFile(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            string[] strFromFile = reader.ReadToEnd().Split(' ');

            foreach (var str in strFromFile)
            {
                    for (int i = 0; i < str.Length-1; i++)
                {
                    if (IsRusLetter(str[i]) && IsRusLetter(str[i+1]))
                    {
                        string thisPair = $"{char.ToUpper(str[i])}{char.ToUpper(str[i + 1])}"; 
                        if (!_charPairCount.ContainsKey(thisPair))
                        {
                            _charPairCount.Add(thisPair, 1);
                        }
                        else
                        {
                            _charPairCount[thisPair]++;
                        }

                        _numOfChar++;
                    }
                }
            }
            
            reader.Close();

        }

        public bool IsRusLetter(char letter)
        {
            if ((letter > 'А') && (letter < 'я'))
            {
                return true;
            }

            return false;
        }

        public void WriteTableToFile(string filePath)
        {
            StreamWriter writer = new StreamWriter(filePath);

            foreach (var pair in _charPairCount.OrderBy(pair => pair.Value))
            {
                writer.WriteLine(pair.Key + "    |    {0:0.####}", pair.Value / _numOfChar);
            }
            
            writer.Close();
        }
    }
}