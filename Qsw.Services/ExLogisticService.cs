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
    public class ExLogisticService : Singleton<ExLogisticService>
    {
        public string GetExLogisticList()
        {
            string key = string.Concat("GetExLogisticList");
            return CacheHelp.Get<string>(key, DateTimeOffset.Now.AddDays(1), () => GetExLogisticListSql());
        }
        public string GetExLogisticListSql()
        {
            string sql = "SELECT * FROM ExLogistics";
            var data = DbUtil.Master.QueryList<ExLogisticModel>(sql);
            return JsonUtil.Serialize(data);
        }
    }
}
