using QSW.Common.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QSW.Web.Controllers
{
    public class FileUploadController : AppController
    {
        [HttpPost]
        public ActionResult upload(long fileSize, long dataSize, string fileName)
        {
            var fileStream = Request.GetBufferedInputStream();
            Bitmap bp = new Bitmap(fileStream);
            bp.Save(Server.MapPath("~//" + fileName));
            return OK(string.Empty);
        }

        [HttpPost]
        public ActionResult ReplaceAdsImg(int index, string imgContent)
        {
            byte[] imgBytes = Convert.FromBase64String(imgContent);
            string filePath = string.Format(@"/Images/adv/city--{0}-min-min.jpg", index);
            string path = Server.MapPath("~//" + filePath);
            System.IO.File.Delete(path);
            System.IO.File.WriteAllBytes(path, imgBytes);
            return OK();
        }
    }
}
