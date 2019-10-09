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
    public class CityExLogisticsAmountService : Singleton<CityExLogisticsAmountService>
    {
        public string GetCityExLogisticsAmountList()
        {
            string key = string.Concat("GetCityExLogisticsAmountList");
            return CacheHelp.Get<string>(key, DateTimeOffset.Now.AddSeconds(3), () => GetCityExLogisticsAmountListSql());
        }

        private string GetCityExLogisticsAmountListSql()
        {
            string sql = "SELECT * FROM CityExLogisticsAmount";
            Dictionary<string, object> p = new Dictionary<string, object>();
            var data = DbUtil.Master.QueryList<CityExLogisticsAmountModel>(sql, p);
            return JsonUtil.Serialize(data);
        }

        public string GetCityExLogisticsAmount(int cityId, int exId)
        {
            return GetCityExLogisticsAmountSql(cityId, exId);
        }
        public string GetCityExLogisticsAmountSql(int cityId, int exId)
        {
            string sql = "SELECT * FROM CityExLogisticsAmount WHERE CityId=?cityId AND ExId=?exId OR (CityId=0 AND ExId=?exId) ORDER BY CityId ASC ";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["cityId"] = cityId;
            p["exId"] = exId;
            var data = DbUtil.Master.Query<CityExLogisticsAmountModel>(sql, p);
            return JsonUtil.Serialize(data);
        }

        public bool InsertCityExLogisticsAmount(string cityExLogisticModelStr)
        {
            CityExLogisticsAmountModel model = JsonUtil.Deserialize<CityExLogisticsAmountModel>(cityExLogisticModelStr);
            string sql = $"INSERT INTO CityExLogisticsAmount(CityId,ExId,Amount) VALUES(?cityId,?exId,?amount)";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["cityId"] = model.CityId;
            p["exId"] = model.ExId;
            p["amount"] = model.Amount;
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

        public bool DeleteCityExLogisticsAmount(int id)
        {
            string sql = $"DELETE FROM CityExLogisticsAmount WHERE Id=?id";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["id"] = id;
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

        public bool UpdateCityExLogisticAmount(int id, string cityExLogisticsAmountModelStr)
        {
            CityExLogisticsAmountModel model = JsonUtil.Deserialize<CityExLogisticsAmountModel>(cityExLogisticsAmountModelStr);
            string sql = $"UPDATE CityExLogisticsAmount set CityId=?cityId,ExId=?exId,Amount=?amount WHERE Id=?id";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["cityId"] = model.CityId;
            p["exId"] = model.ExId;
            p["Amount"] = model.Amount;
            p["id"] = id;
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
