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
            string invoicePayable, string businessName, string taxpayerNumber, string billContactPhone, string billContactEmail, string billContent, int IsSample = 0)
        {
            var data = OrderListService.Instance.WapPay(spId, spCount, token, isSC, cityId, exId, exName,
             addres, consignee, phone, isInvoice, payid, payName, ramrk,
             invoicePayable, businessName, taxpayerNumber, billContactPhone, billContactEmail, billContent, IsSample);
            return OK(data, true);
        }
        [HttpGet]
        public ActionResult wapOk(string wapSpid, long orderId)
        {
            OrderListService.Instance.wapOk(wapSpid, orderId);
            return OK(string.Empty);
        }
        [HttpGet]
        public ActionResult GetOrderList(int orderType, string token)
        {
            var data = OrderListService.Instance.GetOrderList(orderType, token);
            return OK(data);
        }
        [HttpGet]
        public ActionResult CanceOrderList(string token, long orderId, int orderType)
        {
            var data = OrderListService.Instance.CanceOrderList(token, orderId, orderType);
            return OK(data);
        }
        [HttpGet]
        public ActionResult GetOrder(long orderId, string token, int orderType)
        {
            var data = OrderListService.Instance.GetOrder(orderId, token, orderType);
            return OK(data, true);
        }
    }
}
