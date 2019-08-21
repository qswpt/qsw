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
    }
}
