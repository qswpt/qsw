using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QSWMaintain
{
    public class ConstDefine
    {
        private static string host = "http://{0}";

        private static string server = string.Empty;
        
        public static string Host
        {
            get
            {
                return string.Format(host, Server);
            }
        }

        public static string Server
        {
            get
            {
                if (!string.IsNullOrEmpty(server))
                {
                    return server;
                }

                var serverIp = ConfigurationManager.AppSettings["ServerIP"];
                if (!string.IsNullOrEmpty(serverIp))
                {
                    server = serverIp;
                }
                else
                {
                    server = "localhost";
                }

                return server;
            }
        }
        public static RestClient Client { get; } = new RestClient(Host);
    }
}
