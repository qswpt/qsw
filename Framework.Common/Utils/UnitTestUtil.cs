using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.SessionState;

namespace Framework.Common.Utils
{
    public static class UnitTestUtil
    {
        /// <summary>
        /// 初始化HttpContext
        /// </summary>
        public static void Mock()
        {
            Mock("http://localhost/", "");
        }

        /// <summary>
        /// 初始化HttpContext（queryString不需要加?)
        /// </summary>
        /// <param name="queryString"></param>
        public static void Mock(string queryString)
        {
            Mock("http://localhost/", queryString);
        }

        /// <summary>
        /// 初始化HttpContext（queryString不需要加?)
        /// </summary>
        /// <param name="url"></param>
        /// <param name="queryString"></param>
        public static void Mock(string url, string queryString)
        {
            HttpRequest request = new HttpRequest("", url, queryString);
            HttpResponse response = new HttpResponse(new StringWriter());
            HttpContext.Current = new HttpContext(request, response);

            HttpSessionStateContainer session = new HttpSessionStateContainer(Guid.NewGuid().ToString("N"), new SessionStateItemCollection(),
                                                                              new HttpStaticObjectsCollection(),
                                                                              20000,
                                                                              true,
                                                                              HttpCookieMode.UseCookies,
                                                                              SessionStateMode.Off,
                                                                              false);
            SessionStateUtility.AddHttpSessionStateToContext(HttpContext.Current, session);

            var instance = HttpContext.Current.Request.ServerVariables;
            Type type = instance.GetType();
            BindingFlags temp = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

            MethodInfo addStatic = null;
            MethodInfo makeReadOnly = null;
            MethodInfo makeReadWrite = null;


            MethodInfo[] methods = type.GetMethods(temp);
            foreach (MethodInfo method in methods)
            {
                switch (method.Name)
                {
                    case "MakeReadWrite":
                        makeReadWrite = method;
                        break;
                    case "MakeReadOnly":
                        makeReadOnly = method;
                        break;
                    case "AddStatic":
                        addStatic = method;
                        break;
                }
            }

            makeReadWrite.Invoke(instance, null);

            List<string[]> list = new List<string[]>();
            string ip = "127.0.0.1";
            list.Add(new string[] { "HTTP_X_FORWARDED_FOR", ip });
            list.Add(new string[] { "HTTP_X_FORWARDED", ip });
            list.Add(new string[] { "HTTP_X_CLUSTER_CLIENT_IP", ip });
            list.Add(new string[] { "HTTP_FORWARDED_FOR", ip });
            list.Add(new string[] { "HTTP_FORWARDED", ip });
            list.Add(new string[] { "HTTP_CLIENT_IP", ip });
            list.Add(new string[] { "REMOTE_ADDR", ip });
            foreach (string[] values in list)
            {
                addStatic.Invoke(instance, values);
            }

            makeReadOnly.Invoke(instance, null);
        }
    }
}
