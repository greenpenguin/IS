using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task2
{
    public class WorkWithFileClass
    {
        Dictionary<char, double> _charCount = new Dictionary<char, double>();
        private int _numOfChar = 0;
        
        public void ReadFile(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            string[] strFromFile = reader.ReadToEnd().Split(' ');

            foreach (var str in strFromFile)
            {
                foreach (var elem in str)
                {
                    if ((elem > 'А') && (elem < 'я'))
                    {
                        char thisChar = char.ToUpper(elem);
                        
                        if (!_charCount.ContainsKey(thisChar))
                        {
                            _charCount.Add(thisChar, 1);
                        }
                        else
                        {
                            _charCount[thisChar]++;
                        }

                        _numOfChar++;
                    }
                }
            }
            
            reader.Close();

        }

        public void WriteTableToFile(string filePath)
        {
            StreamWriter writer = new StreamWriter(filePath);

            foreach (var pair in _charCount.OrderBy(pair => pair.Value))
            {
                writer.WriteLine(pair.Key + "    |    {0:0.###}", pair.Value / _numOfChar);
            }
            
            writer.Close();
        }
    }
}