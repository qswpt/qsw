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
    public class AdvService : Singleton<AdvService>
    {
        public string GetAdvList()
        {
            string key = string.Concat("GetAdvList");
            return CacheHelp.Get<string>(key, DateTimeOffset.Now.AddSeconds(3), () => GetAdvListSql());
        }
        public string GetAdvListSql()
        {
            string sql = "SELECT * FROM Advertisement ORDER BY AdvSart ASC";
            var data = DbUtil.Master.QueryList<AdvModel>(sql);
            return JsonUtil.Serialize(data);
        }
    }
}
