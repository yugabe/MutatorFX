using System.Linq;
using BenchmarkDotNet.Attributes;
using QueryMutator.Core;
using QueryMutator.TestDatabase;

namespace QueryMutator.Benchmarks
{
    [CoreJob(baseline: true)]
    public class QueryMutatorBenchmarks
    {
        public IMapper GetMappingMapper { get; set; }

        public IMapper GetParameterMappingMapper { get; set; }

        public IMapping<ParentEntity, ParentEntityDto> RunBasicMappingMapping { get; set; }

        public IMapping<CollectionParent, CollectionParentDto> RunCollectionMappingMapping { get; set; }

        public IMapping<NullableParentEntity, NullableParentEntityDto> RunNullableMappingMapping { get; set; }

        public IMapping<FlattenedParent, FlattenedParentDto> RunFlattenedMappingMapping { get; set; }

        public IMapping<ParentEntity, ParentEntityDto, int> RunParameterMappingMapping { get; set; }

        public QueryMutatorBenchmarks()
        {
            DatabaseHelper.CreateDatabase("QMTESTDB");
        }

        #region Create mapper

        [Benchmark]
        public IMapper CreateBasicMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<ParentEntity, ParentEntityDto>();
            });
            return config.CreateMapper();
        }

        [Benchmark]
        public IMapper CreateCollectionMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<CollectionParent, CollectionParentDto>();
            });
            return config.CreateMapper();
        }

        [Benchmark]
        public IMapper CreateNullableMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<NullableParentEntity, NullableParentEntityDto>();
            });
            return config.CreateMapper();
        }

        [Benchmark]
        public IMapper CreateFlattenedMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<FlattenedParent, FlattenedParentDto>();
            });
            return config.CreateMapper();
        }

        [Benchmark]
        public IMapper CreateParameterMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<ParentEntity, ParentEntityDto, int>(mapping => mapping
                    .MapMemberWithParameter(d => d.Parameterized, p => dd => dd.Id * p)
                );
            });
            return config.CreateMapper();
        }

        #endregion

        #region Get mapping

        [GlobalSetup(Target = nameof(GetMapping))]
        public void SetupGetMapping()
        {
            GetMappingMapper = new MapperConfiguration(cfg => cfg.CreateMapping<ParentEntity, ParentEntityDto>()).CreateMapper();
        }

        [Benchmark]
        public IMapping GetMapping()
        {
            return GetMappingMapper.GetMapping<ParentEntity, ParentEntityDto>();
        }

        [GlobalSetup(Target = nameof(GetParameterMapping))]
        public void SetupGetParameterMapping()
        {
            GetParameterMappingMapper = new MapperConfiguration(cfg =>
                cfg.CreateMapping<ParentEntity, ParentEntityDto, int>(mapping => mapping
                    .MapMemberWithParameter(d => d.Parameterized, p => dd => dd.Id * p)
                ))
                .CreateMapper();
        }

        [Benchmark]
        public object GetParameterMapping()
        {
            return GetParameterMappingMapper.GetMapping<ParentEntity, ParentEntityDto, int>();
        }

        #endregion

        #region Run mapping

        [GlobalSetup(Target = nameof(RunBasicMapping))]
        public void SetupRunBasicMapping()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMapping<ParentEntity, ParentEntityDto>()).CreateMapper();
            RunBasicMappingMapping = mapper.GetMapping<ParentEntity, ParentEntityDto>();
        }

        [Benchmark]
        public ParentEntityDto RunBasicMapping()
        {
            using (var context = new DatabaseContext(DatabaseHelper.Options))
            {
                var dtos = context.ParentEntities.Select(RunBasicMappingMapping).ToList();
                return dtos.FirstOrDefault();
            }
        }

        [GlobalSetup(Target = nameof(RunCollectionMapping))]
        public void SetupRunCollectionMapping()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMapping<CollectionParent, CollectionParentDto>()).CreateMapper();
            RunCollectionMappingMapping = mapper.GetMapping<CollectionParent, CollectionParentDto>();
        }

        [Benchmark]
        public CollectionParentDto RunCollectionMapping()
        {
            using (var context = new DatabaseContext(DatabaseHelper.Options))
            {
                var dtos = context.CollectionParents.Select(RunCollectionMappingMapping).ToList();
                return dtos.FirstOrDefault();
            }
        }

        [GlobalSetup(Target = nameof(RunNullableMapping))]
        public void SetupRunNullableMapping()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMapping<NullableParentEntity, NullableParentEntityDto>()).CreateMapper();
            RunNullableMappingMapping = mapper.GetMapping<NullableParentEntity, NullableParentEntityDto>();
        }

        [Benchmark]
        public NullableParentEntityDto RunNullableMapping()
        {
            using (var context = new DatabaseContext(DatabaseHelper.Options))
            {
                var dtos = context.NullableParentEntities.Select(RunNullableMappingMapping).ToList();
                return dtos.FirstOrDefault();
            }
        }

        [GlobalSetup(Target = nameof(RunFlattenedMapping))]
        public void SetupRunFlattenedMapping()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMapping<FlattenedParent, FlattenedParentDto>()).CreateMapper();
            RunFlattenedMappingMapping = mapper.GetMapping<FlattenedParent, FlattenedParentDto>();
        }

        [Benchmark]
        public FlattenedParentDto RunFlattenedMapping()
        {
            using (var context = new DatabaseContext(DatabaseHelper.Options))
            {
                var dtos = context.FlattenedParents.Select(RunFlattenedMappingMapping).ToList();
                return dtos.FirstOrDefault();
            }
        }

        [GlobalSetup(Target = nameof(RunParameterMapping))]
        public void SetupRunParameterMapping()
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMapping<ParentEntity, ParentEntityDto, int>(mapping => mapping
                    .MapMemberWithParameter(d => d.Parameterized, p => dd => dd.Id * p)
                ))
                .CreateMapper();
            RunParameterMappingMapping = mapper.GetMapping<ParentEntity, ParentEntityDto, int>();
        }

        [Benchmark]
        public ParentEntityDto RunParameterMapping()
        {
            using (var context = new DatabaseContext(DatabaseHelper.Options))
            {
                var dtos = context.ParentEntities.Select(RunParameterMappingMapping, 15).ToList();
                return dtos.FirstOrDefault();
            }
        }

        #endregion
    }
}
