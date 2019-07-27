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
            string sql = $"SELECT a.*,b.BrandName,c.UnitIdName,d.TypeName FROM Commodity a LEFT JOIN Brand b ON a.CommodityBrandId=b.BrandId LEFT " +
                         $"JOIN Unit c ON a.CommodityUnitId=c.UnitIdId LEFT JOIN CommodityType d ON a.CommodityFamilyId=d.TypeId WHERE a.CommodityState= 0 " +
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
            var data = GetComInfo(id);
            return JsonUtil.Serialize(data);
        }
        private CommodityModel GetComInfo(int id)
        {
            string sql = $"SELECT a.*,b.BrandName,c.UnitIdName,d.TypeName FROM Commodity a LEFT JOIN Brand b ON a.CommodityBrandId=b.BrandId LEFT " +
                       $"JOIN Unit c ON a.CommodityUnitId=c.UnitIdId LEFT JOIN CommodityType d ON a.CommodityFamilyId=d.TypeId WHERE " +
                       $"a.CommodityId=?commodityId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["commodityId"] = id;
            var data = DbUtil.Master.Query<CommodityModel>(sql, p);
            return data;
        }
        #endregion
        #region
        public string SetShopping(string token, int shpId)
        {
            string key = string.Concat(token, "SetShopping");
            var uComList = CacheHelp.Get<List<CommodityModel>>(key, DateTimeOffset.Now.AddMonths(3), () => null);
            if (uComList == null)
            {
                uComList = new List<CommodityModel>();
            }
            var um = uComList.Find(o => o.CommodityId == shpId);
            if (um == null)
            {
                CommodityModel cm = GetComInfo(shpId);
                if (cm != null)
                {
                    cm.SpCount++;
                    uComList.Add(cm);
                }
            }
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
        public string SetShoppingCount(string token, int shpId, int spCount)
        {
            string key = string.Concat(token, "SetShopping");
            var uComList = CacheHelp.Get<List<CommodityModel>>(key, DateTimeOffset.Now.AddMonths(3), () => null);
            if (uComList == null)
            {
                uComList = new List<CommodityModel>();
            }
            var um = uComList.Find(o => o.CommodityId == shpId);
            if (um == null)
            {
                CommodityModel cm = GetComInfo(shpId);
                if (cm != null)
                {
                    cm.SpCount = spCount;
                    uComList.Add(cm);
                }
            }
            else
                um.SpCount = spCount;
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
        public string DeleteShopping(string idStr, string token)
        {
            string key = string.Concat(token, "SetShopping");
            var uComList = CacheHelp.Get<List<CommodityModel>>(key, DateTimeOffset.Now.AddMonths(3), () => null);
            if (!string.IsNullOrEmpty(idStr) && uComList != null && uComList.Count > 0)
            {
                List<int> idList = new List<int>(idStr.Split(',').Select(x => int.Parse(x)));
                foreach (var id in idList)  //移除购物车商品
                {
                    var item = uComList.Find(o => o.CommodityId == id);
                    if (item != null)
                    {
                        uComList.Remove(item);
                    }
                }
                CacheHelp.Set(key, DateTimeOffset.Now.AddMonths(3), uComList);
            }
            return JsonUtil.Serialize(uComList);
        }
        public string DeleteAllShopping(string token)
        {
            string key = string.Concat(token, "SetShopping");
            var uComList = CacheHelp.Get<List<CommodityModel>>(key, DateTimeOffset.Now.AddMonths(3), () => null);
            if (uComList != null && uComList.Count > 0)
                uComList.Clear();
            CacheHelp.Set(key, DateTimeOffset.Now.AddMonths(3), uComList);
            return JsonUtil.Serialize(uComList);
        }
        #endregion

        public bool DeleteCommodityById(int id)
        {
            string sql = $"DELETE FROM Commodity WHERE CommodityId = ?id";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["id"] = id;
            int res = DbUtil.Master.ExecuteNonQuery(sql, p);
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateCommodity(int commodityId, string commodityModelStr)
        {
            var commodityModel = JsonUtil.Deserialize<CommodityModel>(commodityModelStr);
            string sql = $"UPDATE Commodity set CommodityName=?CommodityName,CommodityImg=?CommodityImg," +
                        $"CommodityGeneral=?CommodityGeneral,CommodityPrice=?CommodityPrice," +
                        $"CommodityUnitId=?CommodityUnitId,CommoditySpec=?CommoditySpec," +
                        $"CommodityBrandId=?CommodityBrandId,CommodityFamilyId=?CommodityFamilyId" +
                        $"CommodityIndex=?CommodityIndex,CommodityCode=?CommodityCode,CommodityState=?CommodityState" +
                        $"CommodityHOT=?CommodityHOT,CommodityRH=?CommodityRH,CommodityRM=?CommodityRM," +
                        $"CommodityFL=?CommodityFL,CommodityRemark=?CommodityRemark" +
                        $"WHERE CommodityId=?commodityId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["CommodityId"] = commodityModel.CommodityId;
            p["CommodityName"] = commodityModel.CommodityName;
            p["CommodityImg"] = commodityModel.CommodityImg;
            p["CommodityGeneral"] = commodityModel.CommodityGeneral;
            p["CommodityPrice"] = commodityModel.CommodityPrice;
            p["CommodityUnitId"] = commodityModel.CommodityUnitId;
            p["CommoditySpec"] = commodityModel.CommoditySpec;
            p["CommodityBrandId"] = commodityModel.CommodityBrandId;
            p["CommodityFamilyId"] = commodityModel.CommodityFamilyId;
            p["CommodityIndex"] = commodityModel.CommodityIndex;
            p["CommodityCode"] = commodityModel.CommodityCode;
            p["CommodityState"] = 0;
            p["CommodityHOT"] = commodityModel.CommodityHOT;
            p["CommodityRH"] = commodityModel.CommodityRH;
            p["CommodityRM"] = commodityModel.CommodityRM;
            p["CommodityFL"] = commodityModel.CommodityFL;
            p["CommodityRemark"] = commodityModel.CommodityRemark;
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

        public bool InsertCommodity(string commodityModelStr)
        {
            var commodityModel = JsonUtil.Deserialize<CommodityModel>(commodityModelStr);
            string sql = $"INSERT INTO Commodity VALUES(?CommodityName,?CommodityImg,?CommodityGeneral," +
                        $"?CommodityPrice,?CommodityUnitId,?CommoditySpec,?CommodityBrandId,?CommodityFamilyId," +
                        $"?CommodityIndex,?CommodityCode,?CommodityState,?CommodityHOT,?CommodityRH,?CommodityRM" +
                        $"?CommodityFL,?CommodityRemark)";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["CommodityName"] = commodityModel.CommodityName;
            p["CommodityImg"] = commodityModel.CommodityImg;
            p["CommodityGeneral"] = commodityModel.CommodityGeneral;
            p["CommodityPrice"] = commodityModel.CommodityPrice;
            p["CommodityUnitId"] = commodityModel.CommodityUnitId;
            p["CommoditySpec"] = commodityModel.CommoditySpec;
            p["CommodityBrandId"] = commodityModel.CommodityBrandId;
            p["CommodityFamilyId"] = commodityModel.CommodityFamilyId;
            p["CommodityIndex"] = commodityModel.CommodityIndex;
            p["CommodityCode"] = commodityModel.CommodityCode;
            p["CommodityState"] = 0;
            p["CommodityHOT"] = commodityModel.CommodityHOT;
            p["CommodityRH"] = commodityModel.CommodityRH;
            p["CommodityRM"] = commodityModel.CommodityRM;
            p["CommodityFL"] = commodityModel.CommodityFL;
            p["CommodityRemark"] = commodityModel.CommodityRemark;
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
