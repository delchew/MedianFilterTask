using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculationsCommon
{
    public class DataHandler
    {
        private Dictionary<int, Func<DataSetType, int>> _handlersStorage = new Dictionary<int, Func<DataSetType, int>>
        {
            { 1, (dataSet) => dataSet.Data.Sum() % 255 },
            { 2, (dataSet) => dataSet.Data.Aggregate((x, y) => x * y % 255) },
            { 3, (dataSet) => dataSet.Data.Max() },
            { 4, (dataSet) => dataSet.Data.Min() }
        };

        public IEnumerable<int> GetResults(IEnumerable<DataSetType> dataSetTypes)
        {
            var results = new List<int>();
            foreach(var datasetType in dataSetTypes)
            {
                results.Add(_handlersStorage[datasetType.TypeId](datasetType));
            }
            return results;
        }
    }
}
