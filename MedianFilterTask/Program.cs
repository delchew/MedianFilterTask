using CalculationsCommon;
using System;
using System.IO;

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
                var results = DataHandler.GetResults(data);

                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
