using System.Text;

namespace ConsoleApp3
{

    internal static class StringBuilderCache
    {
        [ThreadStatic]
        static StringBuilder? cache;

        public static StringBuilder Allocate()
        {
            var ret = cache;
            if (ret == null)
                return new StringBuilder();

            ret.Length = 0;
            cache = null;  //don't re-issue cached instance until it's freed
            return ret;
        }

        public static void Free(StringBuilder sb)
        {
            cache = sb;
        }

        public static string ReturnAndFree(StringBuilder sb)
        {
            var ret = sb.ToString();
            cache = sb;
            return ret;
        }
    }

    public static class SBCache
    {
        private const int MaxCacheSize = 10;

        [ThreadStatic]
        static Stack<StringBuilder>? _cache;
        [ThreadStatic]
        static bool _cacheInitialized;

        public static StringBuilder Allocate()
        {
            EnsureInitilized();
            if (!(_cache!.TryPop(out var ret)))
            {
                return new StringBuilder();
            }
            return ret;
        }

        public static void Free(StringBuilder sb)
        {
            EnsureInitilized();
            if (_cache!.Count < MaxCacheSize)
            {
                _cache.Push(sb);
            }
           sb.Length = 0;
        }

        public static string ReturnAndFree(StringBuilder sb)
        {
            try
            {
                return sb.ToString();
            }
            finally
            {
                Free(sb);
            }
        }

        private static void EnsureInitilized()
        {
            if (!_cacheInitialized)
            {
                _cache = new();
                _cacheInitialized = true;
            }
        }
    }
}
