using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace Framework.Common.Utils
{
    public static class SessionUtil
    {
        public static HttpSessionState Session
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }

        public static int MemberId
        {
            get; set;
        }
    }
}
