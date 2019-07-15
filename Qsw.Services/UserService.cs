using Framework.Common.Functions;
using Framework.Common.Utils;
using QSW.Common.Caches;
using QSW.Common.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qsw.Services
{
    public class UserService : Singleton<UserService>
    {
        public string Login(string userName, string pwd)
        {
            string token = string.Empty;
            string sql = "select * from Users where UserName=?userName and Pwd=?pwd and State=0 ";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["userName"] = userName;
            p["pwd"] = pwd;
            UserModel user = DbUtil.Master.Query<UserModel>(sql, p);
            if (user != null)
            {
                string key = string.Concat(user.UserName, user.Uid); //统一cache Key
                CacheHelp.Set(key, DateTimeOffset.Now.AddDays(7), user);
                List<object> u = new List<object>();
                u.Add(new
                {
                    token = key,
                });
                token = JsonUtil.Serialize(u);
            }
            return token;
        }
    }
}
