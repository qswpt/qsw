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
    public class OrderListService : Singleton<OrderListService>
    {
        /// <summary>
        /// 添加空订单
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        public static long GetInserScalar(int uId)
        {
            DeleteRbsData(uId);
            string sql = "INSERT INTO OrderList (OrderState,UserId) values(-1,?userId); SELECT @@IDENTITY";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["?userId"] = uId;
            var reOrderListId = Convert.ToInt64(DbUtil.Master.ExecuteScalar(sql, p));
            return reOrderListId;
        }
        /// <summary>
        /// 删除空订单
        /// </summary>
        /// <param name="uid"></param>
        public static void DeleteRbsData(int uid)
        {
            string sql = "DELETE FROM OrderList WHERE UserId=?userId AND OrderState=-1";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["?userId"] = uid;
            DbUtil.Master.ExecuteScalar(sql, p);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderL"></param>
        /// <param name="uId"></param>
        /// <returns></returns>
        private bool InsertOrderList(OrderListModel orderL, int uId, OrderInvoiceModel invoice, ref long orderId)
        {
            bool isok = false;
            orderId = GetInserScalar(uId);
            if (orderId > 0)
            {
                DbUtil.Master.BeginTransaction();
                try
                {
                    //保存订单明细 方法
                    foreach (var dtl in orderL.OrdrList)
                    {
                        dtl.OrderId = orderId;
                        OrderDtlService.InsertOrderDtl(dtl);
                    }
                    //保存订单信息
                    string sql = $"UPDATE OrderList SET OrderPrice=?orderPrice,OrderPNumber=?orderPNumber,OrderState=?orderState,NameExpress=?nameExpress,ExpressCode=?expressCode,ExpressAmount=?expressAmount," +
                                  "OrderAmount=?orderAmount,ReceivingAddress=?receivingAddress,Consignee=?consignee,Telephone=?telephone,CreateTime=?createTime,IsInvoice=?isInvoice,PaymentMethod=?paymentMethod," +
                                  "PaymentMethodName=?paymentMethodName,Remarks=?remarks WHERE OrderId=?orderId AND UserId=?userId ";
                    Dictionary<string, object> p = new Dictionary<string, object>();
                    p["orderPrice"] = orderL.OrderPrice;
                    p["orderPNumber"] = orderId;
                    p["orderState"] = 0; //未支付
                    p["nameExpress"] = orderL.NameExpress;
                    p["expressCode"] = orderL.ExpressCode;
                    p["expressAmount"] = orderL.ExpressAmount;
                    p["orderAmount"] = orderL.OrderAmount;
                    p["receivingAddress"] = orderL.ReceivingAddress;
                    p["consignee"] = orderL.Consignee;
                    p["telephone"] = orderL.Telephone;
                    p["createTime"] = DateTime.Now;
                    p["isInvoice"] = orderL.IsInvoice;
                    p["paymentMethod"] = orderL.PaymentMethod;
                    p["paymentMethodName"] = orderL.PaymentMethodName;
                    p["remarks"] = orderL.Remarks;
                    p["orderId"] = orderId;
                    p["userId"] = uId;
                    DbUtil.Master.ExecuteNonQuery(sql, p);
                    invoice.OrderId = orderId;
                    invoice.OrderPNumber = orderId.ToString();
                    if (orderL.IsInvoice == 1)
                    {
                        OrderInvoiceService.Instance.InserInvoice(invoice);
                    }
                    DbUtil.Master.CommitTransaction();
                    isok = true;
                }
                catch (Exception ex)
                {
                    DbUtil.Master.RollbackTransaction();
                }
            }
            return isok;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spId"></param>
        /// <param name="spCount"></param>
        /// <param name="token"></param>
        /// <param name="isSC">是否来自于购物车</param>
        /// <returns></returns>
        public string WapPay(string spId, string spCount, string token, int isSC, int cityId, int exId, string exName,
            string addres, string consignee, string phone, int isInvoice, int payid, string payName, string ramrk,
            string invoicePayable, string businessName, string taxpayerNumber, string billContactPhone, string billContactEmail, string billContent)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                OrderListModel orderList = new OrderListModel();
                long orderId = 0;
                var idList = spId.Split(',').Select(x => int.Parse(x)).ToList();
                var spcList = spCount.Split(',').Select(x => int.Parse(x)).ToList();
                List<CommodityModel> comDtl = new List<CommodityModel>();
                #region 获取基础数据
                if (isSC == 1)
                {
                    //获取购物车信息
                    var comStr = CommodityService.Instance.GetShoppingInId(token, spId);
                    comDtl = JsonUtil.Deserialize<List<CommodityModel>>(comStr);
                }
                else
                {
                    var data = CommodityService.Instance.GetCommodityInfo(Convert.ToInt32(spId));
                    comDtl.Add(JsonUtil.Deserialize<CommodityModel>(data));
                }
                #endregion
                //生成订单
                List<OrderDtlModel> oderDtl = new List<OrderDtlModel>();
                double orderAmount = 0;
                #region 订单明细
                foreach (var cm in comDtl)
                {
                    int cIndex = idList.FindIndex(o => o == cm.CommodityId);
                    OrderDtlModel dtl = new OrderDtlModel();
                    dtl.CommodityId = cm.CommodityId;
                    dtl.CommodityName = cm.CommodityName;
                    dtl.CommodityGeneral = cm.CommodityGeneral;
                    dtl.CommodityPrice = cm.CommodityPrice;
                    dtl.CommodityUnitName = cm.UnitIdName;
                    dtl.CommoditySpec = cm.CommoditySpec;
                    dtl.CommodityBrandId = cm.CommodityBrandId;
                    dtl.CommodityBrandName = cm.BrandName;
                    dtl.CommodityFamilyId = cm.CommodityFamilyId;
                    dtl.CommodityIndex = cm.CommodityIndex;
                    dtl.CommodityCode = cm.CommodityCode;
                    dtl.CommodityRH = cm.CommodityRH;
                    dtl.CommodityRM = cm.CommodityRM;
                    dtl.CommodityFL = cm.CommodityFL;
                    dtl.UserId = user.Uid;
                    dtl.CommNumber = spcList[cIndex];
                    dtl.OriginalTotalPrice = spcList[cIndex] * (cm.CommodityPrice * cm.CommoditySpec);
                    orderAmount = orderAmount + spcList[cIndex] * (cm.CommodityPrice * cm.CommoditySpec);
                    oderDtl.Add(dtl);
                }
                #endregion
                orderList.OrdrList = oderDtl;
                orderList.OrderPrice = orderAmount;
                //计算运费
                string cityStr = CityExLogisticsAmountService.Instance.GetCityExLogisticsAmount(cityId, exId);
                var cityData = JsonUtil.Deserialize<CityExLogisticsAmountModel>(cityStr);
                orderList.NameExpress = exName;
                orderList.ExpressAmount = cityData.Amount;
                orderList.OrderAmount = orderList.OrderPrice + orderList.ExpressAmount;
                orderList.ReceivingAddress = addres;
                orderList.Consignee = consignee;
                orderList.Telephone = phone;
                orderList.IsInvoice = isInvoice;
                orderList.PaymentMethod = payid;
                orderList.PaymentMethodName = payName;
                orderList.Remarks = ramrk;
                //保存发票抬头信息
                #region 发票
                OrderInvoiceModel invoice = new OrderInvoiceModel();
                invoice.InvoicePayable = invoicePayable;
                invoice.BusinessName = businessName;
                invoice.TaxpayerNumber = taxpayerNumber;
                invoice.BillContactPhone = billContactPhone;
                invoice.BillContactEmail = billContactEmail;
                invoice.BillContent = billContent;
                invoice.UserId = user.Uid;
                invoice.InvoiceAmount = orderList.OrderAmount;
                #endregion
                var isok = InsertOrderList(orderList, user.Uid, invoice, ref orderId);
                if (isok)
                {
                    if (isSC == 1)
                    {
                        //删除购物车
                        CommodityService.Instance.DeleteShopping(spId, token);
                    }
                    //提交支付---支付方法
                    //支付成功修改支付状态
                    //
                }
                return string.Empty;
            }
            else
            {
                return UserService.ckTokenState();
            }
        }
    }
}
