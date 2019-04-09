using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using QueryMutator.Core;
using QueryMutator.TestDatabase;

namespace QueryMutator.Benchmarks
{
    [CoreJob(baseline: true), ClrJob]
    public class QueryMutatorBenchmarks
    {
        [GlobalSetup]
        public void CreateDatabase()
        {
            DatabaseHelper.CreateDatabase("QMTESTDB");
        }

        [Benchmark]
        public IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<ParentEntity, ParentEntityDto>();
            });
            return config.CreateMapper();
        }
    }
}
