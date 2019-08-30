using Qsw.Services;
using QSW.Common.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace QSW.Web.Controllers
{
    public class AdvController : AppController
    {
        [HttpGet]
        public ActionResult GetAdvList()
        {
            var data = AdvService.Instance.GetAdvList();
            return OK(data);
        }

        [HttpPost]
        public ActionResult DeleteAdv(int advId)
        {
            var data = AdvService.Instance.DeleteAdv(advId);
            return OK(data);
        }

        [HttpPost]
        public ActionResult AddAdv(string advModelStr)
        {
            var data = AdvService.Instance.InsertAdv(advModelStr);
            return OK(data);
        }

        [HttpPost]
        public ActionResult UpdateAdv(int advId,string advModelStr)
        {
            var data = AdvService.Instance.UpdateAdv(advId,advModelStr);
            return OK(data);
        }

        [HttpGet]
        public ActionResult GetAdvType()
        {
            var data = AdvService.Instance.GetAdvType();
            return OK(data);
        }
    }
}
