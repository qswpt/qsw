using QSW.Common.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KJW.Web.Controllers
{
    public class topController : AppController
    {
        [HttpGet]
        public ActionResult GetTitle()
        {
            List<object> title = new List<object>();
            title.Add(new
            {
                title = "七色网",
            });
            return OK(title);
        }
    }
}
