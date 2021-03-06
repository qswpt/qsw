﻿using QSW.Common.Controllers;
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

        //[HttpPost]
        //public ActionResult ReplaceAdsImg(int index, string imgContent)
        //{
        //    byte[] imgBytes = Convert.FromBase64String(imgContent);
        //    string filePath = string.Format(@"/Images/adv/city--{0}-min-min.jpg", index);
        //    string path = Server.MapPath("~//" + filePath);
        //    if (System.IO.File.Exists(path))
        //    {
        //        System.IO.File.Delete(path);
        //    }

        //    System.IO.File.WriteAllBytes(path, imgBytes);
        //    return OK(string.Empty);
        //}

        [HttpPost]
        public ActionResult ReplaceAdsImg(string previousName, string imgName, string imgContent)
        {
            byte[] imgBytes = Convert.FromBase64String(imgContent);
            string filePath = string.Format(@"/Images/adv/{0}", imgName);
            string previousFilePath = string.Format(@"/Images/adv/{0}", previousName);
            string path = Server.MapPath("~//" + previousFilePath);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            path = Server.MapPath("~//" + filePath);
            System.IO.File.WriteAllBytes(path, imgBytes);
            return OK(string.Empty);
        }

        [HttpGet]
        public ActionResult GetAdsImg(int index)
        {
            string filePath = string.Format(@"/Images/adv/city--{0}-min-min.jpg", index);
            string path = Server.MapPath("~//" + filePath);
            if (!System.IO.File.Exists(path))
            {
                return OK(string.Empty);
            }
            byte[] contentArr = System.IO.File.ReadAllBytes(path);
            string imgContent = Convert.ToBase64String(contentArr);
            return OK(imgContent);
        }

        [HttpGet]
        public ActionResult GetAdsImage(string adImageName)
        {
            string filePath = string.Format(@"/Images/adv/{0}", adImageName);
            string path = Server.MapPath("~//" + filePath);
            if (!System.IO.File.Exists(path))
            {
                return OK(string.Empty);
            }
            byte[] contentArr = System.IO.File.ReadAllBytes(path);
            string imgContent = Convert.ToBase64String(contentArr);
            return OK(imgContent);
        }

        [HttpPost]
        public ActionResult DeleteAdsImage(string imageName)
        {
            return this.DeleteImage("adv", imageName);
        }

        [HttpPost]
        public ActionResult ReplaceBrandImg(string previousName, string imgName, string imgContent)
        {
            return ReplaceImage("logo", previousName, imgName, imgContent);
        }

        [HttpPost]
        public ActionResult DeleteBrandImage(string imageName)
        {
            return DeleteImage("logo", imageName);
        }

        [HttpPost]
        public ActionResult ReplaceCommodityImg(string previousName, string imgName, string imgContent)
        {
            return ReplaceImage("commodity", previousName, imgName, imgContent);
        }

        [HttpPost]
        public ActionResult DeleteCommodityImage(string imageName)
        {
            return DeleteImage("commodity", imageName);
        }

        #region Private Methods
        private ActionResult ReplaceImage(string typeName, string previousName, string imgName, string imgContent)
        {
            string previousPath = Server.MapPath("~//" + string.Format(@"/Images/{0}/{1}", typeName, previousName));
            if (System.IO.File.Exists(previousPath))
            {
                System.IO.File.Delete(previousPath);
            }

            byte[] imgBytes = Convert.FromBase64String(imgContent);
            string filePath = string.Format(@"/Images/{0}/{1}", typeName, imgName);
            string path = Server.MapPath("~//" + filePath);
            System.IO.File.WriteAllBytes(path, imgBytes);
            return OK(string.Empty);
        }

        private ActionResult DeleteImage(string typeName, string imgName)
        {
            string imagePath = Server.MapPath("~//" + string.Format(@"/Images/{0}/{1}", typeName, imgName));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            return OK(string.Empty);
        }
        #endregion
    }
}
