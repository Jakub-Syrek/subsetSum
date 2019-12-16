using System;
using System.Collections.Generic;
using System.Linq;

namespace SubsetSumAlgorithm.Helpers
{
    public static class Reccurency
    {
        static int Sum(this int[] a)
        {
            int sum = 0;
            foreach (int item in a)
                sum += item;
            return sum;
        }
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

        public static Output ReturnExtremas(Input _input)
        {
            int indexer = -1;            
            int[] starter = {};
            List<int[]> lista = new List<int[]>();           
            List<(int, int[])> sortedListDistinct = new List<(int, int[])>();
            Array.Sort(_input.Numbers);
            Recurse(_input.Numbers, indexer, starter);            

            void Recurse(int[] input, int index, int[] actual)
            {
                int n = input.Length;
                if (index == n)                
                    return;
                
                if (actual.Sum() == (int)_input.Sum)
                {
                    Array.Sort(actual);                                        
                    lista.Add(actual);                    
                }
                for (int i = index + 1; i < n; i++)
                {
                    Array.Resize(ref actual, actual.Length + 1);
                    actual[actual.Length - 1] = input[i];                    
                    Recurse(input, i, actual);
                    Array.Resize(ref actual, actual.Length - 1);                    
                }
            }
            sortedListDistinct.AddRange(lista.
                Where(v => !IsContained(sortedListDistinct.
                Select(x => x.Item2).ToList(), v)).
                Select(v => new ValueTuple<int, int[]>(v.Length, v)));
            
            var listaOrdered = sortedListDistinct.
                OrderBy(x => x.Item1).Select(y => y.Item2);
           
            Output output = new Output(false);
            if (listaOrdered.Any())
            {
                output.IsPossible = true;
                output.ShortestResults = listaOrdered.
                    Where(x => x.Length == listaOrdered.First().Length);
                output.LongestResults = listaOrdered.
                    Where(x => x.Length == listaOrdered.Last().Length);
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
