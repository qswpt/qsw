using Qsw.Services;
using QSW.Common.Controllers;
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

        [HttpPost]
        public ActionResult AddCity(string cityName)
        {
            var data = CityService.Instance.InsertCity(cityName);
            return OK(data);
        }

        [HttpPost]
        public ActionResult UpdateCity(int cityId, string cityName)
        {
            var data = CityService.Instance.UpdateCity(cityId, cityName);
            return OK(data);
        }

        [HttpPost]
        public ActionResult DeleteCity(int cityId)
        {
            var data = CityService.Instance.DeleteCity(cityId);
            return OK(data);
        }
    }
}
