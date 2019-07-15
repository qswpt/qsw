using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Framework.Common;
using Framework.Common.Exceptions;

namespace Framework.Common.Utils
{
    public static class ExceptionUtil
    {
        public static void Throw(Exception ex)
        {
            if (ex is MessageException ||
                ex is AuthenticationException ||
                ex is AuthorizationException)
            {
                throw ex;
            }
            else
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static void ThrowMessageException(string msg)
        {
            throw new MessageException(msg);
        }
    }
}
