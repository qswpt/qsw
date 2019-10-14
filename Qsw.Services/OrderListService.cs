using Framework.Common.Functions;
using Framework.Common.Utils;
using QSW.Common.Caches;
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
        public static int UpdataState(long orderId)
        {
            string sql = "UPDATE OrderList SET OrderState=1 WHERE OrderId=?orderId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["?orderId"] = orderId;
            return DbUtil.Master.ExecuteNonQuery(sql, p);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderL"></param>
        /// <param name="uId"></param>
        /// <returns></returns>
        private void InsertOrderList(OrderListModel orderL, int uId, OrderInvoiceModel invoice, ref long orderId)
        {
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
                                  "PaymentMethodName=?paymentMethodName,Remarks=?remarks,IsSample=?isSample,Weight=?weight WHERE OrderId=?orderId AND UserId=?userId ";
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
                    p["isSample"] = orderL.IsSample;
                    p["weight"] = orderL.Weight;
                    DbUtil.Master.ExecuteNonQuery(sql, p);
                    invoice.OrderId = orderId;
                    invoice.OrderPNumber = orderId.ToString();
                    if (orderL.IsInvoice == 1)
                    {
                        OrderInvoiceService.Instance.InserInvoice(invoice);
                    }
                    DbUtil.Master.CommitTransaction();
                }
                catch (Exception ex)
                {
                    DbUtil.Master.RollbackTransaction();
                    LogUtil.Error(ex.Message);
                    throw ex;
                }
            }
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
            string invoicePayable, string businessName, string taxpayerNumber, string billContactPhone, string billContactEmail, string billContent, int IsSample)
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
                int weight = 0; //订单重量
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
                    dtl.CommodityImg = cm.CommodityImg;
                    dtl.CommodityIndex = cm.CommodityIndex;
                    dtl.CommodityCode = cm.CommodityCode;
                    dtl.CommodityRH = cm.CommodityRH;
                    dtl.CommodityRM = cm.CommodityRM;
                    dtl.CommodityFL = cm.CommodityFL;
                    dtl.UserId = user.Uid;
                    dtl.CommNumber = spcList[cIndex];
                    dtl.OriginalTotalPrice = spcList[cIndex] * (cm.CommodityPrice * cm.CommoditySpec);
                    orderAmount = orderAmount + spcList[cIndex] * (cm.CommodityPrice * cm.CommoditySpec);
                    weight = weight + cm.CommoditySpec * dtl.CommNumber;
                    oderDtl.Add(dtl);
                }
                #endregion
                orderList.OrdrList = oderDtl;
                orderList.OrderPrice = orderAmount;
                orderList.IsSample = IsSample;
                //计算运费
                string cityStr = CityExLogisticsAmountService.Instance.GetCityExLogisticsAmount(cityId, exId);
                var cityData = JsonUtil.Deserialize<CityExLogisticsAmountModel>(cityStr);
                if (IsSample == 1)
                {
                    orderList.OrderAmount = 0;
                    orderList.NameExpress = string.Empty;
                }
                else
                {
                    orderList.Weight = weight;
                    orderList.ExpressAmount = cityData.Amount * weight;
                    orderList.OrderAmount = orderList.OrderPrice + orderList.ExpressAmount;
                    orderList.NameExpress = exName;
                }
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
                InsertOrderList(orderList, user.Uid, invoice, ref orderId);
                if (isSC == 1)
                {
                    //删除购物车
                    CommodityService.Instance.DeleteShopping(spId, token);
                }
                string key = CryptoUtil.GetRandomAesKey();
                string wapSpId = CryptoUtil.AesEncryptHex(orderId.ToString(), key);
                CacheHelp.Set(wapSpId, DateTimeOffset.Now.AddDays(1), orderId.ToString());
                return wapPay(orderList, orderId, IsSample, wapSpId);
            }
            else
            {
                return UserService.ckTokenState();
            }
        }
        public void wapOk(string wapSpId, long orderId)
        {
            var idkey = CacheHelp.Get<string>(wapSpId, null);
            if (!string.IsNullOrEmpty(idkey))
            {
                var orId = Convert.ToInt64(idkey);
                if (orId == orderId)
                {
                    LogUtil.Info("支付加密：" + wapSpId + "订单编号;" + orderId);
                    UpdataState(orId);
                }
            }
        }
        #region 订单查询
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderType">0所有必须大于-1、1未支付、2支付未发货、3已发货</param>
        /// <returns></returns>
        public string GetOrderList(int orderType, string token)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                string statusStr = string.Empty;
                switch (orderType)
                {
                    case 0:
                        statusStr = ">-1";
                        break;
                    case 1:
                        statusStr = "=0";
                        break;
                    case 2:
                        statusStr = "=1";
                        break;
                    case 3:
                        statusStr = ">=2 AND OrderState<4";
                        break;
                }
                string sql = "SELECT * FROM OrderList WHERE OrderState" + statusStr + " AND UserId=?userId ORDER BY CreateTime DESC";
                Dictionary<string, object> p = new Dictionary<string, object>();
                p["userId"] = user.Uid;
                var data = DbUtil.Master.QueryList<OrderListModel>(sql, p);
                string orderId = string.Empty;
                foreach (var order in data)
                {
                    if (string.IsNullOrEmpty(orderId))
                    {
                        orderId = order.OrderId.ToString();
                    }
                    else
                    {
                        orderId = orderId + "," + order.OrderId.ToString();
                    }
                }
                if (!string.IsNullOrEmpty(orderId))
                {
                    var orderDtl = OrderDtlService.Instance.Getdtl(orderId);
                    foreach (var order in data)
                    {
                        var dtls = orderDtl.FindAll(o => o.OrderId == order.OrderId).ToList();
                        order.OrdrList = dtls;
                    }
                }
                return JsonUtil.Serialize(data);
            }
            else
            {
                return UserService.ckTokenState();
            }
        }
        public string CanceOrderList(string token, long orderId, int orderType)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                string sql = "SELECT * FROM OrderList WHERE OrderId=?orderId";
                Dictionary<string, object> p = new Dictionary<string, object>();
                p["orderId"] = orderId;
                var data = DbUtil.Master.Query<OrderListModel>(sql, p);
                if (data.OrderState == 0)
                {
                    try
                    {
                        DbUtil.Master.BeginTransaction();
                        OrderDtlService.Instance.DeleteDtl(orderId);
                        OrderInvoiceService.Instance.DeleteInvoce(orderId);
                        DeleteOrder(orderId);
                        DbUtil.Master.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        DbUtil.Master.RollbackTransaction();
                    }
                }
                return GetOrderList(orderType, token);
            }
            else
            {
                return UserService.ckTokenState();
            }
        }
        private void DeleteOrder(long orderId)
        {
            string sql = "DELETE FROM OrderList WHERE OrderId=?orderId";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["orderId"] = orderId;
            DbUtil.Master.ExecuteNonQuery(sql, p);
        }
        public string GetOrder(long orderId, string token, int orderType)
        {
            var user = UserService.CkToken(token);
            if (user != null)
            {
                string sql = "SELECT * FROM OrderList WHERE OrderId=?orderId";
                Dictionary<string, object> p = new Dictionary<string, object>();
                p["orderId"] = orderId;
                var orderList = DbUtil.Master.Query<OrderListModel>(sql, p);
                //调起支付
                string key = CryptoUtil.GetRandomAesKey();
                string wapSpId = CryptoUtil.AesEncryptHex(orderId.ToString(), key);
                CacheHelp.Set(wapSpId, DateTimeOffset.Now.AddDays(1), orderId.ToString());
                return wapPay(orderList, orderId, 0, wapSpId);
            }
            else
            {
                return UserService.ckTokenState();
            }
        }
        private string wapPay(OrderListModel order, long orderId, int IsSample, string wapSpId)
        {
            return wapService.ProcessRequest(order, orderId, wapSpId);
        }
        #endregion
    }
}
