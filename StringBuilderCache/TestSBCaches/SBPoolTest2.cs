

using Microsoft.Extensions.ObjectPool;
using System.Text;

namespace ConsoleApp3
{
    class SBPoolTest2
    {


        public string GetSBFromPool(int i, ObjectPool<StringBuilder> _sbPool)
        {
            var sb = _sbPool.Get();
            try
            {
                string s2 = "ddffgg";
                for (int j = 0; j < i; j++)
                {
                    sb.AppendLine($"some{j}Stringsome{s2}StringsomeStringsomeString{j}");
                }
                return sb.ToString();
            }
            finally
            {
                _sbPool.Return(sb);
            }
        }

        public string GetSBCache(int i)
        {
            var sb = SBCache.Allocate();
            string s2 = "ddffgg";
            for (int j = 0; j < i; j++)
            {
                sb.AppendLine($"some{j}Stringsome{s2}StringsomeStringsomeString{j}");
            }
            return SBCache.ReturnAndFree(sb);
        }

        public string GetSBCacheSingle(int i)
        {
            var sb = StringBuilderCache.Allocate();
            string s2 = "ddffgg";
            for (int j = 0; j < i; j++)
            {
                sb.AppendLine($"some{j}Stringsome{s2}StringsomeStringsomeString{j}");
            }
            return StringBuilderCache.ReturnAndFree(sb);
        }
    }
}
