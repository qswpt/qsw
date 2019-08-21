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
        private static string host = "http://{0}:{1}";

        private static string server = string.Empty;

        private static int port = 0;

        public static string Host
        {
            get
            {
                return string.Format(host, Server, Port);
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

        public static int Port
        {
            get
            {
                if (port != 0)
                {
                    return port;
                }

                bool res = int.TryParse(ConfigurationManager.AppSettings["Port"], out port);
                if (!res)
                {
                    port = 62830;
                }

                return port;
            }

        }

        public static RestClient Client { get; } = new RestClient(Host);
    }
}
