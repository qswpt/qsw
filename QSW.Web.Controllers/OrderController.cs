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
    public class OrderController : AppController
    {
        [HttpPost]
        public ActionResult WapPay(string spId, string spCount, string token, int isSC, int cityId, int exId, string exName,
            string addres, string consignee, string phone, int isInvoice, int payid, string payName, string ramrk,
            string invoicePayable, string businessName, string taxpayerNumber, string billContactPhone, string billContactEmail, string billContent)
        {
            var data = OrderListService.Instance.WapPay(spId, spCount, token, isSC, cityId, exId, exName,
             addres, consignee, phone, isInvoice, payid, payName, ramrk,
             invoicePayable, businessName, taxpayerNumber, billContactPhone, billContactEmail, billContent);
            return OK(data);
        }
    }
}
