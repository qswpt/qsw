using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSW.Common.Models
{
    public class OrderInvoiceModel
    {
        public long OrderId { get; set; }
        public string OrderPNumber { get; set; }
        public string InvoiceCode { get; set; }
        public string InvoicePayable { get; set; }
        public string BusinessName { get; set; }
        public string TaxpayerNumber { get; set; }
        public string BillContactPhone { get; set; }
        public string BillContactEmail { get; set; }
        public string BillContent { get; set; }
        public double InvoiceAmount { get; set; }
        public int UserId { get; set; }
    }
}
