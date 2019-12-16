using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubsetSumAlgorithm.Helpers
{
  
    public static class HeapsAlgorithm
    {

        private static Stack<int[]> stackWithIntArrays;
        private static bool NextCombination(IList<int> num, int n, int k)
        {
            bool finished;

            var changed = finished = false;

            if (k <= 0) return false;

            for (var i = k - 1; !finished && !changed; i--)
            {
                if (num[i] < n - 1 - (k - 1) + i)
                {
                    num[i]++;

                    if (i < k - 1)
                        for (var j = i + 1; j < k; j++)
                            num[j] = num[j - 1] + 1;
                    changed = true;
                }
                finished = i == 0;
            }

            return changed;
        }

        public static IEnumerable Combinations<T> (IEnumerable<T> elements, int k)
        {
            var elem = elements.ToArray();
            var size = elem.Length;

            if (k > size) yield break;

            var numbers = new int[k];

            for (var i = 0; i < k; i++)
                numbers[i] = i;

            do
            {
                yield return numbers.Select(n => elem[n]);
            } while (NextCombination(numbers, size, k));
        }

        public static int[] MyToArray(this IEnumerable enumerable)
        {
            List<int> genericList = new List<int>();
            var sequenceEnum = enumerable.GetEnumerator();            
            while (sequenceEnum.MoveNext())
            {
                //genericList.Add((int)sequenceEnum.Current.ToString());
                var z = sequenceEnum.Current;
            }


            foreach (object obj in enumerable)
            {
                int x = (Int16)obj;
                genericList.Add(x);
            }
            return genericList.ToArray();

            //IList<T> ilista = (IList<T>)enumerable;
            //int count = ilista.Count();
            //T[] arr = ilista.ToArray();       
            //return enumerable == null ? new T[count] : arr;
        }
        public static Output ReturnCalc(Input input)
        {
            #region PrepareAndExecute
            Array.Sort(input.Numbers);

            int n, i;
            
           
            n = input.Numbers.Count();
            

            Console.Write("\n The Permutations with a combination of {0} digits are : \n", n);
            for (int j = 0; j < n+1; j++)
            {                
                IEnumerable enumerable = HeapsAlgorithm.Combinations(input.Numbers, j);
                int[] arr = enumerable.MyToArray();
                //Enumerable.ToArray<int>(enumerable)



                //Array.ConvertAll(ret,new Converter<IEnumerable<int>,int[]>() conv)
                if (arr != null )  //&& ret.Any() )
                {
                    for (int k = 0; k < arr.Count(); k++)
                    {
                        var zzz = arr[k];
                    }
                    foreach ( var x in arr)
                    {
                        
                        Console.WriteLine((dynamic)x);
                    }
                    
                }
            }
            #endregion
            Output output = new Output(false);
                        
            if (stackWithIntArrays != null )
            {
                if (stackWithIntArrays.Any())
                {


                    var stackOrdered = stackWithIntArrays.OrderBy(x => x.Count());
                    output.IsPossible = true;
                    output.ShortestResults = stackOrdered.Where(x => x.Count() == stackOrdered.First().Count());
                    output.LongestResults = stackOrdered.Where(x => x.Count() == stackOrdered.Last().Count());
                    stackWithIntArrays.Clear();
                    return output;
                    //int[][] ShortestAndLongestExæquo = ShortestResults.Select(x => x).Concat(LongestResults.Select(y => y)).ToArray();
                    //Action<int[]> action = new Action<int[]>(ResBuilder);
                    //Array.ForEach(ShortestAndLongestExæquo, action);
                }
                return output;
            }
            else
                return output;
        }

    }
}
