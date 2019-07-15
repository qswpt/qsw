using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Framework.Common.Utils
{
    public static class RequestUtil
    {
        public static string Controller
        {
            get
            {
                string controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"] as string;
                return (controller == null ? "" : controller);
            }
        }

        public static string Action
        {
            get
            {
                string action = HttpContext.Current.Request.RequestContext.RouteData.Values["action"] as string;
                return (action == null ? "" : action);
            }
        }

        public static int Id
        {
            get
            {
                return ConvertUtil.ToInt(HttpContext.Current.Request.RequestContext.RouteData.Values["id"], 0);
            }
        }

        public static string GetData(string key)
        {
            return HttpContext.Current.Request[key];
        }

        public static string GetRouteData(string key)
        {
            return HttpContext.Current.Request.RequestContext.RouteData.Values[key] as string;
        }

        public static string UrlEncode(string text)
        {
            return HttpContext.Current.Server.UrlEncode(text);
        }

        public static string UrlDecode(string text)
        {
            return HttpContext.Current.Server.UrlDecode(text);
        }

        public static string HtmlEncode(string text)
        {
            return HttpContext.Current.Server.HtmlEncode(text);
        }

        public static string HtmlDecode(string text)
        {
            return HttpContext.Current.Server.HtmlDecode(text);
        }

        public static string GetClientIP()
        {
            string clientIP = "";

            try
            {
                if (HttpContext.Current != null)
                {
                    clientIP = HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"];
                    if (string.IsNullOrEmpty(clientIP))
                    {
                        clientIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                        if (string.IsNullOrEmpty(clientIP))
                        {
                            clientIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                            if (string.IsNullOrEmpty(clientIP))
                            {
                                clientIP = "1.1.1.1";
                            }
                        }
                        else
                        {
                            string[] arrIP = clientIP.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            int arrayIndex = arrIP.Length - 2;
                            if (arrayIndex < 0)
                            {
                                arrayIndex = 0;
                            }

                            clientIP = arrIP[arrayIndex];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex.ToString());
            }

            return clientIP;
        }

        public static string GetRequestInfo()
        {
            string info = "";

            try
            {
                if (HttpContext.Current != null)
                {
                    info = $"Url:{HttpContext.Current.Request.Url.AbsoluteUri}|Form:{HttpContext.Current.Request.Form.ToString()}";
                }
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex.ToString());
            }

            return info;
        }

        public static string GetClientBrowserInfo()
        {
            string info = "";

            try
            {
                if (HttpContext.Current != null)
                {
                    NameValueCollection headers = HttpContext.Current.Request.Headers;
                    if (headers != null && headers.Count > 0)
                    {
                        info = "Browser:";
                        foreach (string header in headers)
                        {
                            foreach (string headerValue in headers.GetValues(header))
                            {
                                info += $"{header}={headerValue};";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex.ToString());
            }

            return info;
        }
    }
}
