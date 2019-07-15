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
    public class AppController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("~/index.html");
            //return View();
        }

        public ActionResult GetServerTime()
        {
            ContentResult cr = new ContentResult();
            cr.ContentType = "text/html";
            cr.Content = "{\"Status\":1,\"Date\":\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\"}";
            return cr;
        }

        public ActionResult GetClientIP()
        {
            string clientIp = $"REMOTE_ADDR:{Request.ServerVariables["REMOTE_ADDR"]}，HTTP_X_REAL_IP:{Request.ServerVariables["HTTP_X_REAL_IP"]}，HTTP_X_FORWARDED_FOR:{Request.ServerVariables["HTTP_X_FORWARDED_FOR"]}，HTTP_CLIENT_IP:{Request.ServerVariables["HTTP_CLIENT_IP"]}，GetClientIP:{RequestUtil.GetClientIP()}";
            return OK(clientIp);
        }

        protected ActionResult OK()
        {
            ContentResult cr = new ContentResult();
            cr.ContentType = "text/html";
            cr.Content = "{\"Status\":1}";
            return cr;
        }

        protected ActionResult OK(string data)
        {
            ContentResult cr = new ContentResult();
            cr.ContentType = "text/html";

            if (data == null)
            {
                cr.Content = "{\"Status\":1,\"Data\":null}";
            }
            else
            {
                if (data.StartsWith("{") || data.StartsWith("["))
                {
                    cr.Content = "{\"Status\":1,\"Data\":" + data + "}";
                }
                else
                {
                    cr.Content = "{\"Status\":1,\"Data\":\"" + data + "\"}";
                }
            }

            return cr;
        }

        protected ActionResult OK(DataTable data)
        {
            ContentResult cr = new ContentResult();
            cr.ContentType = "text/html";
            cr.Content = "{\"Status\":1,\"Data\":" + DataTableUtil.SerializeToJson(data) + "}";
            return cr;
        }

        protected ActionResult OK(object data)
        {
            ContentResult cr = new ContentResult();
            cr.ContentType = "text/html";
            cr.Content = "{\"Status\":1,\"Data\":" + JsonUtil.Serialize(data) + "}";
            return cr;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            CallContext.SetData("Ticks", DateTime.Now.Ticks);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            long elapsedTicks = DateTime.Now.Ticks - ConvertUtil.ToLong(CallContext.GetData("Ticks"), 0);

            if (elapsedTicks > 10000000) // 大于1秒
            {
                LogUtil.Warn("请求超过1秒[" + elapsedTicks / 10000000 + "]：" + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "/" + filterContext.ActionDescriptor.ActionName);
            }

            if (elapsedTicks > 30000000) // 大于3秒
            {
                LogUtil.Error("请求超过3秒[" + elapsedTicks / 10000000 + "]：" + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "/" + filterContext.ActionDescriptor.ActionName);
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (Request.IsAjaxRequest() || RequestUtil.GetData("Ajax") == "1")
            {
                HandleAjaxException(filterContext);
            }
            else
            {
                HandleException(filterContext);
            }
        }

        protected void HandleAjaxException(ExceptionContext filterContext)
        {
            // 返回的消息格式：
            // Status:0=保留，1=成功，2=提示消息，3=业务异常，300=未登录，400=无权限，500=未知的异常
            // Data:返回的相关异常数据

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.StatusCode = 200;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            if (filterContext.Exception is MessageException)
            {
                ContentResult cr = new ContentResult();
                cr.ContentType = "text/html";
                cr.Content = "{\"Status\":2,\"Data\":\"" + Server.HtmlEncode(ConvertUtil.Escape(filterContext.Exception.Message)) + "\"}";
                filterContext.Result = cr;
            }
            else if (filterContext.Exception is MessageException)
            {
                ContentResult cr = new ContentResult();
                cr.ContentType = "text/html";
                cr.Content = "{\"Status\":3,\"Data\":\"" + Server.HtmlEncode(ConvertUtil.Escape(filterContext.Exception.Message)) + "\"}";
                filterContext.Result = cr;
            }
            else if (filterContext.Exception is AuthenticationException)
            {
                ContentResult cr = new ContentResult();
                cr.ContentType = "text/html";
                cr.Content = "{\"Status\":300,\"Data\":\"" + Server.HtmlEncode(ConvertUtil.Escape(filterContext.Exception.Message)) + "\"}";
                filterContext.Result = cr;
            }
            else if (filterContext.Exception is AuthorizationException)
            {
                ContentResult cr = new ContentResult();
                cr.ContentType = "text/html";
                cr.Content = "{\"Status\":400,\"Data\":\"" + Server.HtmlEncode(ConvertUtil.Escape(filterContext.Exception.Message)) + "\"}";
                filterContext.Result = cr;
            }
            else
            {
                ContentResult cr = new ContentResult();
                cr.ContentType = "text/html";
                cr.Content = "{\"Status\":500,\"Data\":\"" + Server.HtmlEncode(ConvertUtil.Escape(filterContext.Exception.Message)).Replace(@"\&quot;", "") + "\"}";
                filterContext.Result = cr;

                LogUtil.Error($"当前用户：{SessionUtil.MemberId}，当前IP：{RequestUtil.GetClientIP()}， 异常信息：{filterContext.Exception.ToString()}，请求信息：{RequestUtil.GetRequestInfo()}，浏览器信息：{RequestUtil.GetClientBrowserInfo()}");
            }
        }

        protected void HandleException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.StatusCode = 200;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            if (filterContext.Exception is MessageException)
            {
                filterContext.Result = View("~/Views/App/Error.cshtml", filterContext.Exception);
            }
            else if (filterContext.Exception is MessageException)
            {
                filterContext.Result = View("~/Views/App/Error.cshtml", filterContext.Exception);
            }
            else if (filterContext.Exception is AuthenticationException)
            {
                filterContext.Result = new RedirectResult("/Member/Login");
            }
            else if (filterContext.Exception is AuthorizationException)
            {
                filterContext.Result = View("~/Views/App/Error.cshtml", filterContext.Exception);
            }
            else
            {
                filterContext.Result = View("~/Views/App/Error.cshtml", filterContext.Exception);
                LogUtil.Error($"当前用户：{SessionUtil.MemberId}，当前IP：{RequestUtil.GetClientIP()}， 异常信息：{filterContext.Exception.ToString()}，请求信息：{RequestUtil.GetRequestInfo()}，浏览器信息：{RequestUtil.GetClientBrowserInfo()}");
            }
        }
    }
}
