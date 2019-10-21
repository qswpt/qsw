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
            return CacheHelp.Get<string>(key, DateTimeOffset.Now.AddSeconds(3), () => GetExLogisticListSql());
        }
        public string GetExLogisticListSql()
        {
            string sql = "SELECT * FROM ExLogistics";
            var data = DbUtil.Master.QueryList<ExLogisticModel>(sql);
            return JsonUtil.Serialize(data);
        }

        public bool InsertExLogistic(string exName)
        {
            string sql = $"INSERT INTO ExLogistics(ExName) VALUES(?exName)";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["exName"] = exName;
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

        public bool DeleteExLogistic(int exId)
        {
            string sql = $"DELETE FROM ExLogistics WHERE ExId=?exId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["exId"] = exId;
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

        public bool UpdateExLogistic(int exId, string exName)
        {
            string sql = $"UPDATE ExLogistics set ExName=?exName WHERE ExId=?exId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["exId"] = exId;
            p["exName"] = exName;
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
