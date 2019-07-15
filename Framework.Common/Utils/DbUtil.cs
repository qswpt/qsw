using Framework.Common.Functions;
using System.Collections.Generic;
using System.Configuration;

namespace Framework.Common.Utils
{
    public static class DbUtil
    {
        public static MySqlDb Master = new MySqlDb(ConfigurationManager.AppSettings["DBConnectionStringMaster"]);
        public static MySqlDb Slave = new MySqlDb(ConfigurationManager.AppSettings["DBConnectionStringSlave"]);
    }

    /// <summary>
    /// （SQL参数包装，简化调用）
    /// </summary>
    public class SqlParam : Dictionary<string, object>
    {
        public SqlParam() : base()
        { }

        // 适用于一个参数的情况，代码简洁
        public SqlParam(string paramName, object value) : base()
        {
            this.Add(paramName, value);
        }

        // 链式操作 sqlparam.AddParam().AddParam().AddParam()
        public SqlParam AddParam(string paramName, object value)
        {
            this.Add(paramName, value);
            return this;
        }
    }
}
