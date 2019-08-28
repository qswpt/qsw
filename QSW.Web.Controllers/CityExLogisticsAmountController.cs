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
    public class CityExLogisticsAmountController : AppController
    {
        [HttpGet]
        public ActionResult GetCityExLogisticsAmount(int cityId, int exId)
        {
            var data = CityExLogisticsAmountService.Instance.GetCityExLogisticsAmount(cityId, exId);
            return OK(data);
        }
    }
}
