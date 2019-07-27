using QSW.Common.Controllers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KJW.Web.Controllers
{
    public class topController : AppController
    {
        [HttpGet]
        public ActionResult GetTitle()
        {
            List<object> title = new List<object>();
            title.Add(new
            {
                title = "七色网",
            });
            return OK(title);
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
