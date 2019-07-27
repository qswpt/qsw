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
    }
}
