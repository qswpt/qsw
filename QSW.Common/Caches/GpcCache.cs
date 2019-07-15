using Framework.Common.Utils;
using KJW.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJW.Common.Caches
{
    /// <summary>
    /// 高频彩缓存
    /// </summary>
    public class GpcCache:CacheHelp
    {
        /// <summary>
        /// 设置实时开奖信息
        /// </summary>
        /// <param name="cacheKeyPre"></param>
        /// <param name="realTimeInfoDto"></param>
        /// <param name="absoluteExpiration"></param>
        public static string SetRealTimeDrawInfo(string cacheKeyPre, LotteryRealTimeInfoDto realTimeInfoDto, DateTimeOffset? absoluteExpiration=null,bool isIgnoreNullAndZero=true)
        {
            if (!absoluteExpiration.HasValue)
            {
                absoluteExpiration = DateTimeOffset.Now.AddSeconds(3);
            }

            string jsonRealTime = string.Empty;
            if (isIgnoreNullAndZero)
            {
                jsonRealTime= JsonUtil.SerializeFilterZeroAndNull(realTimeInfoDto);
            }
            else
            {
                jsonRealTime = JsonUtil.Serialize(realTimeInfoDto);
            }
                
            MemoryCacheUtil.Set(cacheKeyPre+"0", jsonRealTime, absoluteExpiration.Value); // 最新开奖的缓存3秒，以便及时取得最新开奖结果
            return jsonRealTime;
        }

        /// <summary>
        /// 获取实时开奖信息
        /// </summary>
        /// <param name="cacheKeyPre"></param>
        /// <returns></returns>
        public static string GetRealTimeDrawInfo(string cacheKeyPre)
        {
            return MemoryCacheUtil.GetString(cacheKeyPre+"0");
        }

        /// <summary>
        /// 今日历史数据缓存
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="periodDrawRecords"></param>
        /// <param name="absoluteExpiration"></param>
        /// <returns></returns>
        public static string SetHistoryDrawInfoToday(string cacheKey, List<PeriodDrawRecordDto> periodDrawRecords, DateTimeOffset? absoluteExpiration = null, bool isIgnoreNullAndZero = true)
        {
            if (!absoluteExpiration.HasValue)
            {
                absoluteExpiration = DateTimeOffset.Now.AddSeconds(3);
            }

            string jsonHistoryDraw = string.Empty;
            if (isIgnoreNullAndZero)
            {
                jsonHistoryDraw = JsonUtil.SerializeFilterZeroAndNull(periodDrawRecords);
            }
            else
            {
                jsonHistoryDraw = JsonUtil.Serialize(periodDrawRecords);
            }

            MemoryCacheUtil.Set(cacheKey, jsonHistoryDraw, absoluteExpiration.Value); // 属于今日期次的缓存3秒
            return jsonHistoryDraw;
        }

        /// <summary>
        /// 非今日历史数据，滑动缓存
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="periodDrawRecords"></param>
        /// <param name="slidingExpiration"></param>
        /// <returns></returns>
        public static string SetHistoryDrawInfoNoToday(string cacheKey, List<PeriodDrawRecordDto> periodDrawRecords, TimeSpan? slidingExpiration=null, bool isIgnoreNullAndZero = true)
        {
            if (!slidingExpiration.HasValue)
            {
                slidingExpiration = TimeSpan.FromMinutes(30);
            }
            
            string jsonHistoryDraw = string.Empty;
            if (isIgnoreNullAndZero)
            {
                jsonHistoryDraw = JsonUtil.SerializeFilterZeroAndNull(periodDrawRecords);
            }
            else
            {
                jsonHistoryDraw = JsonUtil.Serialize(periodDrawRecords);
            }

            MemoryCacheUtil.Set(cacheKey, jsonHistoryDraw, slidingExpiration.Value); 
            return jsonHistoryDraw;
        }

        public static string GetHistoryDrawInfo(string cacheKey)
        {
            return MemoryCacheUtil.GetString(cacheKey);
        }
    }
}
