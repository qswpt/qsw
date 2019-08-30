using Qsw.Services;
using QSW.Common.Controllers;
using System.Web.Mvc;

namespace QSW.Web.Controllers
{
    public class CityExLogisticsAmountController : AppController
    {
        [HttpGet]
        public ActionResult GetCityExLogisticsAmountList()
        {
            var data = CityExLogisticsAmountService.Instance.GetCityExLogisticsAmountList();
            return OK(data);
        }

        [HttpGet]
        public ActionResult GetCityExLogisticsAmount(int cityId, int exId)
        {
            var data = CityExLogisticsAmountService.Instance.GetCityExLogisticsAmount(cityId, exId);
            return OK(data);
        }

        [HttpPost]
        public ActionResult AddCityExLogisticsAmount(string cityExLogisticsAmountModelStr)
        {
            var data = CityExLogisticsAmountService.Instance.InsertCityExLogisticsAmount(cityExLogisticsAmountModelStr);
            return OK(data);
        }

        [HttpPost]
        public ActionResult UpdateCityExLogisticsAmount(int id, string cityExLogisticsAmountModelStr)
        {
            var data = CityExLogisticsAmountService.Instance.UpdateCityExLogisticAmount(id, cityExLogisticsAmountModelStr);
            return OK(data);
        }

        [HttpPost]
        public ActionResult DeleteCityExLogisticsAmount(int id)
        {
            var data = CityExLogisticsAmountService.Instance.DeleteCityExLogisticsAmount(id);
            return OK(data);
        }
    }
}
