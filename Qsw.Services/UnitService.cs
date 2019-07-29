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
    public class UnitService:Singleton<UnitService>
    {
        public string GetUnit(int size)
        {
            string key = string.Concat("GetUnit", size);
            return CacheHelp.Get<string>(key, DateTimeOffset.Now.AddSeconds(3), () => GetUnitSal(size));
        }
        private string GetUnitSal(int size)
        {
            string sql = $"SELECT * FROM Unit ORDER BY OderSart  LIMIT ?size";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["size"] = size;
            var data = DbUtil.Master.QueryList <UnitModel>(sql, p);
            return JsonUtil.Serialize(data);
        }
    }
}
