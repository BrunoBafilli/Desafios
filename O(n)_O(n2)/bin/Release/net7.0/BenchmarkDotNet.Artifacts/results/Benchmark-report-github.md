```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2


```
| Method       | Mean       | Error    | StdDev   |
|------------- |-----------:|---------:|---------:|
| ON           |   988.9 ns | 19.48 ns | 26.01 ns |
| ON2          | 2,015.4 ns |  8.73 ns |  8.16 ns |
| BenchmarkON  | 2,266.0 ns | 43.28 ns | 44.44 ns |
| BenchmarkON2 | 5,811.1 ns | 51.57 ns | 48.23 ns |
