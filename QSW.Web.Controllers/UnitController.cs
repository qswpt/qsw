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
    public class UnitController: AppController
    {
        [HttpGet]
        public ActionResult GetUnit(int size = 10)
        {
            var data = UnitService.Instance.GetUnit(size);
            return OK(data);
        }
    }
}
