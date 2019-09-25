﻿using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using QSW.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Qsw.Services
{
    public class wapService
    {
        public static bool ProcessRequest(OrderListModel orderList, long orderId)
        {
            DefaultAopClient client = new DefaultAopClient(wapConfig.gatewayUrl, wapConfig.app_id, wapConfig.private_key, "json", "1.0", wapConfig.sign_type, wapConfig.alipay_public_key, wapConfig.charset, false);
            AlipayTradeWapPayModel model = ConvertToModel(orderList, orderId);

            AlipayTradeWapPayRequest request = new AlipayTradeWapPayRequest();
            // 设置同步回调地址
            request.SetReturnUrl("");
            // 设置异步通知接收地址
            request.SetNotifyUrl("");
            // 将业务model载入到request
            request.SetBizModel(model);

            AlipayTradeWapPayResponse response = null;
            try
            {
                //因为是页面跳转类服务，使用pageExecute方法得到form表单后输出给前端跳转
                response = client.pageExecute(request, null, "post");
                if(response!=null)
                {
                    return response.IsError;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return true;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        //将HttpContext反射到AlipayTradeWapPayModel,只适用于普通类型,复杂类型开发者自行添加实现
        public static AlipayTradeWapPayModel ConvertToModel(OrderListModel orderList, long orderId)
        {
            AlipayTradeWapPayModel t = new AlipayTradeWapPayModel();
            t.AuthToken = string.Empty;
            t.Body = "颜料订单";
            t.GoodsType = "1";
            t.OutTradeNo = orderId.ToString();
            t.QuitUrl = "http://www.baidu.com";
            t.TimeExpire = DateTime.Now.AddMinutes(30).ToString("yyyy-MM-dd HH:mm");
            t.TimeoutExpress = DateTime.Now.AddMinutes(20).ToString("yyyy-MM-dd HH:mm");
            t.TotalAmount = orderList.OrderAmount.ToString();
            return t;
        }
    }
}