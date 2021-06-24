using System.Collections.Generic;

namespace CalculationsCommon
{
    public class DataSetType
    {
        public int TypeId { get; set; }
        public IEnumerable<int> Data { get; set; }
    }
}
