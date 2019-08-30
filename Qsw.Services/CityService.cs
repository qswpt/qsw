using Framework.Common.Functions;
using Framework.Common.Utils;
using QSW.Common.Caches;
using QSW.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qsw.Services
{
    public class CityService : Singleton<CityService>
    {
        public string GetCityList()
        {
            string key = string.Concat("GetCitList");
            return CacheHelp.Get<string>(key, DateTimeOffset.Now.AddSeconds(3), () => GetCityListSql());
        }
        public string GetCityListSql()
        {
            string sql = "select * from City";
            var data = DbUtil.Master.QueryList<CityModel>(sql);
            return JsonUtil.Serialize(data);
        }

        public bool InsertCity(string cityName)
        {
            string sql = $"INSERT INTO City(CityName) VALUES(?cityName)";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["cityName"] = cityName;
            int num = DbUtil.Master.ExecuteNonQuery(sql, p);
            if (num > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCity(int cityId)
        {
            string sql = $"DELETE FROM City WHERE CityId=?cityId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["cityId"] = cityId;
            int num = DbUtil.Master.ExecuteNonQuery(sql, p);
            if (num > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateCity(int cityId, string cityName)
        {
            string sql = $"UPDATE City set CityName=?cityName WHERE CityId=?cityId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["cityId"] = cityId;
            p["cityName"] = cityName;
            int num = DbUtil.Master.ExecuteNonQuery(sql, p);
            if (num > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
