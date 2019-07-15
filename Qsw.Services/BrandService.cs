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
    public class BrandService : Singleton<BrandService>
    {
        public string GetBrandHome(int size)
        {
            string key = string.Concat("GetBrandHome", size);
            return CacheHelp.Get<string>(key, DateTimeOffset.Now.AddSeconds(3), () => GetBrandHomeSal(size));
        }
        private string GetBrandHomeSal(int size)
        {
            string sql = "SELECT * FROM Brand ORDER BY OderSart  LIMIT ?size";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["size"] = size;
            var data = DbUtil.Master.QueryList<BrandModel>(sql, p);
            return JsonUtil.Serialize(data);
        }
    }
}
