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
    public class SearchController : AppController
    {
        [HttpGet]
        public ActionResult GetSearchList(string token)
        {
            var data = SearchDtlService.Instance.GetSearchList(token);
            return OK(data);
        }
        [HttpGet]
        public ActionResult InsertSearch(string token, string searcheTxt, int hot = 0)
        {
            var data = SearchDtlService.Instance.InsertSearch(token, searcheTxt, hot);
            return OK(data);
        }
        [HttpGet]
        public ActionResult UpSearch(string token, string searcheTxt, int hot, long searchId)
        {
            var data = SearchDtlService.Instance.UpSearch(token, searcheTxt, hot, searchId);
            return OK(data);
        }
        [HttpGet]
        public ActionResult ClearSearch(string token)
        {
            var data = SearchDtlService.Instance.ClearSearch(token);
            return OK(data);
        }
    }
}
