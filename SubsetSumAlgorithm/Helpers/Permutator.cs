using Facet.Combinatorics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SubsetSumAlgorithm.Helpers
{
    public static class Permutator
    {       
        static bool IsContained(this List<int[]> lst, int[] y)
        {
            if (!lst.Any())
                return false;
            foreach (var _ in lst.
                Where(v => string.
                Join("", v).
                SequenceEqual(string.
                Join("", y))).
                Select(v => new { }))
                return true;
            return false;
        }
        public static Output GetSubsetsWhichSumsUp(Input input)
        {
            var lstWithIntArraysStart = new List<int[]>();
            var lstWithIntArraysEnd = new List<int[]>();
            Array.Sort(input.Numbers);
            for (int i = 0; i < input.Numbers.Count(); i++)
            {
                var combinations = new Combinations<int>(input.Numbers, i);
                foreach (var set in combinations.Where(set => set.Sum() == input.Sum).Select(set => set))
                {
                    var array = new int[set.Count];
                    set.CopyTo(array, 0);
                    Array.Sort(array);
                    if (IsContained(lstWithIntArraysStart, array) == false)
                        lstWithIntArraysStart.Add(array);
                }
                if (lstWithIntArraysStart.Any())
                {
                    break;
                }
            }
            for (int i = input.Numbers.Count(); i > 0; i--)
            {
                var combinations = new Combinations<int>(input.Numbers, i);
                foreach (var set in combinations.Where(set => set.Sum() == input.Sum).Select(set => set))
                {
                    var array = new int[set.Count];
                    set.CopyTo(array, 0);
                    Array.Sort(array);
                    if (IsContained(lstWithIntArraysEnd, array) == false)
                        lstWithIntArraysEnd.Add(array);
                }
                if (lstWithIntArraysEnd.Any())
                {
                    break;
                }
            }
            List<int[]> lstWithIntArrays = lstWithIntArraysStart.Concat(lstWithIntArraysEnd).ToList();
            Output output = new Output(false);
            if (lstWithIntArrays.Any())
            {                
                output.IsPossible = true;
                output.ShortestResults = lstWithIntArraysStart;
                output.LongestResults = lstWithIntArraysEnd;
                return output;
            }
            else                
            {
                output.LongestResults = new int[0][];
                output.ShortestResults = new int[0][];
                return output;
            }
        }
    }
}
