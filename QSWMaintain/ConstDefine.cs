using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QSWMaintain
{
    public class ConstDefine
    {
        private static string host = "http://{0}:{1}";

        private static string Server = "localhost";

        private static int port = 80;

        public static string Host
        {
            get
            {
                return string.Format(host, Server, port);
            }
        }

        public static RestClient Client { get; } = new RestClient(Host);
    }
}
