using CalculationsCommon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CalculationsCommonTests
{
    [TestClass]
    public class DataHandlerTests
    {

        [TestMethod]
        public void TestMethod1()
        {
            var dataset = new DataSetType[]
            {
                new DataSetType{TypeId = 1, Data = new [] {1, 5, 12, 8, 200}},
                new DataSetType{TypeId = 2, Data = new [] {1, 5, 12, 8, 200}},
                new DataSetType{TypeId = 3, Data = new [] {1, 5, 12, 8, 200}},
                new DataSetType{TypeId = 4, Data = new [] {1, 5, 12, 8, 200}},
            };
            var results = DataHandler.GetResults(dataset);

            Assert.AreEqual(new[] { 226, 120, 200, 1 }, results);
        }
    }
}
