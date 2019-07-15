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
    public class CommodityService : Singleton<CommodityService>
    {
        #region 获取热门商品
        public string GetCommodityList(int index = 1, int size = 10)
        {
            string key = string.Concat("GetCommodityList", index, size);
            return CacheHelp.Get<string>(key, DateTimeOffset.Now.AddSeconds(3), () => GetCommodityListSql(index, size));
        }
        private string GetCommodityListSql(int index, int size)
        {
            string sql = $"SELECT a.*,b.BrandName,c.UnitIdName,d.TypeName FROM Commodity a LEFT JOIN Brand b ON a.CommodityBrandId=b.BrandId LEFT " +                         $"JOIN Unit c ON a.CommodityUnitId=c.UnitIdId LEFT JOIN CommodityType d ON a.CommodityFamilyId=d.TypeId WHERE a.CommodityState= 0 " +
                         $"ORDER BY a.CommodityHOT ASC LIMIT ?index,?size";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["index"] = (index - 1) * size;
            p["size"] = size;
            var data = DbUtil.Master.QueryList<CommodityModel>(sql, p);
            return JsonUtil.Serialize(data);
        }
        #endregion
        #region 根据品牌ID查找商品
        public string GetCommodityByBrand(int brandId, int index = 1, int size = 10)
        {
            string key = string.Concat("GetCommodityByBrand", brandId, index, size);
            return CacheHelp.Get<string>(key, DateTimeOffset.Now.AddSeconds(3), () => GetCommodityByBrandIdSql(brandId, index, size));
        }
        private string GetCommodityByBrandIdSql(int brandId, int index, int size)
        {
            string sql = $"SELECT a.*,b.BrandName,c.UnitIdName,d.TypeName FROM Commodity a LEFT JOIN Brand b ON a.CommodityBrandId=b.BrandId LEFT " +
                        $"JOIN Unit c ON a.CommodityUnitId=c.UnitIdId LEFT JOIN CommodityType d ON a.CommodityFamilyId=d.TypeId WHERE a.CommodityState= 0 AND " +
                        $"a.CommodityBrandId=?commodityBrandId ORDER BY a.CommodityHOT ASC LIMIT ?index,?size";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["index"] = (index - 1) * size;
            p["size"] = size;
            p["commodityBrandId"] = brandId;
            var data = DbUtil.Master.QueryList<CommodityModel>(sql, p);
            return JsonUtil.Serialize(data);
        }
        #endregion
        #region 根据分类查找商品
        public string GetCommodityFamily(int familyId, int index = 1, int size = 10)
        {
            string key = string.Concat("GetCommodityFamily", familyId, index, size);
            return CacheHelp.Get<string>(key, DateTimeOffset.Now.AddSeconds(3), () => GetCommodityByFamilyIdSql(familyId, index, size));
        }
        private string GetCommodityByFamilyIdSql(int familyId, int index, int size)
        {
            string sql = $"SELECT a.*,b.BrandName,c.UnitIdName,d.TypeName FROM Commodity a LEFT JOIN Brand b ON a.CommodityBrandId=b.BrandId LEFT " +
                        $"JOIN Unit c ON a.CommodityUnitId=c.UnitIdId LEFT JOIN CommodityType d ON a.CommodityFamilyId=d.TypeId WHERE a.CommodityState= 0 AND " +
                        $"a.CommodityFamilyId=?commodityFamilyId ORDER BY a.CommodityHOT ASC LIMIT ?index,?size";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["index"] = (index - 1) * size;
            p["size"] = size;
            p["commodityFamilyId"] = familyId;
            var data = DbUtil.Master.QueryList<CommodityModel>(sql, p);
            return JsonUtil.Serialize(data);
        }
        #endregion
        #region 获取指定商品信息
        public string GetCommodityInfo(int id)
        {
            string key = string.Concat("GetCommodityInfo", id);
            return CacheHelp.Get<string>(key, DateTimeOffset.Now.AddSeconds(3), () => GetCommodityByInfoSql(id));
        }
        private string GetCommodityByInfoSql(int id)
        {
            string sql = $"SELECT a.*,b.BrandName,c.UnitIdName,d.TypeName FROM Commodity a LEFT JOIN Brand b ON a.CommodityBrandId=b.BrandId LEFT " +
                        $"JOIN Unit c ON a.CommodityUnitId=c.UnitIdId LEFT JOIN CommodityType d ON a.CommodityFamilyId=d.TypeId WHERE " +
                        $"a.CommodityId=?commodityId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["commodityId"] = id;
            var data = DbUtil.Master.Query<CommodityModel>(sql, p);
            return JsonUtil.Serialize(data);
        }
        #endregion
        #region
        public string SetShopping(string token, int shpId)
        {
            CommodityModel cm = new CommodityModel();
            cm.CommodityId = shpId;
            cm.SpCount++;
            string key = string.Concat(token, "SetShopping");
            var uComList = CacheHelp.Get<List<CommodityModel>>(key, DateTimeOffset.Now.AddMonths(3), () => null);
            if (uComList == null)
            {
                uComList = new List<CommodityModel>();
            }
            var um = uComList.Find(o => o.CommodityId == shpId);
            if (um == null)
                uComList.Add(cm);
            else
                um.SpCount++;
            var state = CacheHelp.Set(key, DateTimeOffset.Now.AddMonths(3), uComList);
            ReturnModel re = new ReturnModel();
            if (state)
            {
                re.state = true;
                re.rcount = uComList.Count;
            }
            return JsonUtil.Serialize(re);
        }
        public string GetShoppingList(string token)
        {
            string key = string.Concat(token, "SetShopping");
            var uComList = CacheHelp.Get<List<CommodityModel>>(key, DateTimeOffset.Now.AddMonths(3), () => null);
            return JsonUtil.Serialize(uComList);
        }
        public string GetShoppingCount(string token)
        {
            string key = string.Concat(token, "SetShopping");
            var uComList = CacheHelp.Get<List<CommodityModel>>(key, DateTimeOffset.Now.AddMonths(3), () => null);
            ReturnModel re = new ReturnModel();
            re.state = true;
            if (uComList != null)
            {
                re.rcount = uComList.Count;
            }
            return JsonUtil.Serialize(re);
        }
        #endregion
    }
}
