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
    public class CommodityController : AppController
    {
        [HttpGet]
        public ActionResult GetCommodityList(int index = 1, int size = 10)
        {
            var data = CommodityService.Instance.GetCommodityList(index, size);
            return OK(data);
        }
        [HttpGet]
        public ActionResult GetCommodityByBrand(int brandId, int index = 1, int size = 10)
        {
            var data = CommodityService.Instance.GetCommodityByBrand(brandId, index, size);
            return OK(data);
        }
        [HttpGet]
        public ActionResult GetCommodityFamily(int familyId, int index = 1, int size = 10)
        {
            var data = CommodityService.Instance.GetCommodityFamily(familyId, index, size);
            return OK(data);
        }
        [HttpGet]
        public ActionResult SetShopping(string token, int spId)
        {
            var data = CommodityService.Instance.SetShopping(token, spId);
            return OK(data);
        }
        [HttpGet]
        public ActionResult SetShoppingCount(string token, int spId, int spCount)
        {
            var data = CommodityService.Instance.SetShoppingCount(token, spId, spCount);
            return OK(data);
        }
        [HttpGet]
        public ActionResult GetShoppingCount(string token)
        {
            var data = CommodityService.Instance.GetShoppingCount(token);
            return OK(data);
        }
        [HttpGet]
        public ActionResult DeleteShopping(string idStr, string token)
        {
            var data = CommodityService.Instance.DeleteShopping(idStr, token);
            return OK(data);
        }
        [HttpGet]
        public ActionResult DeleteAllShopping(string token)
        {
            var data = CommodityService.Instance.DeleteAllShopping(token);
            return OK(data);
        }
        [HttpGet]
        public ActionResult GetCommodityId(int id)
        {
            var data = CommodityService.Instance.GetCommodityInfo(id);
            return OK(data);
        }

        [HttpPost]
        public ActionResult DeleteCommodityById(int id)
        {
            var data = CommodityService.Instance.DeleteCommodityById(id);
            return OK(data);
        }

        [HttpGet]
        public ActionResult GetShoppingList(string token)
        {
            var data = CommodityService.Instance.GetShoppingList(token);
            return OK(data);
        }

        [HttpPost]
        public ActionResult AddCommodity(string commodityeModelStr)
        {
            var data = CommodityService.Instance.InsertCommodity(commodityeModelStr);
            return OK(data);
        }

        [HttpPost]
        public ActionResult UpdateCommodity(int id,string commodityeModelStr)
        {
            var data = CommodityService.Instance.UpdateCommodity(id,commodityeModelStr);
            return OK(data);
        }
    }
}
