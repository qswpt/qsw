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
    public class OrderDtlService : Singleton<OrderDtlService>
    {
        public static void InsertOrderDtl(OrderDtlModel order)
        {
            string sql = $"INSERT INTO OrderDtl (OrderId,CommodityId,CommodityName,CommodityGeneral,CommodityPrice,CommodityUnitName,CommoditySpec,CommodityBrandId," +
                          "CommodityBrandName,CommodityFamilyId,CommodityIndex,CommodityCode,CommodityRH,CommodityRM,CommodityFL,OriginalTotalPrice,DiscountPrice,Discount,CommNumber,UserId)" +
                          " VALUES (?orderId,?commodityId,?commodityName,?commodityGeneral,?commodityPrice,?commodityUnitName,?commoditySpec,?commodityBrandId,?commodityBrandName,?commodityFamilyId,?commodityIndex," +
                          "?commodityCode,?commodityRH,?commodityRM,?commodityFL,?originalTotalPrice,?discountPrice,?discount,?commNumber,?userId)";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["orderId"] = order.OrderId;
            p["commodityId"] = order.CommodityId;
            p["commodityName"] = order.CommodityName;
            p["commodityGeneral"] = order.CommodityGeneral;
            p["commodityPrice"] = order.CommodityPrice;
            p["commodityUnitName"] = order.CommodityUnitName;
            p["commoditySpec"] = order.CommoditySpec;
            p["commodityBrandId"] = order.CommodityBrandId;
            p["commodityBrandName"] = order.CommodityBrandName;
            p["commodityFamilyId"] = order.CommodityFamilyId;
            p["commodityIndex"] = order.CommodityIndex;
            p["commodityCode"] = order.CommodityCode;
            p["commodityRH"] = order.CommodityRH;
            p["commodityRM"] = order.CommodityRM;
            p["commodityFL"] = order.CommodityFL;
            p["originalTotalPrice"] = order.OriginalTotalPrice;
            p["discountPrice"] = order.DiscountPrice;
            p["discount"] = order.Discount;
            p["commNumber"] = order.CommNumber;
            p["userId"] = order.UserId;
            DbUtil.Master.ExecuteNonQuery(sql, p);
        }
    }
}
