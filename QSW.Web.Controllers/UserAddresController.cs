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
    public class UserAddresController : AppController
    {
        [HttpGet]
        public ActionResult GetUserAddresList(string token)
        {
            var data = UserAddresService.Instance.GetUserAddresList(token);
            return OK(data);
        }
        [HttpGet]
        public ActionResult UpdateUserAddres(string token, int adId, string Address, string telephone, string contacts, int defaultAddress, int city)
        {
            var data = UserAddresService.Instance.UpdateUserAddres(token, adId, Address, telephone, contacts, defaultAddress, city);
            return OK(data);
        }
        [HttpGet]
        public ActionResult InserUserAddres(string token, string Address, string telephone, string contacts, int defaultAddress, int city)
        {
            var data = UserAddresService.Instance.InserUserAddres(token, Address, telephone, contacts, defaultAddress, city);
            return OK(data);
        }
        [HttpGet]
        public ActionResult DeleteUserAddres(string token, int adId)
        {
            var data = UserAddresService.Instance.DeleteUserAddres(token, adId);
            return OK(data);
        }
    }
}
