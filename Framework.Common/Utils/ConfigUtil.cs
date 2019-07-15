using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common.Utils
{
    public static class ConfigUtil
    {
        private static string _version = null;

        public static string Version
        {
            get
            {
                if (_version == null)
                {
                    Func<string, System.IO.SearchOption, DateTime> funcGetMaxModifyTime = (directoryPath, searchOption) =>
                    {
                        DateTime tempMaxTime = DateTime.MinValue;
                        System.IO.Directory.GetFiles(directoryPath, "*.*", searchOption)
                            .ToList()
                            .ForEach(n =>
                            {
                                var fileInfo = new System.IO.FileInfo(n);
                                if (fileInfo.LastWriteTime <= DateTime.Now)
                                {
                                    tempMaxTime = tempMaxTime > fileInfo.LastWriteTime ? tempMaxTime : fileInfo.LastWriteTime;
                                }
                            });
                        return tempMaxTime;
                    };

                    DateTime maxLastModifyTime = funcGetMaxModifyTime(AppDomain.CurrentDomain.BaseDirectory, System.IO.SearchOption.TopDirectoryOnly);

                    System.IO.Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory)
                        .ToList()
                        .ForEach(n =>
                        {
                            DateTime tempModifyTime = funcGetMaxModifyTime(n, System.IO.SearchOption.AllDirectories);
                            maxLastModifyTime = maxLastModifyTime > tempModifyTime ? maxLastModifyTime : tempModifyTime;
                        });

                    _version = maxLastModifyTime.ToString("yyMMddHHmmss");
                }

                return _version;
            }
        }
    }
}
