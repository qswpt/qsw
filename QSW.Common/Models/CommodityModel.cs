using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSW.Common.Models
{
    public class CommodityModel
    {
        public int CommodityId { get; set; }
        public string CommodityName { get; set; }
        public string CommodityImg { get; set; }
        public string CommodityGeneral { get; set; }
        public double CommodityPrice { get; set; }
        public int CommodityUnitId { get; set; }
        public int CommoditySpec { get; set; }
        public int CommodityBrandId { get; set; }
        public int CommodityFamilyId { get; set; }
        public string CommodityIndex { get; set; }
        public string CommodityCode { get; set; }
        public int CommodityHOT { get; set; }
        public string BrandName { get; set; }
        public string UnitIdName { get; set; }
        public string TypeName { get; set; }
        public int SpCount { get; set; }
        public string CommodityRH { get; set; }
        public string CommodityRM { get; set; }
        public string CommodityFL { get; set; }
        public string CommodityRemark { get; set; }
    }
}
