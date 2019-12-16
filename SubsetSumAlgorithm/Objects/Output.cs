using SubsetSumAlgorithm.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubsetSumAlgorithm
{
   
    public struct Output : IEquatable<Output>
    {
        #region Fields
        public IEnumerable<int[]> ShortestResults { get; set; } 

        public IEnumerable<int[]> LongestResults { get; set; } 
        
        public bool IsPossible;
        #endregion

        #region CTOR
        
        public Output(bool x)
        {
            IsPossible = x;
            ShortestResults = null; // new int[0][];
            LongestResults = null; //new int[0][]; 
        }

        public bool MyEquals(Output other)
        {
            bool result1 = false;
            bool result2 = false;
            bool result3 = false;
            if (this.ShortestResults == null && other.ShortestResults == null)
                result1 = true;
            else
                result1 = StaticHelper.IsFirstSimmilarToSecond(this.ShortestResults.ToList(), other.ShortestResults.ToList());
            if (this.LongestResults == null && other.LongestResults == null)
                result2 = true;
            else
                result2 = StaticHelper.IsFirstSimmilarToSecond(this.LongestResults.ToList(), other.LongestResults.ToList());
            if (this.IsPossible == null && other.IsPossible == null)
                result3 = true;
            else
                result3 = this.IsPossible == other.IsPossible;

            return (result1 && result2 && this.IsPossible == other.IsPossible);
        }

        public bool Equals(Output other)
        {
            bool result1 = false;
            bool result2 = false;
            bool result3 = false;
            if (this.ShortestResults == null && other.ShortestResults == null)
                result1 = true;
            else
                result1 = StaticHelper.IsFirstSimmilarToSecond(this.ShortestResults.ToList(), other.ShortestResults.ToList());
            if (this.LongestResults == null && other.LongestResults == null)
                result2 = true;
            else
                result2 = StaticHelper.IsFirstSimmilarToSecond(this.LongestResults.ToList(), other.LongestResults.ToList());
            if (this.IsPossible == null && other.IsPossible == null)
                result3 = true;
            else
                result3 = this.IsPossible == other.IsPossible;

            return (result1 && result2 && this.IsPossible == other.IsPossible);
        }
        #endregion
    }
}
