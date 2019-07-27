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
        public ActionResult UpdateUserInfo(string token, string nickname, string sex, string uImg)
        {
            var data = UserService.Instance.UpdateUserInfo(token, nickname, sex, uImg);
            return OK(data);
        }
    }
}
