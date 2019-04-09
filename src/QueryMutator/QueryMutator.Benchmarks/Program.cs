using System;
using BenchmarkDotNet.Running;

namespace QueryMutator.Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<QueryMutatorBenchmarks>();

            Console.ReadLine();
        }
    }
}
