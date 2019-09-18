using System.IO;

namespace Task3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string inputFilePath = Directory.GetCurrentDirectory() + "/input.txt";
            string outputFilePath = Directory.GetCurrentDirectory() + "/output.txt";
            
            WorkWithFileClass workWithFileClass = new WorkWithFileClass();
            
            workWithFileClass.ReadFile(inputFilePath);
            workWithFileClass.WriteTableToFile(outputFilePath);
        }
    }
}