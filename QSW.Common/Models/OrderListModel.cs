using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSW.Common.Models
{
    public class OrderListModel
    {
        public long OrderId { get; set; }
        public double OrderPrice { get; set; }
        public string OrderPNumber { get; set; }
        public int OrderState { get; set; }
        public string NameExpress { get; set; }
        public string ExpressCode { get; set; }
        public double ExpressAmount { get; set; }
        public double OrderAmount { get; set; }
        public string ReceivingAddress { get; set; }
        public string Consignee { get; set; }
        public string Telephone { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime PaymentTime { get; set; }
        public DateTime DeliveryTime { get; set; }
        public DateTime TimeOfDelivery { get; set; }
        public int IsInvoice { get; set; }
        public int PaymentMethod { get; set; }
        public string PaymentMethodName { get; set; }
        public string Remarks { get; set; }
        public int UserId { get; set; }
        public List<OrderDtlModel> OrdrList { get; set; }
    }
}
