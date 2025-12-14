
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ConsoleApp3;
using Microsoft.Extensions.ObjectPool;
using System.Text;

public class Solution
{
    public class Program
    {
        [MemoryDiagnoser]
        public class Test
        {
            private const int stepCount = 10;
            private const int iterations = 20;
            internal static ObjectPool<StringBuilder> _sbPool;
            
            [Benchmark]
            public void TestSB()
            {
                for (int i = 0; i < iterations; i++)
                {
                    var sb = new SBTest();
                    _ = sb.GetSB(stepCount);
                }
            }
             
            //[Benchmark]
            public void TestSBPool()
            {
                for (int i = 0; i < iterations; i++)
                {
                    var sb = new SBPoolTest2();
                    _ = sb.GetSBFromPool(stepCount, _sbPool);
                }
            }

            [Benchmark]
            public void TestCachePool()
            {
                for (int i = 0; i < iterations; i++)
                {
                    var sb = new SBPoolTest2();
                    _ = sb.GetSBCache(stepCount);
                }
            }

           // [Benchmark]
            public void TestCachePoolSingle()
            {
                for (int i = 0; i < iterations; i++)
                {
                    var sb = new SBPoolTest2();
                    _ = sb.GetSBCacheSingle(stepCount);
                }
            }

           // [Benchmark]
            public void TestValuePool()
            {
                for (int i = 0; i < iterations; i++)
                {
                    var sb = new SBVTest();
                    _ = sb.GetSB2(stepCount);
                }
            }

            [GlobalSetup]
            public void Init()
            {
                //DefaultObjectPoolProvider d = new DefaultObjectPoolProvider();
                _sbPool ??= new DefaultObjectPoolProvider().CreateStringBuilderPool(50, 5000); ;
            }
        }


        public static void Main()
        {
           
            var summary = BenchmarkRunner.Run<Test>();
            //var sb = new SBPoolTest2();
            //_ = sb.GetSB(10);
            //_ = sb.GetSB(20);
        }
    }
}