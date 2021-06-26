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
                //get data from file
                var data = DataFileParser.TryGetData(_filePath);

                //calculate results fo each data set
                var results = DataHandler.GetResults(data).ToArray();

                //print results
                Console.WriteLine("Sequense of calculated results:");
                foreach (var result in results)
                {
                    Console.Write($"{result} ");
                }
                Console.WriteLine("\n");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Filtered results for window width equal to");

                for (int i = 3; i <= 10000001; i += 2)
                {
                    //print filtered results
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{i}: ");
                    Console.ResetColor();
                    var filteredResults = MedianFilter.ApplyFilter(results, i);

                    foreach (var result in filteredResults)
                    {
                        Console.Write($"{result} ");
                    }
                    Console.WriteLine("\n");
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
