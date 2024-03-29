﻿using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class EncryptionClass
    {
        public int GCD(int n, int m)
        {
            int gcd = 0;
            for (int i = 1; i < (n * m + 1); i++)
            {
                if (m % i == 0 && n % i == 0)
                {
                    gcd = i;
                }
            }
            return gcd;
        }
        
        private int ToA(int B, int k, int n, int m)
        {
            int result = B - k;
            while (result % n != 0)
            {
                result += m;
            }
            return result / n;
        }

        private int ToB(int A, int n, int k, int m)
        {
            return (A * n + k) % m;
        }
        
        public List<char> Encryption(string messageForEncryption, Dictionary<int, char> numCodeOfAlphabet, int n, int k, int m)
        {
            List<int> newCodes = new List<int>();

            foreach (var elem in messageForEncryption)
            {
                int code = -1;
                foreach (var numCode in numCodeOfAlphabet)
                {
                    if (numCode.Value == elem)
                    {
                        code = numCode.Key;
                    }
                }
                newCodes.Add(ToB(code, n, k, m));
            }

            List<char> result = new List<char>();
            foreach (var elem in newCodes)
            {
                foreach (var numCode in numCodeOfAlphabet)
                {
                    if (numCode.Key == elem)
                    {
                        result.Add(numCode.Value);
                    }
                }
            }
            
            return result;
        }

        public StringBuilder Decryption(List<char> messageForDecryption, Dictionary<int, char> numCodeOfAlphabet, int k, int n, int m)
        {
            StringBuilder result = new StringBuilder();
            
            List<int> codeOfMessageForDecryption = new List<int>();
            foreach (var elem in messageForDecryption)
            {
                foreach (var numCode in numCodeOfAlphabet)
                {
                    if (numCode.Value == elem)
                    {
                        codeOfMessageForDecryption.Add(numCode.Key);
                    }
                }
            }
            
            foreach (var elem in codeOfMessageForDecryption)
            {
                int code = ToA(elem, k, n, m);
                foreach (var numCode in numCodeOfAlphabet)
                {
                    if (numCode.Key == code)
                    {
                        result.Append(numCode.Value);
                    }
                }
            }
            
            return result;
        }
        
    }
}