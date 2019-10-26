using System;

namespace Task13
{
    public class WorkWithConsoleClass
    {
        public int InputA()
        {
            Console.WriteLine("Please input A:");
            return int.Parse(Console.ReadLine());
        }
        
        public int InputC()
        {
            Console.WriteLine("Please input C:");
            return int.Parse(Console.ReadLine());
        }
        
        public int InputM()
        {
            Console.WriteLine("Please input m:");
            return int.Parse(Console.ReadLine());
        }
        
        public int InputStartValue()
        {
            Console.WriteLine("Please input start value:");
            return int.Parse(Console.ReadLine());
        }
        
    }
}