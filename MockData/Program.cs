using Bogus;
using System;

namespace MockData // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Initializing data with Bogus...");
            DataGenerator.ResultData();
            Console.WriteLine("Several Users: ");
            DataGenerator.Persons.ForEach(Console.WriteLine);
        }
    }
}