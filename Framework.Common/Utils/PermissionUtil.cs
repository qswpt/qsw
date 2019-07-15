using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common.Utils
{
    public static class PermissionUtil
    {
        public static bool NeedLogin(string controllerAction)
        {
            switch (controllerAction.ToLower())
            {
                case "member/getcaptcha":
                case "member/login":
                case "member/dologin":
                case "member/testrsa":
                    return false;
            }

            return true;
        }
    }
}
