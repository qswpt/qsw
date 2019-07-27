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
    public class CommodityTypeController : AppController
    {
        [HttpGet]
        public ActionResult GetCommodityType(int size = 10)
        {
            var data = CommodityTypeService.Instance.GetCommodityType(size);
            return OK(data);
        }

        [HttpPost]
        public ActionResult DeleteCommodityType(int typeId)
        {
            var data = CommodityTypeService.Instance.DeleteCommodityType(typeId);
            return OK(data);
        }

        [HttpPost]
        public ActionResult AddCommodityType(string commodityTypeModelStr)
        {
            var data = CommodityTypeService.Instance.InsertCommodityType(commodityTypeModelStr);
            return OK(data);
        }

        [HttpPost]
        public ActionResult UpdateCommodityType(int id,string commodityTypeModelStr)
        {
            var data = CommodityTypeService.Instance.UpdateCommodityType(id,commodityTypeModelStr);
            return OK(data);
        }
    }
}
