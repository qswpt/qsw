using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSW.Common
{
    public class FileWrite
    {
        public static void WriteLine(string path, string cent, string fileName)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            FileStream f = new FileStream(path + "\\" + fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(f);
            sw.WriteLine(cent);
            sw.Flush();
            sw.Close();
            f.Close();
        }
    }
}
