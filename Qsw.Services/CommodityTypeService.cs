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
    public class CommodityTypeService : Singleton<CommodityTypeService>
    {
        public string GetCommodityType(int size)
        {
            string key = string.Concat("GetCommodityType", size);
            return CacheHelp.Get<string>(key, DateTimeOffset.Now.AddSeconds(3), () => GetBrandHomeSal(size));
        }
        private string GetBrandHomeSal(int size)
        {
            string sql = "SELECT * FROM CommodityType ORDER BY OderSart  LIMIT ?size";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["size"] = size;
            var data = DbUtil.Master.QueryList<CommodityTypeModel>(sql, p);
            return JsonUtil.Serialize(data);
        }

        public bool DeleteCommodityType(int typeId)
        {
            string sql = "DELETE FROM CommodityType WHERE TypeId=?TypeId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["TypeId"] = typeId;
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

        public bool UpdateCommodityType(int typeId, string commodityTypeModelStr)
        {
            var commodityTypeModel = JsonUtil.Deserialize<CommodityTypeModel>(commodityTypeModelStr);
            string sql = $"UPDATE CommodityType set TypeName=?TypeName,OderSart=?OderSart WHERE TypeId=?TypeId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["TypeId"] = typeId;
            p["TypeName"] = commodityTypeModel.TypeName;
            p["OderSart"] = commodityTypeModel.OderSart;
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

        public bool InsertCommodityType(string commodityTypeModelStr)
        {
            var commodityTypeModel = JsonUtil.Deserialize<CommodityTypeModel>(commodityTypeModelStr);
            string sql = $"INSERT INTO CommodityType VALUES(?TypeName,?OderSart)";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["TypeName"] = commodityTypeModel.TypeName;
            p["OderSart"] = commodityTypeModel.OderSart;
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
