using Framework.Common.Functions;
using Framework.Common.Utils;
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
        public string GetCityExLogisticsAmount(int cityId, int exId)
        {
            return GetCityExLogisticsAmountSql(cityId, exId);
        }
        public string GetCityExLogisticsAmountSql(int cityId, int exId)
        {
            string sql = "SELECT * FROM CityExLogisticsAmount WHERE CityId=?cityId AND ExId=?exId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["cityId"] = cityId;
            p["exId"] = exId;
            var data = DbUtil.Master.Query<CityExLogisticsAmountModel>(sql,p);
            return JsonUtil.Serialize(data);
        }
    }
}
