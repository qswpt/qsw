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

        private string GetAdvListSql()
        {
            string sql = "SELECT * FROM Advertisement ORDER BY AdvSart ASC";
            var data = DbUtil.Master.QueryList<AdvModel>(sql);
            return JsonUtil.Serialize(data);
        }

        public bool InsertAdv(string advModelStr)
        {
            AdvModel model = JsonUtil.Deserialize<AdvModel>(advModelStr);
            string sql = $"INSERT INTO Advertisement(AdvTypeId,AdvInnerId,AdvSart,AdvImage) VALUES(?advTypeId,?advInnerId,?advSart,?advImage)";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["advImage"] = model.AdvImage;
            p["advTypeId"] = model.AdvTypeId;
            p["advInnerId"] = model.AdvInnerId;
            p["advSart"] = model.AdvSart;
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

        public bool DeleteAdv(int advId)
        {
            string sql = $"DELETE FROM Advertisement WHERE AdvId=?advId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["advId"] = advId;
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

        public bool UpdateAdv(int advId, string advModelStr)
        {
            AdvModel model = JsonUtil.Deserialize<AdvModel>(advModelStr);
            string sql = $"UPDATE Advertisement set AdvImage=?advImage,AdvTypeId=?advTypeId,AdvInnerId=?advInnerId,AdvSart=?advSart WHERE AdvId=?advId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["advImage"] = model.AdvImage;
            p["advTypeId"] = model.AdvTypeId;
            p["advInnerId"] = model.AdvInnerId;
            p["advSart"] = model.AdvSart;
            p["advId"] = advId;
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

        public string GetAdvType()
        {
            string key = string.Concat("GetAdvType");
            return CacheHelp.Get<string>(key, DateTimeOffset.Now.AddSeconds(3), () => GetAdvTypeSql());
        }

        private string GetAdvTypeSql()
        {
            string sql = "SELECT * FROM advtype ORDER BY AdvTypeId";
            var data = DbUtil.Master.QueryList<AdvTypeModel>(sql);
            return JsonUtil.Serialize(data);
        }
    }
}
