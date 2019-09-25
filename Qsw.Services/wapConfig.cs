using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qsw.Services
{
    public class wapConfig
    {
        // 应用ID,您的APPID
        public static string app_id = "";

        // 支付宝网关
        public static string gatewayUrl = "https://openapi.alipay.com/gateway.do";

        // 商户私钥，您的原始格式RSA2私钥
        public static string private_key = "";

        // 支付宝公钥,查看地址：https://openhome.alipay.com/platform/keyManage.htm 对应APPID下的支付宝公钥。
        public static string alipay_public_key = "";

        // 签名方式
        public static string sign_type = "RSA2";

        // 编码格式
        public static string charset = "UTF-8";

        //服务器异步回调地址
        public static string NOTIFY_URL = "";

        //服务器同步回跳地址
        public static string RETURN_URL = "http://localhost:30319/net/returnUrl.htm";
    }
}
