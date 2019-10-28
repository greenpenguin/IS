using System;
using System.Text;

namespace Task7
{
    public class WorkWithConsole
    {
        public string InputKeyWordFromConsole()
        {
            Console.WriteLine("Please input key word:");
            string outputStr = Console.ReadLine();
            return outputStr;
        }
    }
}