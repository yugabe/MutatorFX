``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.437 (1809/October2018Update/Redstone5)
Intel Core i7-6700K CPU 4.00GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.101
  [Host] : .NET Core 2.2.4 (CoreCLR 4.6.27521.02, CoreFX 4.6.27521.01), 64bit RyuJIT  [AttachedDebugger]
  Core   : .NET Core 2.2.4 (CoreCLR 4.6.27521.02, CoreFX 4.6.27521.01), 64bit RyuJIT

Job=Core  Runtime=Core  

```
|                        Method |          Mean |         Error |        StdDev | Ratio |
|------------------------------ |--------------:|--------------:|--------------:|------:|
|             CreateBasicMapper |  39,139.54 ns |   826.6355 ns | 1,074.8596 ns |  1.00 |
|                               |               |               |               |       |
|        CreateCollectionMapper |  16,983.63 ns |    80.0461 ns |    74.8751 ns |  1.00 |
|                               |               |               |               |       |
|          CreateNullableMapper |  26,006.94 ns |   135.4847 ns |   120.1036 ns |  1.00 |
|                               |               |               |               |       |
|         CreateFlattenedMapper |  12,807.16 ns |   270.8008 ns |   352.1175 ns |  1.00 |
|                               |               |               |               |       |
|         CreateParameterMapper |  33,516.51 ns |   163.9539 ns |   153.3626 ns |  1.00 |
|                               |               |               |               |       |
|                    GetMapping |      51.56 ns |     0.1798 ns |     0.1682 ns |  1.00 |
|                               |               |               |               |       |
|           GetParameterMapping |      60.14 ns |     1.2278 ns |     1.2609 ns |  1.00 |
|                               |               |               |               |       |
|               RunBasicMapping | 107,185.45 ns |   919.1235 ns |   859.7487 ns |  1.00 |
|                               |               |               |               |       |
|          RunCollectionMapping | 111,043.48 ns |   411.4886 ns |   384.9067 ns |  1.00 |
|                               |               |               |               |       |
|            RunNullableMapping |  76,200.42 ns | 1,505.6615 ns | 2,060.9665 ns |  1.00 |
|                               |               |               |               |       |
|           RunFlattenedMapping |  78,456.98 ns |   466.8375 ns |   413.8393 ns |  1.00 |
|                               |               |               |               |       |
|           RunParameterMapping | 151,223.59 ns |   430.5205 ns |   359.5041 ns |  1.00 |
|                               |               |               |               |       |
|           RunBenchmarkMapping |  97,591.34 ns |   382.2506 ns |   298.4361 ns |  1.00 |
|                               |               |               |               |       |
| RunAutoMapperBenchmarkMapping | 111,458.01 ns | 2,333.2108 ns | 3,193.7253 ns |  1.00 |
|                               |               |               |               |       |
|    RunMapsterBenchmarkMapping |  92,945.88 ns |   607.8066 ns |   568.5427 ns |  1.00 |
