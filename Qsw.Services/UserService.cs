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
        public string Register(string uName, string pwd, string sex, string nickname, string entName, string phones, string entPhone, string entAddres)
        {
            var isok = ckUnameSql(uName);
            if (!isok)
            {
                #region
                string sql = "INSERT INTO Users (UserName,Pwd,Nickname,Sex,EntName,Phones,EntPhone,EntAddres) VALUES (?userName,?pwd,?nickname,?sex,?entName,?phones,?entPhone,?entAddres)";
                Dictionary<string, object> p = new Dictionary<string, object>();
                p["userName"] = uName;
                p["pwd"] = pwd;
                p["nickname"] = nickname;
                p["sex"] = sex;
                p["entName"] = entName;
                p["phones"] = phones;
                p["entPhone"] = entPhone;
                p["entAddres"] = entAddres;
                var row = DbUtil.Master.ExecuteNonQuery(sql, p);
                if (row > 0)
                {
                    UserModel user = new UserModel();
                    string key = CryptoUtil.GetRandomAesKey();
                    user.key = key;
                    user.UserName = uName;
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
                else
                {
                    object obj = new { msg = false };
                    return JsonUtil.Serialize(obj);
                }
                #endregion
            }
            else
            {
                object obj = new { msg = isok };
                return JsonUtil.Serialize(obj);
            }
        }
        private bool ckUnameSql(string uName)
        {
            string sql = "SELECT * FROM Users WHERE UserName=?userName";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["userName"] = uName;
            var data = DbUtil.Master.Query<UserModel>(sql, p);
            bool isok = false;
            if (data != null)
            {
                isok = true;
            }
            return isok;
        }
        public string CkUname(string uName)
        {
            bool isok = ckUnameSql(uName);
            object obj = new { msg = isok };
            return JsonUtil.Serialize(obj);
        }
        public string UpdateUserInfo(string token, string nickname, string sex, string uImg, string phone, string entPhone, string entName, string entaddres)
        {
            if (!string.IsNullOrEmpty(token))
            {
                var userModel = CacheHelp.Get<UserModel>(token, DateTimeOffset.Now.AddDays(7), () => null);
                if (userModel != null)
                {
                    string sql = "UPDATE Users SET Nickname=?nickname,Sex=?sex,UserImg=?userImg,EntName=?entName,Phones=?phones,EntPhone=?entPhone,EntAddres=?entAddres where Uid=?uid";
                    Dictionary<string, object> p = new Dictionary<string, object>();
                    p["nickname"] = nickname;
                    p["sex"] = sex;
                    p["userImg"] = uImg;
                    p["entName"] = entName;
                    p["phones"] = phone;
                    p["entPhone"] = entPhone;
                    p["entAddres"] = entaddres;
                    p["uid"] = userModel.Uid;
                    int rowNum = DbUtil.Master.ExecuteNonQuery(sql, p);
                    if (rowNum > 0)
                    {
                        userModel.Nickname = nickname;
                        userModel.Sex = sex;
                        userModel.UserImg = uImg;
                        userModel.Phones = phone;
                        userModel.EntPhone = entPhone;
                        userModel.EntName = entName;
                        userModel.EntAddres = entaddres;
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
            object obj = new { msg = "pastLogin" };
            return JsonUtil.Serialize(obj);
        }
    }
}
