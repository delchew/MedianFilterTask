using CalculationsCommon;
using System;
using System.IO;
using System.Linq;

namespace MedianFilterTask
{
    public class Program
    {
        private static readonly string fileName = "data.txt";
        private static readonly string _filePath = Path.Combine(Environment.CurrentDirectory + "\\Data", fileName);
        public static void Main(string[] args)
        {
            try
            {
                var data = DataFileParser.TryGetData(_filePath);
                var results = DataHandler.GetResults(data).ToArray();

                Console.WriteLine("Sequense of calculated results:");
                foreach (var result in results)
                {
                    Console.Write($"{result} ");
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("for window width equal to");
                for (int i = 3; i <= 10000001; i += 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{i}: ");

                    Console.ForegroundColor = ConsoleColor.White;
                    var filteredResults = MedianFilter.ApplyFilter(results, i);
                    foreach (var result in filteredResults)
                    {
                        Console.Write($"{result} ");
                    }
                    Console.WriteLine();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Filter window width has exceeded the results sequence size. Calculations was stopped.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
