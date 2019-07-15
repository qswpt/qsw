using System;
using System.Runtime.Caching;

namespace Framework.Common.Utils
{
    public static class MemoryCacheUtil
    {
        private static MemoryCache _cache = MemoryCache.Default;

        public static string GetString(string key)
        {
            return ConvertUtil.ToString(_cache[key], null);
        }

        public static int GetInt(string key, int defaultValue)
        {
            return ConvertUtil.ToInt(_cache[key], defaultValue);
        }

        public static DateTime GetDateTime(string key, DateTime defaultValue)
        {
            return ConvertUtil.ToDateTime(_cache[key], defaultValue);
        }

        public static T Get<T>(string key)
        {
            return (T)_cache.Get(key);
        }

        public static void Set(string key, object value)
        {
            _cache.Set(key, value, DateTimeOffset.MaxValue);
        }

        public static void Set(string key, object value, DateTimeOffset absoluteExpiration)
        {
            _cache.Set(key, value, absoluteExpiration);
        }

        public static void Set(string key, object value, TimeSpan slidingExpiration)
        {
            _cache.Set(key, value, new CacheItemPolicy() { SlidingExpiration = slidingExpiration });
        }

        public static void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}