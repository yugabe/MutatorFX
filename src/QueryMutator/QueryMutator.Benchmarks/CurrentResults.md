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
|      CreateBasicMapper |  36,237.00 ns |   251.9222 ns |   235.6481 ns |  1.00 |
|                        |               |               |               |       |
| CreateCollectionMapper |  18,384.07 ns |   393.8286 ns |   657.9991 ns |  1.00 |
|                        |               |               |               |       |
|   CreateNullableMapper |  43,331.38 ns |   570.9065 ns |   534.0263 ns |  1.00 |
|                        |               |               |               |       |
|  CreateFlattenedMapper |  11,223.29 ns |   180.9816 ns |   160.4354 ns |  1.00 |
|                        |               |               |               |       |
|  CreateParameterMapper |  31,172.46 ns |   247.7159 ns |   231.7136 ns |  1.00 |
|                        |               |               |               |       |
|             GetMapping |      56.57 ns |     1.0286 ns |     0.9622 ns |  1.00 |
|                        |               |               |               |       |
|    GetParameterMapping |      65.46 ns |     0.5209 ns |     0.4873 ns |  1.00 |
|                        |               |               |               |       |
|        RunBasicMapping | 104,185.34 ns |   268.2453 ns |   237.7925 ns |  1.00 |
|                        |               |               |               |       |
|   RunCollectionMapping | 109,955.65 ns | 2,127.2594 ns | 2,184.5388 ns |  1.00 |
|                        |               |               |               |       |
|     RunNullableMapping |  73,228.42 ns | 1,453.1351 ns | 1,492.2628 ns |  1.00 |
|                        |               |               |               |       |
|    RunFlattenedMapping |  76,273.82 ns |   309.6206 ns |   258.5472 ns |  1.00 |
|                        |               |               |               |       |
|    RunParameterMapping | 147,561.06 ns |   724.8682 ns |   565.9294 ns |  1.00 |
