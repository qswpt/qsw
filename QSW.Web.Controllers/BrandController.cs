using Qsw.Services;
using QSW.Common.Controllers;
using System.Web.Mvc;

namespace KJW.Web.Controllers
{
    public class BrandController : AppController
    {
        [HttpGet]
        public ActionResult GetBrandHome(int size = 10)
        {
            var data = BrandService.Instance.GetBrandHome(size);
            return OK(data);
        }

        [HttpPost]
        public ActionResult DeleteBrand(int id)
        {
            var res = BrandService.Instance.DeleteBrand(id);
            return OK(res);
        }

        [HttpPost]
        public ActionResult UpdateBrand(int id, string brandModelStr)
        {
            var res = BrandService.Instance.UpdateBrand(id, brandModelStr);
            return OK(res);
        }

        [HttpPost]
        public ActionResult AddBrand(string brandModelStr)
        {
            var res = BrandService.Instance.InsertBrand(brandModelStr);
            return OK(res);
        }
    }
}
