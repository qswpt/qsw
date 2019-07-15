using Framework.Common.Exceptions;
using Framework.Common.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace QSW.Common.Controllers
{
    public class LoginController : AppController
    {
        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            //// 判断是否需要登录
            //string controllerAction = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "/" + filterContext.ActionDescriptor.ActionName;
            //if (!PermissionUtil.NeedLogin(controllerAction))
            //{
            //    return;
            //}

            //// 验证是否登录
            //if (SessionUtil.MemberId == 0)
            //{
            //    throw new AuthenticationException("请登录");
            //}
        }
    }
}
