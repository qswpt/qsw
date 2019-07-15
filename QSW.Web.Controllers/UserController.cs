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
    }
}
