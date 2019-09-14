using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSW.Common.Models
{
    public class OrderDtlModel
    {
        public long OrderId { get; set; }
        public int CommodityId { get; set; }
        public string CommodityName { get; set; }
        public string CommodityGeneral { get; set; }
        public double CommodityPrice { get; set; }
        public string CommodityUnitName { get; set; }
        public int CommoditySpec { get; set; }
        public int CommodityBrandId { get; set; }
        public string CommodityBrandName { get; set; }
        public int CommodityFamilyId { get; set; }
        public string CommodityIndex { get; set; }
        public string CommodityCode { get; set; }
        public string CommodityRH { get; set; }
        public string CommodityRM { get; set; }
        public string CommodityFL { get; set; }
        public double OriginalTotalPrice { get; set; }
        public double DiscountPrice { get; set; }
        public double Discount { get; set; }
        public int CommNumber { get; set; }
        public int UserId { get; set; }
    }
}
