using Microsoft.Extensions.ObjectPool;
using System.Text;

namespace ConsoleApp3
{
    class SBPoolTest
    {
        private static readonly ObjectPool<StringBuilder> _stringBuilderPool =
              new DefaultObjectPoolProvider().CreateStringBuilderPool(50, 5000);

        private const int capacity = 2_000_000;
        public string GetSB(int i)
        {
            var sb = _stringBuilderPool.Get();
            sb.Clear();
            string s2 = "ddffgg";
            for (int j = 0; j < i; j++)
            {
                sb.AppendLine($"some{j}Stringsome{s2}StringsomeStringsomeString{j}");
            }
            string s = sb.ToString();
            _stringBuilderPool.Return(sb);
            return s;
        } 

        public void Return(StringBuilder sb)
        {
            _stringBuilderPool.Return(sb);
        }
    }
}
