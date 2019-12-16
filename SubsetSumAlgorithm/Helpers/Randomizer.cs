using System;
using System.Collections.Generic;

namespace SubsetSumAlgorithm
{
    static public class Randomizer
    {
        public static IEnumerable<Input> GenerateRandoms(int SetCount,int setRange)
        {
            int rangeElementsFromOne = setRange;
            int inputSetsNedded = SetCount;

            Random rnd = new Random();
            //od 1 do 20 liczb i od -200 do +200 zakres
            int[] ReturnSet(int numbersCount)
            {
                int[] arr = new int[numbersCount];
                
                for (int i = 0; i < numbersCount; i++)                
                    arr[i] = rnd.Next(-200, 200);
                
                return arr;
            }

            List<Input> lista = new List<Input>();
            for (int i = 0; i < inputSetsNedded; i++)
            {
                Input input = new Input();
                input.Numbers = ReturnSet(rnd.Next(1, rangeElementsFromOne));
                input.Sum = rnd.Next(-200, 200);
                lista.Add(input);
            }
            return (IEnumerable<Input>)lista;
        }
    }
}
