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
    }
}
