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
            string sql = $"SELECT * FROM Brand ORDER BY OderSart  LIMIT ?size";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["size"] = size;
            var data = DbUtil.Master.QueryList<BrandModel>(sql, p);
            return JsonUtil.Serialize(data);
        }

        public bool DeleteBrand(int brandId)
        {
            string sql = $"DELETE FROM Brand WHERE BrandId=?brandId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["brandId"] = brandId;
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

        public bool UpdateBrand(int brandId, string brandModeStr)
        {
            var brandModel = JsonUtil.Deserialize<BrandModel>(brandModeStr);
            string sql = $"UPDATE Brand set BrandName=?brandName,BrandTypeId=?brandTypeId,BrandImg=?brandImg,BrandState=?brandState,OderSart=?oderSart WHERE BrandId=?brandId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["brandId"] = brandId;
            p["brandName"] = brandModel.BrandName;
            p["brandImg"] = brandModel.BrandImg;
            p["brandState"] = brandModel.BrandState;
            p["oderSart"] = brandModel.OderSart;
            p["brandTypeId"] = brandModel.BrandTypeId;
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

        public bool InsertBrand(string brandModelStr)
        {
            var brandModel = JsonUtil.Deserialize<BrandModel>(brandModelStr);
            string sql = $"INSERT INTO Brand(BrandName,BrandTypeId,BrandImg,BrandState,OderSart) VALUES(?brandName,?brandTypeId,?brandImg,?brandState,?oderSart)";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["brandName"] = brandModel.BrandName;
            p["brandImg"] = brandModel.BrandImg;
            p["brandState"] = brandModel.BrandState;
            p["oderSart"] = brandModel.OderSart;
            p["brandTypeId"] = brandModel.BrandTypeId;
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
