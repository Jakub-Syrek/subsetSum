using System;
using System.Collections.Generic;
using System.Text;

namespace SubsetSumAlgorithm.Objects
{
    public struct TestCase : IEquatable<TestCase>
    {
        #region Props

        public Input Input{ get; set; }
        public Output Output { get; set; }

        #endregion

        #region Ctor
        public TestCase(Input input, Output output)
        {
            Input = input;
            Output = output;
        }
               
        public bool MyEquals(TestCase other)
        {
            return (this.Input.Equals(other.Input) && this.Output.Equals(other.Output));
        }

        public bool Equals(TestCase other)
        {
            return (this.Input.Equals(other.Input) && this.Output.Equals(other.Output));
        }

        #endregion
    }
    public struct TestCases
    {
        #region Props

        public Input[] Input { get; set; }
        public Output[] Output { get; set; }

        #endregion

        #region CTOR
        public TestCases(Input[] x, Output[] y)
        {
            Input = x;
            Output = y;

        }
        #endregion
    }
}
