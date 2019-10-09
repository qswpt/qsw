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
    public class SearchDtlService : Singleton<SearchDtlService>
    {
        public string GetSearchList(string token)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                string key = string.Concat("GetSearchList");
                return CacheHelp.Get<string>(key, DateTimeOffset.Now.AddSeconds(3), () => GetSearchList(user.Uid));
            }
            else
            {
                return UserService.ckTokenState();
            }
        }
        public string GetSearchList(int uid)
        {
            string sql = $"SELECT * FROM SearcheDtl WHERE Uid=?uid OR Hot=1";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["uid"] = uid;
            var data = DbUtil.Master.QueryList<SearcheDtlModel>(sql, p);
            return JsonUtil.Serialize(data);
        }
        public string InsertSearch(string token, string searcheTxt, int hot)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                if (!searcheExit(searcheTxt, user.Uid))
                {
                    string sql = $"INSERT INTO SearcheDtl (Uid,SearchName,Hot) VALUES (?uid,?searchName,?hot)";
                    Dictionary<string, object> p = new Dictionary<string, object>();
                    p["uid"] = user.Uid;
                    p["searchName"] = searcheTxt;
                    p["hot"] = hot;
                    DbUtil.Master.ExecuteNonQuery(sql, p);
                }
                return GetSearchList(token);
            }
            else
            {
                return UserService.ckTokenState();
            }
        }
        private bool searcheExit(string searchTxt, int uid)
        {
            bool isok = false;
            string sql = $"SELECT * from SearcheDtl WHERE Uid=?uid AND SearchName=?searchName";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["uid"] = uid;
            p["searchName"] = searchTxt;
            var data = DbUtil.Master.Query<SearcheDtlModel>(sql, p);
            if (data != null)
            {
                isok = true;
            }
            return isok;
        }
        public string UpSearch(string token, string searcheTxt, int hot, long searchId)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                string sql = $"UPDATE SearcheDtl SET SearchName=?searchName,Hot=?hot WHERE SearchId=?searchId";
                Dictionary<string, object> p = new Dictionary<string, object>();
                p["searchName"] = searcheTxt;
                p["hot"] = hot;
                p["searchId"] = searchId;
                DbUtil.Master.ExecuteNonQuery(sql, p);
                return GetSearchList(token);
            }
            else
            {
                return UserService.ckTokenState();
            }
        }
        public string ClearSearch(string token)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                string sql = $"DELETE FROM SearcheDtl WHERE Uid=?uid";
                Dictionary<string, object> p = new Dictionary<string, object>();
                p["uid"] = user.Uid;
                DbUtil.Master.ExecuteNonQuery(sql, p);
                return GetSearchList(token);
            }
            else
            {
                return UserService.ckTokenState();
            }
        }
    }
}
