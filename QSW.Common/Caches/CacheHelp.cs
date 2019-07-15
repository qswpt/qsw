using Framework.Common.Utils;
using System;

namespace QSW.Common.Caches
{
    public class CacheHelp
    {
        public static T Get<T>(string key, Func<T> fetch)
        {
            T result = MemoryCacheUtil.Get<T>(key);
            if (result == null)
            {
                result = fetch();
                if (result != null)
                {
                    MemoryCacheUtil.Set(key, result);
                }
            }
            return result;
        }

        public static T Get<T>(string key, DateTimeOffset? absoluteExpiration, Func<T> fetch)
        {
            T result = MemoryCacheUtil.Get<T>(key);
            if (result == null)
            {
                result = fetch();
                if (result != null)
                {
                    if (!absoluteExpiration.HasValue)
                    {
                        absoluteExpiration = DateTimeOffset.Now.AddSeconds(3);
                    }
                    MemoryCacheUtil.Set(key, result, absoluteExpiration.Value);
                }
            }
            return result;
        }
        public static bool Set(string key, DateTimeOffset? absoluteExpiration, object obj)
        {
            bool isok = false;
            if (obj != null)
            {
                if (!absoluteExpiration.HasValue)
                {
                    absoluteExpiration = DateTimeOffset.Now.AddSeconds(3);
                }
                MemoryCacheUtil.Set(key, obj, absoluteExpiration.Value);
                isok = true;
            }
            return isok;
        }

        public static T Get<T>(string key, TimeSpan? slidingExpiration, Func<T> fetch)
        {
            T result = MemoryCacheUtil.Get<T>(key);
            if (result == null)
            {
                result = fetch();
                if (result != null)
                {
                    if (!slidingExpiration.HasValue)
                    {
                        slidingExpiration = TimeSpan.FromMinutes(30);
                    }
                    MemoryCacheUtil.Set(key, result, slidingExpiration.Value);
                }
            }
            return result;
        }
    }
}