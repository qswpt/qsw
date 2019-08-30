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
        private static string uKey = "qsw2019";
        public string Login(string userName, string pwd)
        {
            string sql = "select * from Users where UserName=?userName and Pwd=?pwd and State=0 ";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["userName"] = userName;
            p["pwd"] = pwd;
            UserModel user = DbUtil.Master.Query<UserModel>(sql, p);
            if (user != null)
            {
                string key = CryptoUtil.GetRandomAesKey();
                user.key = key;
                user.Pwd = string.Empty;
                string Token = CryptoUtil.AesEncryptHex(user.UserName + uKey, key);
                string uloginKey = user.UserName + uKey;
                var oldToken = CacheHelp.Get<string>(uloginKey, DateTimeOffset.Now.AddDays(7), () => null);
                if (!string.IsNullOrEmpty(oldToken))
                {
                    CacheHelp.Set(oldToken, DateTimeOffset.Now.AddDays(7), null);
                }
                CacheHelp.Set(uloginKey, DateTimeOffset.Now.AddDays(7), Token);
                CacheHelp.Set(Token, DateTimeOffset.Now.AddDays(7), user);
                List<object> u = new List<object>();
                u.Add(new
                {
                    token = Token,
                });
                return JsonUtil.Serialize(u);
            }
            return string.Empty;
        }
        public string GetUserInfo(string token)
        {
            return JsonUtil.Serialize(CkToken(token));
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
        /// <summary>
        /// 检查token是否有效
        /// </summary>
        /// <param name="token"></param>
        /// <param name="uName"></param>
        /// <returns></returns>
        public static UserModel CkToken(string token)
        {
            var user = CacheHelp.Get<UserModel>(token, DateTimeOffset.Now.AddDays(7), () => null);
            if (user != null)
            {
                string tmpUName = CryptoUtil.AesDecryptHex(token, user.key);
                if (!string.IsNullOrEmpty(tmpUName) && tmpUName.Equals(user.UserName + uKey))
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        public static string ckTokenState()
        {
            //List<object> objList = new List<object>();
            //objList.Add(new { msg = "pastLogin" });
            object obj = new { msg= "pastLogin" };
            return JsonUtil.Serialize(obj);
        }
    }
}
