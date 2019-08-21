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
    public class CityController : AppController
    {
        [HttpGet]
        public ActionResult GetCityList()
        {
            var data = CityService.Instance.GetCityList();
            return OK(data); 
        }
    }
}
