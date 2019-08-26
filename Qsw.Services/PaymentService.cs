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
    public class PaymentService : Singleton<PaymentService>
    {
        public string GetPayList()
        {
            string key = string.Concat("GetPayListe");
            return CacheHelp.Get<string>(key, DateTimeOffset.Now.AddDays(1), () => GetPayListSql());
        }
        public string GetPayListSql()
        {
            string sql = "SELECT * FROM PaymentType";
            var data = DbUtil.Master.QueryList<PaymentModel>(sql);
            return JsonUtil.Serialize(data);
        }
    }
}
