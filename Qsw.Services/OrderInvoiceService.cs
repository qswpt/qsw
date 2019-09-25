using Framework.Common.Functions;
using Framework.Common.Utils;
using QSW.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qsw.Services
{
    public class OrderInvoiceService : Singleton<OrderInvoiceService>
    {
        public void InserInvoice(OrderInvoiceModel invoce)
        {
            string sql = $"INSERT OrderInvoice (OrderId,OrderPNumber,InvoicePayable,BusinessName,TaxpayerNumber,BillContactPhone,BillContactEmail,BillContent,InvoiceAmount,UserId)" +
                " VALUES (?orderId,?orderPNumber,?invoicePayable,?businessName,?taxpayerNumber,?billContactPhone,?billContactEmail,?billContent,?invoiceAmount,?userId)";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["orderId"] = invoce.OrderId;
            p["orderPNumber"] = invoce.OrderPNumber;
            p["invoicePayable"] = invoce.InvoicePayable;
            p["businessName"] = invoce.BusinessName;
            p["taxpayerNumber"] = invoce.TaxpayerNumber;
            p["billContactPhone"] = invoce.BillContactPhone;
            p["billContactEmail"] = invoce.BillContactEmail;
            p["billContent"] = invoce.BillContent;
            p["invoiceAmount"] = invoce.InvoiceAmount;
            p["userId"] = invoce.UserId;
            DbUtil.Master.ExecuteNonQuery(sql, p);
        }
        public void DeleteInvoce(long orderId)
        {
            string sql = "DELETE FROM OrderInvoice WHERE OrderId=?orderId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["orderId"] = orderId;
            DbUtil.Master.ExecuteNonQuery(sql, p);
        }
    }
}
