using Newtonsoft.Json;
using SubsetSumAlgorithm.Helpers;
using SubsetSumAlgorithm.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace SubsetSumAlgorithm
{
    class Program
    {
        static void Main(string[] args) 
        {            
            

            int testCasesDemand = 1000;
            IEnumerable<Input> collectionOfTestCases = Randomizer.GenerateRandoms(SetCount: testCasesDemand,setRange: 20);
            //List<TestCase> list = new List<TestCase>();
            //TestCase testCase = new TestCase();
            //Input input = new Input();
            //Output output = new Output();
            //input.Numbers = new int[] { -10,-42,31,136,30,-136,68,-95,-44,62,-96,124,-4,141,62,-42,-60,71,-57};
            //input.Sum = 148;
            //output.ShortestResults = new int[][] { new int[] { 68, -44, 124 } };
            //output.LongestResults = new int[][] {
            //    new int[]{-42,31,136,30,-136,68,-95,-44,62,-96,124,141,-42,-60,71},
            //    new int[] {-10,-42,31,136,-136,68,-95,62,-96,124,-4,141,-42,-60,71},
            //    new int[] {-10,-42,136,30,-136,68,-95,-44,62,-96,124,-4,141,71,-57},
            //    new int[] {-42,136,-136,68,-95,-44,62,-96,124,-4,141,62,-42,71,-57},
            //    new int[] {-10,-42,31,136,30,-136,62,-96,124,-4,141,-42,-60,71,-57},
            //    new int[] {-42,31,136,30,68,-95,-44,62,-96,124,62,-42,-60,71,-57},
            //    new int[] {-42,31,136,30,-136,68,-95,62,124,-4,62,-42,-60,71,-57},
            //    new int[] {-10,-42,31,136,68,-95,62,-96,124,-4,62,-42,-60,71,-57}};
            //testCase.Input = input;
            //testCase.Output = output;
            //list.Add(testCase);
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            foreach (Input input in collectionOfTestCases)//collectionOfTestCases)
            {
                Output res = Reccurency.ReturnExtremas(input);
                Console.WriteLine(res.IsPossible.ToString());
                if (res.IsPossible)
                {
                    
                    foreach (var item1 in res.LongestResults)
                    {
                        foreach (int it in item1)
                        {
                            Console.Write($"{it},");
                        }
                        Console.WriteLine();   //$" sums up to 148, Most subsets => {item1.Length} elements");
                    }
                    foreach (var item2 in res.ShortestResults)
                    {
                        foreach (var it in item2)
                        {
                            Console.Write($"{it},");
                        }
                        Console.WriteLine();   // $" sums up to 148, Least subsets => {item2.Length} elements");
                    }
                }
                else
                {
                    Console.WriteLine(res.IsPossible.ToString());
                }
            }
            Console.WriteLine($"{testCasesDemand} cases done in {stopwatch1.Elapsed}");



            List<string> serializedListJSON = new List<string>();
            List<string> serializedListYAML = new List<string>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (Input input in collectionOfTestCases)//collectionOfTestCases)
            {
                Output outputCase = Permutator.GetSubsetsWhichSumsUp(input);//Reccurency.ReturnExtremas(input);                
                TestCase test = new TestCase(input, outputCase);
                ISerializer YAMLserializer = new SerializerBuilder().Build();
                serializedListJSON.Add(JsonConvert.SerializeObject(test));
                serializedListYAML.Add(YAMLserializer.Serialize(test));

                var count = serializedListJSON.Count.ToString();
                var time = stopwatch.Elapsed.ToString();
                Console.WriteLine($"{count} sets with {input.Numbers.Length} elements in ==>{time}");
            }
            var countFull = serializedListJSON.Count.ToString();
            var timeFull = stopwatch.Elapsed.ToString();
            Console.WriteLine($"{countFull} sets generated and verified in ==>{timeFull}");

            using (System.IO.StreamWriter file = File.CreateText(@"c:\tmp\path.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, serializedListJSON);
            }
            using (System.IO.StreamWriter file = File.CreateText(@"c:\tmp\path.yaml"))
            {
                ISerializer serializer = new SerializerBuilder().Build();
                serializer.Serialize(file, serializedListYAML);
            }



            Console.ReadLine();
        }
    }


















    //$"{{{JsonConvert.SerializeObject(test2)}{Environment.NewLine}}}");
    //TestCase test1 = new TestCase(inputCase, outputCase1);
    //Output? outputCase1 = Permutator.GetSubsetsWhichSumsUp(inputCase);
    //string[] serializedArray = new string[testCasesDemand];
    //List<Input> inputsList = (List<Input>)collectionOfTestCases;
    //Stopwatch stopwatch = new Stopwatch();
    //stopwatch.Start();
    //ParallelLoopResult z = Parallel.For(0, inputsList.Count, i =>
    //{
    //    lock (serializedList)
    //    {
    //        //var subset = new SubsetSum();

    //        Output outputCase = SubsetSum.GetSubsetsWhichSumsUp(inputsList[i]);
    //        TestCase test = new TestCase(inputsList[i], outputCase);
    //        serializedList.Add(JsonConvert.SerializeObject(test));
    //    }

    //});
    //if (z.IsCompleted)
    //    Console.WriteLine($"{serializedList.Count.ToString()} sets generated and verified in Parallel ==>{stopwatch.Elapsed.ToString()}");

    //foreach (var inputCase in collectionOfTestCases)
    //{
    //    //Output? outputCase1 = Permutator.GetSubsetsWhichSumsUp(inputCase);
    //    Output outputCase2 = SubsetSum.GetSubsetsWhichSumsUp(inputCase);
    //    //TestCase test1 = new TestCase(inputCase, outputCase1);
    //    TestCase test2 = new TestCase(inputCase, outputCase2);
    //    serializedList.Add(JsonConvert.SerializeObject(test2));
    //    //Console.WriteLine($"{{{JsonConvert.SerializeObject(test1)}{Environment.NewLine}}}");
    //    Console.WriteLine(serializedList.Count.ToString());                            //$"{{{JsonConvert.SerializeObject(test2)}{Environment.NewLine}}}");
    //}
    //foreach (Input testCase in collectionOfTestCases)
    //{                
    //    Output outputCase = SubsetSum.GetSubsetsWhichSumsUp(testCase);
    //    TestCase test = new TestCase(testCase, outputCase);
    //    list.Add(test);
    //    Console.WriteLine($"{{{JsonConvert.SerializeObject(test)}{Environment.NewLine}}}");
    //}

    //Parallel.ForEach<Input>(collectionOfTestCases, testCase =>                                     
    //{
    //    Output outputCase = SubsetSum.GetSubsetsWhichSumsUp(testCase);
    //    list.Add((testCase,outputCase));

    //});
    //Console.WriteLine($"{{{JsonConvert.SerializeObject(inp)}{Environment.NewLine}{JsonConvert.SerializeObject(output)}{Environment.NewLine}}}");                
    //Parallel.ForEach<(Input, Output)>(list, pair =>
    //{
    //    Console.WriteLine($"{{{JsonConvert.SerializeObject((pair.Item1,pair.Item2))}{Environment.NewLine}}}");
    //});
}



//Console.WriteLine(MathExtensions.ReturnNumberOfAllPossibleCombinations(input.Numbers.Length(),input.Sum));
//Console.WriteLine(MathExtensions.ReturnNumberOfAllPossibleCombinationsByShortening(input.Numbers.Length, input.Sum));