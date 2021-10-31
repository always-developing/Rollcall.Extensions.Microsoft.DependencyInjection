using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using System.Threading.Tasks;

namespace Rollcall.Benchmark
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var config = ManualConfig.Create(DefaultConfig.Instance)
                 .WithOption(ConfigOptions.JoinSummary, true);

            BenchmarkRunner.Run(new[]{
                BenchmarkConverter.TypeToBenchmarks( typeof(EnumerableBenchmarks), config),
                BenchmarkConverter.TypeToBenchmarks( typeof(FactoryBenchmark), config),
                BenchmarkConverter.TypeToBenchmarks( typeof(DelegateBenchmark), config),
                BenchmarkConverter.TypeToBenchmarks( typeof(DistinctBenchmark), config),
                BenchmarkConverter.TypeToBenchmarks( typeof(RollcallBenchmarks), config),
                BenchmarkConverter.TypeToBenchmarks( typeof(RollcallFuncBenchmarks), config),
            });
        }

        
    }
}
