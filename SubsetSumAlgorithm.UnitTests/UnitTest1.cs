using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SubsetSumAlgorithm;
using SubsetSumAlgorithm.Helpers;
using SubsetSumAlgorithm.Objects;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace Tests
{
    public class TxtCases
    {
        public static string[] StringArr { get; set; }

        public static IEnumerator GetEnumerator()
        {
            foreach (var item in StringArr)
            {
                yield return item;
            }
        }
    }
    public class Tests
    {
        static List<TestCase> listTestCasesJASON = new List<TestCase>();
        static List<TestCase> lisTestCasesYAML = new List<TestCase>();
        static List<TestCase> lisTestCasesTXT = new List<TestCase>();
        static List<string> listItemsParammetricalStringsSerializedJASON;
        static List<string> listITEMSParammetricalStringsSerializedYAML;
        static List<string> listITEMSParammetricalStringsSerializedTXT =new List<string>();
        static string json = "";
        static string yaml = "";
        public static List<string> listParammetricalStringsSerializedJASON = new List<string>();
        public static List<string> listParammetricalStringsSerializedYAML = new List<string>();
        public static string[] arrayParametricalTestsJASON = new string[1000];
        public static string[] arrayParametricalTestsYAML = new string[1000];
        public static string[] arrayParametricalTestsTXT1 = GetTests();
        //public static arrayParametricalTestsTXT tXT;

        static string[] GetTests()
        {
            foreach (var line in File.ReadAllLines(@"c:\tmp\Cases.txt"))
            {
                var (input, output) = JsonConvert.DeserializeObject<(Input, Output)>(line);
                TestCase testCase = new TestCase(input, output);
                listITEMSParammetricalStringsSerializedTXT.Add(JsonConvert.SerializeObject(testCase));
            }
            return listITEMSParammetricalStringsSerializedTXT.ToArray();
        }

        [OneTimeSetUp]
        public void Setup()
        {

            bool LoadJson()
            {
                using (StreamReader r = new StreamReader(@"c:\tmp\path.json"))
                {
                    json = r.ReadToEnd();
                    listItemsParammetricalStringsSerializedJASON = JsonConvert.DeserializeObject<List<string>>(json);
                    foreach (string item in listItemsParammetricalStringsSerializedJASON)
                    {
                        listParammetricalStringsSerializedJASON.Add(item);
                        TestCase testCase = JsonConvert.DeserializeObject<TestCase>(item);
                        listTestCasesJASON.Add(testCase);                        
                    }
                    arrayParametricalTestsJASON = listParammetricalStringsSerializedJASON.ToArray() ;
                }
                return true;
            }
            bool LoadYaml()
            {
                using (StreamReader r = new StreamReader(@"c:\tmp\path.yaml"))
                {
                    yaml = r.ReadToEnd();
                    ISerializer serializer = new SerializerBuilder().Build();
                    IDeserializer deserializer = new DeserializerBuilder().Build();
                    listITEMSParammetricalStringsSerializedYAML =  deserializer.Deserialize<List<string>>(yaml);
                    foreach (string testCase in listITEMSParammetricalStringsSerializedYAML)
                    {
                        string serializedYAMLTestCase = serializer.Serialize(testCase);
                        TestCase testCaseObject = deserializer.Deserialize<TestCase>(testCase);
                        listParammetricalStringsSerializedYAML.Add(serializedYAMLTestCase);
                        lisTestCasesYAML.Add(testCaseObject);
                    }
                    arrayParametricalTestsYAML = new string[1000];
                    arrayParametricalTestsYAML = listParammetricalStringsSerializedYAML.ToArray();
                }
                return true;
            }
            bool LoadTXT()
            {

                void GetTests()
                {
                    foreach (var line in File.ReadAllLines(@"c:\tmp\Cases.txt"))
                    {
                        var (input, output) = JsonConvert.DeserializeObject<(Input, Output)>(line);
                        TestCase testCase = new TestCase(input, output);
                        listITEMSParammetricalStringsSerializedTXT.Add(JsonConvert.SerializeObject(testCase));
                    }
                    arrayParametricalTestsTXT1 = listITEMSParammetricalStringsSerializedTXT.ToArray();
                }
                GetTests();
                return true;
            }

            Assert.IsTrue(LoadTXT());
            //Assert.IsTrue( LoadYaml());
            //Assert.IsTrue( LoadJson());
        }


        [Test, TestCaseSource("arrayParametricalTestsJASON")]
        public void Test1(string _testCase)        
        {
            //Setup();
            if (_testCase != null )
            {
                TestCase testCase1 =  JsonConvert.DeserializeObject<TestCase>(_testCase);                
                Output outputCase2 = Reccurency.ReturnExtremas(testCase1.Input);
                TestCase testCase = new TestCase(testCase1.Input, outputCase2);                    
                Assert.IsTrue(outputCase2.MyEquals(testCase.Output));
            }
        }
        [Test, TestCaseSource("arrayParametricalTestsYAML")]
        public void Test2(string _testCase)
        {            
            IDeserializer YAMLdeserializer = new DeserializerBuilder().Build();            
            if (_testCase != null)
            {
                TestCase testCase1 = YAMLdeserializer.Deserialize<TestCase>(_testCase);                
                Output outputCase2 = SubsetSum.GetSubsetsWhichSumsUp(testCase1.Input);
                TestCase testCase = new TestCase(testCase1.Input, outputCase2);
                Assert.IsTrue(outputCase2.MyEquals(testCase.Output));
            }
        }

        [TestCaseSource("arrayParametricalTestsTXT1")]
        public void Test3(string _testCase)
        {    
            if (_testCase != null)
            {
                TestCase testCase1 = JsonConvert.DeserializeObject<TestCase>(_testCase);
                Output outputCase2 = Reccurency.ReturnExtremas(testCase1.Input);
                
                List<string> comp = new List<string>();
                List<string> comp1 = new List<string>();
                foreach (int[] arr in outputCase2.LongestResults)
                {
                    comp.Add(string.Join("", arr));
                }
                foreach (int[] arr in testCase1.Output.LongestResults)
                {                    
                    comp1.Add(string.Join("", arr));
                }
                foreach (int[] arr in outputCase2.ShortestResults)
                {
                    comp.Add(string.Join("", arr));
                }
                foreach (int[] arr in testCase1.Output.ShortestResults)
                {
                    comp1.Add(string.Join("", arr));
                }
                Assert.AreEqual(comp.Count, comp1.Count);
            }
        }
        [TestCaseSource("arrayParametricalTestsTXT1")]
        public void Test4(string _testCase)
        {
            if (_testCase != null)
            {
                TestCase testCase1 = JsonConvert.DeserializeObject<TestCase>(_testCase);
                Output outputCase2 = Permutator.GetSubsetsWhichSumsUp(testCase1.Input);

                List<string> comp = new List<string>();
                List<string> comp1 = new List<string>();
                foreach (int[] arr in outputCase2.LongestResults)
                {
                    comp.Add(string.Join("", arr));
                }
                foreach (int[] arr in testCase1.Output.LongestResults)
                {
                    comp1.Add(string.Join("", arr));
                }
                foreach (int[] arr in outputCase2.ShortestResults)
                {
                    comp.Add(string.Join("", arr));
                }
                foreach (int[] arr in testCase1.Output.ShortestResults)
                {
                    comp1.Add(string.Join("", arr));
                }
                Assert.AreEqual(comp.Count, comp1.Count);
            }
        }
    }
}
