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

        public ActionResult DeleteBrand(int id)
        {
            return OK();
        }
    }
}
