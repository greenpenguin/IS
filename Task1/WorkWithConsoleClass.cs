using System;

namespace Task1
{
    public class WorkWithConsoleClass
    {
        public int ReadNFromConsole()
        {
            Console.WriteLine("Please, input n:");
            return int.Parse(Console.ReadLine());
        }
        
        public int ReadAnotherNFromConsole()
        {
            Console.WriteLine("GCD(n, m) is not 1. Please, input another n:");
            return int.Parse(Console.ReadLine());
        }
        
        public int ReadKFromConsole()
        {
            Console.WriteLine("Please, input k:");
            return int.Parse(Console.ReadLine());
        }
    }
}