using Qsw.Services;
using QSW.Common.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace QSW.Web.Controllers
{
    public class UserController : AppController
    {
        [HttpGet]
        public ActionResult Login(string userName, string pwd)
        {
            var data = UserService.Instance.Login(userName, pwd);
            return OK(data);
        }
        [HttpGet]
        public ActionResult GetUserInfo(string token)
        {
            var data = UserService.Instance.GetUserInfo(token);
            return OK(data);
        }
        [HttpGet]
        public ActionResult UpdateUserInfo(string token, string nickname, string sex, string uImg, string phone, string entPhone, string entName, string entaddres)
        {
            var data = UserService.Instance.UpdateUserInfo(token, nickname, sex, uImg, phone, entPhone, entName, entaddres);
            return OK(data);
        }
        [HttpGet]
        public ActionResult Register(string uName, string pwd, string sex, string nickname, string entName, string phones, string entPhone, string entAddres)
        {
            var data = UserService.Instance.Register(uName, pwd, sex, nickname, entName, phones, entPhone, entAddres);
            return OK(data);
        }
        [HttpGet]
        public ActionResult CkUname(string uName)
        {
            var data = UserService.Instance.CkUname(uName);
            return OK(data);
        }
    }
}
