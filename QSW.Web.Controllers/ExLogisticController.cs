using Qsw.Services;
using QSW.Common.Controllers;
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

        [HttpPost]
        public ActionResult AddExLogistic(string exName)
        {
            var data = ExLogisticService.Instance.InsertExLogistic(exName);
            return OK(data);
        }

        [HttpPost]
        public ActionResult UpdateExLogistic(int exId, string exName)
        {
            var data = ExLogisticService.Instance.UpdateExLogistic(exId, exName);
            return OK(data);
        }

        [HttpPost]
        public ActionResult DeleteExLogistic(int exId)
        {
            var data = ExLogisticService.Instance.DeleteExLogistic(exId);
            return OK(data);
        }
    }
}
