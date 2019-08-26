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
    public class PaymentController : AppController
    {
        [HttpGet]
        public ActionResult GetPayList()
        {
            var data = PaymentService.Instance.GetPayList();
            return OK(data);
        }
    }
}
