using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CalculationsCommon
{
    public static class DataFileParser
    {
        public static IEnumerable<DataSetType> TryGetData(string filePath)
        {
            var dataSets = new List<DataSetType>();
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var dataSet = GetDataSet(reader.ReadLine());
                        dataSets.Add(dataSet);
                    }
                }
                return dataSets;
            }
            throw new FileNotFoundException("File not found for specified path!");
        }

        private static DataSetType GetDataSet(string inputLine)
        {
            var dataSet = inputLine.Split(' ').Select(int.Parse);
            return new DataSetType { TypeId = dataSet.First(), Data = dataSet.Skip(1) };
        }
    }
}
