using Framework.Common.Functions;
using Framework.Common.Utils;
using QSW.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qsw.Services
{
    public class UserAddresService : Singleton<UserAddresService>
    {
        public string GetUserAddresList(string token)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                return userAddresList(user.Uid);
            }
            else
            {
                return UserService.ckTokenState();
            }
        }
        private string userAddresList(int uid)
        {
            string sql = "SELECT * FROM UserAddress WHERE Uid=?uid";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["uid"] = uid;
            var data = DbUtil.Master.QueryList<UserAddresModel>(sql, p);
            return JsonUtil.Serialize(data);
        }
        public string UpdateUserAddres(string token, int id, string Address, string telephone, string contacts, int defaultAddress, int city)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                if (defaultAddress > 0)
                {
                    updateDefaultAddress(user.Uid);
                }
                string sql = "UPDATE UserAddress SET Address=?address,Telephone=?telephone,Contacts=?contacts, DefaultAddress=?defaultAddress,CityId=?city WHERE Uid=?uid AND id=?id";
                Dictionary<string, object> p = new Dictionary<string, object>();
                p["id"] = id;
                p["address"] = Address;
                p["telephone"] = telephone;
                p["contacts"] = contacts;
                p["defaultAddress"] = defaultAddress;
                p["city"] = city;
                p["uid"] = user.Uid;
                var rows = DbUtil.Master.ExecuteNonQuery(sql, p);
                ReturnModel re = new ReturnModel();
                if (rows > 0)
                {
                    re.state = true;
                }
                return JsonUtil.Serialize(re);
            }
            else
            {
                return UserService.ckTokenState();
            }
        }
        public string InserUserAddres(string token, string Address, string telephone, string contacts, int defaultAddress, int city)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                if (defaultAddress > 0)
                {
                    updateDefaultAddress(user.Uid);
                }
                string sql = "INSERT INTO UserAddress (Uid,Address,Telephone,Contacts,DefaultAddress,CityId) value (?uid,?address,?telephone,?contacts,?defaultAddress,?city)";
                Dictionary<string, object> p = new Dictionary<string, object>();
                p["uid"] = user.Uid;
                p["address"] = Address;
                p["telephone"] = telephone;
                p["contacts"] = contacts;
                p["defaultAddress"] = defaultAddress;
                p["city"] = city;
                var rows = DbUtil.Master.ExecuteNonQuery(sql, p);
                ReturnModel re = new ReturnModel();
                if (rows > 0)
                {
                    re.state = true;
                }
                return JsonUtil.Serialize(re);
            }
            else
            {
                return UserService.ckTokenState();
            }
        }
        public string DeleteUserAddres(string token, int adId)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                string sql = "delete from UserAddress where id=?id and Uid=?uid";
                Dictionary<string, object> p = new Dictionary<string, object>();
                p["id"] = adId;
                p["uid"] = user.Uid;
                var rows = DbUtil.Master.ExecuteNonQuery(sql, p);
                ReturnModel re = new ReturnModel();
                if (rows > 0)
                {
                    re.state = true;
                }
                return JsonUtil.Serialize(re);
            }
            else
            {
                return UserService.ckTokenState();
            }
        }
        private void updateDefaultAddress(int uid)
        {
            string sql = "UPDATE UserAddress SET DefaultAddress=0 WHERE Uid=?uid";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["uid"] = uid;
            DbUtil.Master.ExecuteNonQuery(sql, p);
        }
    }
}
