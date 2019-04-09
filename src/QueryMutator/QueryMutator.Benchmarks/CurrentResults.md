``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.379 (1809/October2018Update/Redstone5)
Intel Core i7-6700K CPU 4.00GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.101
  [Host] : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT  [AttachedDebugger]
  Core   : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT

Job=Core  Runtime=Core  

```
|                 Method |          Mean |         Error |        StdDev | Ratio |
|----------------------- |--------------:|--------------:|--------------:|------:|
|      CreateBasicMapper |  57,634.60 ns | 2,355.9924 ns | 2,088.5259 ns |  1.00 |
|                        |               |               |               |       |
| CreateCollectionMapper |  17,962.07 ns |   331.3519 ns |   309.9468 ns |  1.00 |
|                        |               |               |               |       |
|   CreateNullableMapper |  28,406.58 ns |   340.5147 ns |   318.5176 ns |  1.00 |
|                        |               |               |               |       |
|  CreateFlattenedMapper |  10,817.81 ns |   211.5554 ns |   267.5498 ns |  1.00 |
|                        |               |               |               |       |
|  CreateParameterMapper |  33,381.58 ns |   415.5904 ns |   388.7435 ns |  1.00 |
|                        |               |               |               |       |
|             GetMapping |      77.56 ns |     0.3246 ns |     0.2711 ns |  1.00 |
|                        |               |               |               |       |
|    GetParameterMapping |      81.21 ns |     0.7809 ns |     0.6096 ns |  1.00 |
|                        |               |               |               |       |
|        RunBasicMapping | 104,317.26 ns |   496.3326 ns |   439.9860 ns |  1.00 |
|                        |               |               |               |       |
|   RunCollectionMapping | 107,850.69 ns |   755.6495 ns |   706.8350 ns |  1.00 |
|                        |               |               |               |       |
|     RunNullableMapping |  73,455.06 ns | 1,482.4786 ns | 1,927.6410 ns |  1.00 |
|                        |               |               |               |       |
|    RunFlattenedMapping |  76,095.23 ns |   740.1539 ns |   618.0621 ns |  1.00 |
|                        |               |               |               |       |
|    RunParameterMapping | 149,590.07 ns | 2,049.5352 ns | 1,917.1365 ns |  1.00 |
