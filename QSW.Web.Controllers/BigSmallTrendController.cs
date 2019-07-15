using KJW.Common.Controllers;
using KJW.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KJW.Web.Controllers
{
    public class BigSmallTrendController : AppController
    {
        [HttpGet]
        public ActionResult Query(int lotteryCode, DateTime? date = null, int size = 30)
        {
            string bigSmallTrendData = BigSmallTrendService.Instance.GetData(lotteryCode, date, size);
            return OK(bigSmallTrendData);
        }
    }
}
