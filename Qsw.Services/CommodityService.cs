using Framework.Common.Functions;
using Framework.Common.Utils;
using QSW.Common.Caches;
using QSW.Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            string sql = $"SELECT a.*,b.BrandName,c.UnitIdName,d.TypeName FROM Commodity a LEFT JOIN Brand b ON a.CommodityBrandId=b.BrandId LEFT " +                         $"JOIN Unit c ON a.CommodityUnitId=c.UnitIdId LEFT JOIN CommodityType d ON a.CommodityFamilyId=d.TypeId WHERE a.CommodityState= 0 AND a.CommoditySuper=1 " +
                         $"ORDER BY a.CommodityHOT ASC LIMIT ?index,?size";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["index"] = (index - 1) * size;
            p["size"] = size;
            var data = DbUtil.Master.QueryList<CommodityModel>(sql, p);
            return JsonUtil.Serialize(data);
        }
        public string GetCommodityAllList()
        {
            string key = string.Concat("GetCommodityAllList");
            return CacheHelp.Get<string>(key, DateTimeOffset.Now.AddSeconds(3), () => GetCommodityAllSql());
        }
        private string GetCommodityAllSql()
        {
            string sql = $"SELECT a.*,b.BrandName,c.UnitIdName,d.TypeName FROM Commodity a LEFT JOIN Brand b ON a.CommodityBrandId=b.BrandId LEFT " +                         $"JOIN Unit c ON a.CommodityUnitId=c.UnitIdId LEFT JOIN CommodityType d ON a.CommodityFamilyId=d.TypeId WHERE a.CommodityState=0 " +
                         $"ORDER BY a.CommodityHOT ASC";
            var data = DbUtil.Master.QueryList<CommodityModel>(sql);
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
        #region 搜索
        public string GetCommoditySearch(string searchTxt, string token)
        {
            string key = string.Concat("GetCommoditySearch", searchTxt);
            return CacheHelp.Get<string>(key, DateTimeOffset.Now.AddSeconds(3), () => GetCommoditySearchSql(searchTxt, token));
        }
        private string GetCommoditySearchSql(string searchTxt, string token)
        {
            SearchDtlService.Instance.InsertSearch(token, searchTxt, 0);
            string sql = $"SELECT a.*,b.BrandName,c.UnitIdName,d.TypeName FROM Commodity a LEFT JOIN Brand b ON a.CommodityBrandId=b.BrandId LEFT " +
                         $"JOIN Unit c ON a.CommodityUnitId = c.UnitIdId LEFT JOIN CommodityType d ON a.CommodityFamilyId = d.TypeId " +
                         $" WHERE a.CommodityName like '%{searchTxt}%' OR a.CommodityIndex like '%{searchTxt}%' OR b.BrandName like '%{searchTxt}%'";
            var data = DbUtil.Master.QueryList<CommodityModel>(sql);
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
        #region 购物车缓存
        public string SetShopping(string token, int shpId, int spCount)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                string key = string.Concat(user.UserName, "SetShopping");
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
                        cm.SpCount = spCount > 0 ? spCount : 1;
                        uComList.Add(cm);
                    }
                }
                else
                {
                    var sumCount = spCount > 0 ? spCount : 1;
                    um.SpCount = um.SpCount + sumCount;
                }
                var state = CacheHelp.Set(key, DateTimeOffset.Now.AddMonths(3), uComList);
                ReturnModel re = new ReturnModel();
                if (state)
                {
                    re.state = true;
                    re.rcount = uComList.Count;
                }
                return JsonUtil.Serialize(re);
            }
            else
            {
                return UserService.ckTokenState();
            }
        }
        public string SetShoppingCount(string token, int shpId, int spCount)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                string key = string.Concat(user.UserName, "SetShopping");
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
            else
            {
                return UserService.ckTokenState();
            }
        }
        public string GetShoppingList(string token)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                string key = string.Concat(user.UserName, "SetShopping");
                var uComList = CacheHelp.Get<List<CommodityModel>>(key, DateTimeOffset.Now.AddMonths(3), () => null);
                return JsonUtil.Serialize(uComList);
            }
            else
            {
                return UserService.ckTokenState();
            }
        }
        public string GetShoppingCount(string token)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                string key = string.Concat(user.UserName, "SetShopping");
                var uComList = CacheHelp.Get<List<CommodityModel>>(key, DateTimeOffset.Now.AddMonths(3), () => null);
                ReturnModel re = new ReturnModel();
                re.state = true;
                if (uComList != null)
                {
                    re.rcount = uComList.Count;
                }
                return JsonUtil.Serialize(re);
            }
            else
            {
                return UserService.ckTokenState();
            }
        }
        public string DeleteShopping(string idStr, string token)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                string key = string.Concat(user.UserName, "SetShopping");
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
            else
            {
                return UserService.ckTokenState();
            }
        }
        public string DeleteAllShopping(string token)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                string key = string.Concat(user.UserName, "SetShopping");
                var uComList = CacheHelp.Get<List<CommodityModel>>(key, DateTimeOffset.Now.AddMonths(3), () => null);
                if (uComList != null && uComList.Count > 0)
                    uComList.Clear();
                CacheHelp.Set(key, DateTimeOffset.Now.AddMonths(3), uComList);
                return JsonUtil.Serialize(uComList);
            }
            else
            {
                return UserService.ckTokenState();
            }
        }
        /// <summary>
        /// 获取指定购物车商品
        /// </summary>
        /// <param name="token"></param>
        /// <param name="spId"></param>
        /// <returns></returns>
        public string GetShoppingInId(string token, string spId)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                List<CommodityModel> tmpList = new List<CommodityModel>();
                if (!string.IsNullOrEmpty(spId))
                {
                    var idList = new List<int>(spId.Split(',').Select(x => int.Parse(x)));
                    string key = string.Concat(user.UserName, "SetShopping");
                    var uComList = CacheHelp.Get<List<CommodityModel>>(key, DateTimeOffset.Now.AddMonths(3), () => null);
                    if (uComList.Count > 0)
                    {
                        foreach (var id in idList)
                        {
                            var tmpdata = uComList.Find(o => o.CommodityId == id);
                            if (tmpdata != null)
                            {
                                tmpList.Add(tmpdata);
                            }
                        }
                    }
                }
                return JsonUtil.Serialize(tmpList);
            }
            else
            {
                return UserService.ckTokenState();
            }
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
            string sql = $"UPDATE Commodity SET CommodityName=?commodityName,CommodityImg=?commodityImg," +
                        $"CommodityGeneral=?commodityGeneral,CommodityPrice=?commodityPrice," +
                        $"CommodityUnitId=?commodityUnitId,CommoditySpec=?commoditySpec," +
                        $"CommodityBrandId=?commodityBrandId,CommodityFamilyId=?commodityFamilyId," +
                        $"CommodityIndex=?commodityIndex,CommodityCode=?commodityCode,CommodityState=?commodityState," +
                        $"CommodityHOT=?commodityHOT,CommodityRH=?commodityRH,CommodityRM=?commodityRM," +
                        $"CommodityFL=?commodityFL,CommoditySuper=?commoditySuper " +
                        $" WHERE CommodityId=?commodityId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["commodityId"] = commodityModel.CommodityId;
            p["commodityName"] = commodityModel.CommodityName;
            p["commodityImg"] = commodityModel.CommodityImg;
            p["commodityGeneral"] = commodityModel.CommodityGeneral;
            p["commodityPrice"] = commodityModel.CommodityPrice;
            p["commodityUnitId"] = commodityModel.CommodityUnitId;
            p["commoditySpec"] = commodityModel.CommoditySpec;
            p["commodityBrandId"] = commodityModel.CommodityBrandId;
            p["commodityFamilyId"] = commodityModel.CommodityFamilyId;
            p["commodityIndex"] = commodityModel.CommodityIndex;
            p["commodityCode"] = commodityModel.CommodityCode;
            p["commodityState"] = 0;
            p["commodityHOT"] = commodityModel.CommodityHOT;
            p["commodityRH"] = commodityModel.CommodityRH;
            p["commodityRM"] = commodityModel.CommodityRM;
            p["commodityFL"] = commodityModel.CommodityFL;
            p["commoditySuper"] = commodityModel.CommoditySuper;
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
        public bool UpdateCommodityRemark(int commodityId, string remark)
        {
            string sql = $"UPDATE Commodity SET CommodityRemark=?commodityRemark " +
                        $" WHERE CommodityId=?commodityId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["commodityId"] = commodityId;
            p["commodityRemark"] = remark;
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
        public bool UpdateCommodityimgName(int commodityId, string imgName)
        {
            string sql = $"UPDATE Commodity SET CommodityImg=?commodityImg " +
                        $" WHERE CommodityId=?commodityId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["commodityId"] = commodityId;
            p["commodityImg"] = imgName;
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
        public string InsertCommodity(string commodityModelStr)
        {
            var commodityModel = JsonUtil.Deserialize<CommodityModel>(commodityModelStr);
            string sql = $"INSERT INTO Commodity (CommodityName,CommodityImg,CommodityGeneral,CommodityPrice,CommodityUnitId,CommoditySpec," +
                         "CommodityBrandId,CommodityFamilyId,CommodityIndex,CommodityCode,CommodityState,CommodityHOT,CommodityRH," +
                         "CommodityFL,CommoditySuper) VALUES (?commodityName,?commodityImg,?commodityGeneral," +
                        $"?commodityPrice,?commodityUnitId,?commoditySpec,?commodityBrandId,?commodityFamilyId," +
                        $"?commodityIndex,?commodityCode,?commodityState,?commodityHOT,?commodityRH," +
                        $"?commodityFL,?commoditySuper);SELECT @@IDENTITY";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["commodityName"] = commodityModel.CommodityName;
            p["commodityImg"] = commodityModel.CommodityImg;
            p["commodityGeneral"] = commodityModel.CommodityGeneral;
            p["commodityPrice"] = commodityModel.CommodityPrice;
            p["commodityUnitId"] = commodityModel.CommodityUnitId;
            p["commoditySpec"] = commodityModel.CommoditySpec;
            p["commodityBrandId"] = commodityModel.CommodityBrandId;
            p["commodityFamilyId"] = commodityModel.CommodityFamilyId;
            p["commodityIndex"] = commodityModel.CommodityIndex;
            p["commodityCode"] = commodityModel.CommodityCode;
            p["commodityState"] = 0;
            p["commodityHOT"] = commodityModel.CommodityHOT;
            p["commodityRH"] = commodityModel.CommodityRH;
            p["commodityFL"] = commodityModel.CommodityFL;
            p["commoditySuper"] = commodityModel.CommoditySuper;
            var num = Convert.ToInt32(DbUtil.Master.ExecuteScalar(sql, p));
            if (num > 0)
            {
                string pix = Path.GetExtension(commodityModel.CommodityImg);
                UpdateCommodityimgName(num, num + "1" + pix);
                commodityModel.CommodityId = num;
                commodityModel.CommodityImg = num + "1" + pix;
                return JsonUtil.Serialize(commodityModel);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
