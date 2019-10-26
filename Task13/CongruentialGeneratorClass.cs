using System;
using System.Collections.Generic;
using System.Text;

namespace Task13
{
    public class CongruentialGeneratorClass
    {
        private int GCD(int n, int m)
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
        
        //Числа m и c взаимно простые
        //m >= 2, 0 <= A < m, 0 <= C < m, 0 <= t0 < m
        public List<int> CongruentialGenerator(int a, int c, int m, int startValue, int finalLength)
        {
            if (GCD(m, c) != 1)
            {
                throw new ArgumentException("m and c are not coprime integers!");
            }

            if ((m < 2) || (a < 0) || (a >= m) || (c < 0) || (c >= m) || (startValue < 0) || (startValue >= m))
            {
                throw new ArgumentException("Some values are inappropriate!");
            }
            
            List<int> result = new List<int>();
            result.Add(startValue);
            while (result.Count < finalLength)
            {
                result.Add((a * result[result.Count - 1] + c) % m);
            }

            /*foreach (var elem in result)
            {
                Console.Write(elem + " ");
            }*/

            return result;
        }
    }
}