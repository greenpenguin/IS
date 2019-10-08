using System;
using System.Text;

namespace Task6
{
    public class WorkWithConsole
    {
        public string InputKeyWordFromConsole()
        {
            Console.WriteLine("Please input key word:");
            string outputStr = Console.ReadLine();
            StringBuilder outputStringBuilder = new StringBuilder();

            foreach (var elem in outputStr)
            {
                outputStringBuilder.Append(char.ToUpper(elem));
            }
            return outputStringBuilder.ToString();
        }
    }
}