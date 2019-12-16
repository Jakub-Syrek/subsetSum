using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubsetSumAlgorithm
{
    public static class SubsetSum
    { 

        #region Static Helpers
        public static string SerializeResults(Output output)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"[{ResBuilder(output.ShortestResults)}{ResBuilder(output.LongestResults)}{output.IsPossible.ToString()}]");
            return sb.ToString();
        }
        public static string ResBuilder(IEnumerable<int[]> arr)
        {
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < arr.Count(); i++)
            {
                sb.Append("[");
                for (int j = 0; j < arr.ElementAt(i).Length; j++)
                {
                    if (j != arr.ElementAt(i).Length - 1)
                        sb.Append($"{arr.ElementAt(i)[j]},");
                    else
                        sb.Append($"{arr.ElementAt(i)[j]}");
                }
                sb.Append("],");
            }
            return sb.ToString();  //Remove(sb.Length-1,1)
        }

        #endregion

        private static Stack<int[]> stackWithIntArrays;       
        public static Output GetSubsetsWhichSumsUp (Input input)
        {
            if (stackWithIntArrays == null)
                stackWithIntArrays = new Stack<int[]>();
            
            #region PrepareAndExecute
            Array.Sort(input.Numbers);
            int length = input.Numbers.Length;
            for (int i = 1; i < length; i++)
                Recurrency(_targetNum: input.Sum, _index1: 0, _index2: length, _index3: i, _input: input.Numbers, _output: String.Empty);
            #endregion

            #region SortAndFiletrDataForOutput
            var stackOrdered = stackWithIntArrays.OrderBy(x => x.Count());

            Output output = new Output(false);
            if (stackOrdered.Any())
            {                
                output.IsPossible = true;
                output.ShortestResults = stackOrdered.Where(x => x.Count() == stackOrdered.First().Count());
                output.LongestResults = stackOrdered.Where(x => x.Count() == stackOrdered.Last().Count());
                stackWithIntArrays.Clear();
                return output;
                //int[][] ShortestAndLongestExæquo = ShortestResults.Select(x => x).Concat(LongestResults.Select(y => y)).ToArray();
                //Action<int[]> action = new Action<int[]>(ResBuilder);
                //Array.ForEach(ShortestAndLongestExæquo, action);
            }
            else
                return output;
            #endregion
        }

        #region Calculation
        private static void Recurrency(int _targetNum, int _index1, int _index2, int _index3, int[] _input, string _output)
        {
            if (stackWithIntArrays == null)
                stackWithIntArrays = new Stack<int[]>();

            if (_index3 == 0) //inner loop
            {
                string[] numbersTexted = _output.Split(';');
                int[] subNumbers = new int[numbersTexted.Length];
                int subSum = 0;
                for (int i = 0; i < numbersTexted.Length; i++)
                {
                    if (String.IsNullOrWhiteSpace(numbersTexted[i]) == false)
                    {
                        var parser = Int32.Parse(numbersTexted[i]);
                        if (_input.Contains(parser))
                        {
                            subSum += parser;
                            subNumbers[i] = parser;
                        }
                    }
                }
                if (subSum == _targetNum)
                    stackWithIntArrays.Push((int[])subNumbers.Skip(1).ToArray());
                return;
            }
            if (_index3 > _index2)
                return;

            for (int j = _index1; j < _index2; j++)
                Recurrency(_targetNum: _targetNum, _index1: j + 1, _index2: _index2, _index3: _index3 - 1, _input: _input, _output: $"{_output};{_input[j]}");
        }

        
        #endregion
    }
}
