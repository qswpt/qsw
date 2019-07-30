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
        /// <summary>
        /// 返回false时前端需要重新登录
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static UserModel GetUserLoginState(string token)
        {
            var userModel = CacheHelp.Get<UserModel>(token, DateTimeOffset.Now.AddDays(7), () => null);
            return userModel;
        }
        public string GetUserInfo(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                var userModel = CacheHelp.Get<UserModel>(token, DateTimeOffset.Now.AddDays(7), () => null);
                if (userModel != null)
                {
                    return JsonUtil.Serialize(userModel);
                }
            }
            return "";
        }
        public string UpdateUserInfo(string token, string nickname, string sex, string uImg)
        {
            if (!string.IsNullOrEmpty(token))
            {
                var userModel = CacheHelp.Get<UserModel>(token, DateTimeOffset.Now.AddDays(7), () => null);
                if (userModel != null)
                {
                    string sql = "UPDATE Users SET Nickname=?nickname,Sex=?sex,UserImg=?userImg where Uid=?uid";
                    Dictionary<string, object> p = new Dictionary<string, object>();
                    p["nickname"] = nickname;
                    p["sex"] = sex;
                    p["userImg"] = uImg;
                    p["uid"] = userModel.Uid;
                    int rowNum = DbUtil.Master.ExecuteNonQuery(sql, p);
                    if (rowNum > 0)
                    {
                        userModel.Nickname = nickname;
                        userModel.Sex = sex;
                        userModel.UserImg = uImg;
                        string key = string.Concat(token); //统一cache Key
                        CacheHelp.Set(key, DateTimeOffset.Now.AddDays(7), userModel);
                        ReturnModel re = new ReturnModel();
                        re.state = true;
                        return JsonUtil.Serialize(re);
                    }
                }
            }
            return string.Empty;
        }
    }
}
