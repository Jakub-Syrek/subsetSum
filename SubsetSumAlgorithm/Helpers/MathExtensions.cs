using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace SubsetSumAlgorithm
{
    public static class MathExtensions
    {
        public static Func<IEnumerable<int>, BigInteger> MultiplyToBigInt = new Func<IEnumerable<int>, BigInteger>(MultiplierBigInteger);
        public static Func<IEnumerable<int>, int> MultiplyToInt = new Func<IEnumerable<int>, int>(Multiplier);
        private static int Multiplier(IEnumerable<int> arr)
        {
            int x = 1;
            foreach (var item in arr)
                x *= (item == 0) ? 1 : item;

            return x;
        }
        private static BigInteger MultiplierBigInteger(IEnumerable<int> arr)
        {
            BigInteger x = 1;
            foreach (var item in arr)
                x *= (item == 0) ? 1 : item;

            return x;
        }
        public static int ReturnNumberOfAllPossibleCombinationsByShortening(int SetCount, int subsetCountMax = 1)
        {
            Func<IEnumerable<int>, int> Multiply = new Func<IEnumerable<int>, int>(Multiplier);

            int CalculateCombinations(int _n)
            {

                int sum = 0;

                for (int i = 1; i <= ((subsetCountMax == 0) ? _n : subsetCountMax + 1); i++)
                {
                    IEnumerable<int> XData = Enumerable.Range(1, _n).Select(x => x).Reverse().Take(subsetCountMax);
                    IEnumerable<int> YData = Enumerable.Range(1, subsetCountMax).Select(x => x).Reverse();
                    var result = XData.Union(YData).Distinct();

                    XData = XData.Except(YData);
                    YData = YData.Except(XData);

                    int X = Multiply(XData);
                    int Y = Multiply(YData);
                    int subCombinationsValue = X / Y;
                    sum += subCombinationsValue;
                }
                return sum;
            }
            return CalculateCombinations(SetCount);
        }
        public static BigInteger ReturnNumberOfAllPossibleCombinations(int SetCount, int subsetCountMax = 1) //From set of 52 cards choose 5.How many 5 card combinations.
        {
            

            BigInteger CalculateCombinations(int _n)
            {
                IEnumerable<int> licznikDane = Enumerable.Range(1, _n).Select(x => x).Reverse().Take(subsetCountMax);
                BigInteger licznik = MultiplyToBigInt(licznikDane);
                BigInteger sum = 0;

                for (int i = 1; i <= ((subsetCountMax == 0) ? _n : subsetCountMax + 1); i++)
                {
                    IEnumerable<int> mianownikDane = Enumerable.Range(1, subsetCountMax).Select(x => x).Reverse();
                    BigInteger mianownik = MultiplyToBigInt(mianownikDane);
                    BigInteger subCombinationsValue = licznik / mianownik;
                    sum += subCombinationsValue;
                }
                return sum;
            }
            return CalculateCombinations(SetCount);
        }
    }
}
