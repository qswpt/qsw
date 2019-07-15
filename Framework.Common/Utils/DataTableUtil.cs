using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common.Utils
{
    public static class DataTableUtil
    {
        public static string SerializeToJson(DataTable dt)
        {
            int rowCount = dt.Rows.Count;
            int colCount = dt.Columns.Count;
            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            for (int i = 0; i < rowCount; ++i)
            {
                if (i > 0)
                {
                    sb.Append(",");
                }

                sb.Append("{");
                for (int j = 0; j < colCount; ++j)
                {
                    if (j > 0)
                    {
                        sb.Append(",");
                    }

                    string val = ConvertUtil.Escape(ConvertUtil.ToString(dt.Rows[i][j], ""));
                    sb.Append("\"" + dt.Columns[j].ColumnName + "\":\"" + val + "\"");
                }
                sb.Append("}");
            }

            sb.Append("]");

            return sb.ToString();
        }

        public static string SerializeToArray(DataTable dt)
        {
            int colCount = dt.Columns.Count;
            int rowCount = dt.Rows.Count;
            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            for (int i = 0; i < rowCount; ++i)
            {
                if (i > 0)
                {
                    sb.Append(",");
                }

                sb.Append("[");
                for (int j = 0; j < colCount; ++j)
                {
                    if (j > 0)
                    {
                        sb.Append(",");
                    }

                    string val = ConvertUtil.Escape(ConvertUtil.ToString(dt.Rows[i][j], ""));
                    sb.Append("\"" + val + "\"");
                }
                sb.Append("]");
            }
            sb.Append("]");

            return sb.ToString();
        }
    }
}
