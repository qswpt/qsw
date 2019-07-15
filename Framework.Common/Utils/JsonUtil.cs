using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;

namespace Framework.Common.Utils
{
    public static class JsonUtil
    {
        public static string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public static string SerializeFilterZeroAndNull(object value)
        {
            var jsonSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore };
            return JsonConvert.SerializeObject(value, jsonSetting);
        }

        public static object Deserialize(string value)
        {
            return JsonConvert.DeserializeObject(value);
        }

        public static T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public static T Deserialize<T>(byte[] value)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(value));
        }
    }

    public class DefaultDateFormat : DateTimeFormat
    {
        public DefaultDateFormat() : base("yyyy-MM-dd") { }
    }
    public class DefaultDateTimeFormat : DateTimeFormat
    {
        public DefaultDateTimeFormat() : base("yyyy-MM-dd HH:mm:ss") { }
    }
    public class DateTimeFormat : IsoDateTimeConverter
    {
        public DateTimeFormat(string format) { base.DateTimeFormat = format; }
    }
}
