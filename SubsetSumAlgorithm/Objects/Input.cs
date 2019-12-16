using System;
using System.Collections.Generic;
using System.Text;

namespace SubsetSumAlgorithm
{
    public struct Input : IEquatable<Input>
    {
        public int[] Numbers { get; set; }
        public int Sum { get; set; }
        public Input(int[] nr, int num)
        {
            Numbers = nr;
            Sum = num;
        }

        public bool Equals(Input other)
        {
            return (this.Numbers == other.Numbers && this.Sum == other.Sum);
        }
    }
}
