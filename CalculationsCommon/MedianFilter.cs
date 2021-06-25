using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculationsCommon
{
    public static class MedianFilter
    {
        private const int minWindowWidth = 3;

        //Naive Implementation
        public static IEnumerable<int> ApplyFilter (int[] numCollection, int windowWidth)
        {
            if (windowWidth < minWindowWidth)
            {
                throw new ArgumentException("Minimal window width for median filer is 3!");
            }
            if (windowWidth > numCollection.Length)
            {
                throw new ArgumentException("Window width for median fileter can't exceed sequence elements quantity!");
            }
            var middleItemIndex = windowWidth / 2;
            for (int i = 0; i < numCollection.Length - windowWidth; i++)
            {
                numCollection[i + middleItemIndex] = numCollection.Skip(i)
                                                                  .Take(windowWidth)
                                                                  .OrderBy(x => x)
                                                                  .ElementAt(middleItemIndex);
            }
            return numCollection;
        }
    }
}
