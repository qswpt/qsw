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
    public class ExLogisticController : AppController
    {
        [HttpGet]
        public ActionResult GetExLogisticList()
        {
            var data = ExLogisticService.Instance.GetExLogisticList();
            return OK(data);
        }
    }
}
