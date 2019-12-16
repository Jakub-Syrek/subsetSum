using System.Collections.Generic;
using System.Linq;

namespace SubsetSumAlgorithm.Helpers
{
    public static class StaticHelper
    {
        public static bool IsFirstSimmilarToSecond(IList<int[]> first, IList<int[]> second)
        {
            List<int[]> firstList = new List<int[]>(first);
            List<int[]> secondList = new List<int[]>(second);

            for (int i = 0; i < firstList.Count; i++)
            {
                for (int j = 0; j < secondList.Count; j++)
                {
                    if (firstList[i] == secondList[j])
                        firstList.RemoveAt(i);
                }
            }
            if (firstList.Any() == false)
                return true;
            else
                return false;
        }
    }
}
