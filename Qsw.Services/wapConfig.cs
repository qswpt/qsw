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
        public static string app_id = "2019101068191957";

        // 支付宝网关
        public static string gatewayUrl = "https://openapi.alipay.com/gateway.do";

        // 商户私钥，您的原始格式RSA2私钥
        public static string private_key = $"MIIEogIBAAKCAQEAtBB8I04Zn2/AWNaaagwOtZleItQ286RNe880dG3YGy/5bS1XUlkUEugn6vQDcW/731L3qt7wn21eJ8yvwaw7G+zU1QbJgtx5XtrQwWtCFi4eEqDHj+GA/PBaiV6mxTlV9ZgScDoA4cVdlS8zq3bZiV1Z+GWydMqBb9z+eD5R7YTwIr20w8/9wl3VyorO/4PPII8gge+dKByvT2ru0Gy1oYZbQ1hAn+3S5B0a3HErKyFfrQBEtWFf01QvS9i8J6naytm3CZ3FnVShBGrTp/1FAbP8y+2tTmuDPeXDYmagvJ+k/nB1+OE1InmcLNk07fDSxoaWQhdhEcTTe4we2+w3MwIDAQABAoIBAEUK4R6Ebsy0g9NMji7Fasp1ASRnrJ5lTJSBkcJm7+sUzRXwwb/AijLps4yifcN8Rd6OqIprK2ZmAClQkb+4M330pHL+RDwaH6ugSVUwtEle64cHAR4JQHU8D+sGUPnkjzI5WjCP/RCUpdpzG+POEYFbOwlErVWc5F6pJSWj97QTlPzzW/r4OdPALZqHE1tz4yllG8l/lVBC9jaKJhEosE7/cf16MAE6Z1kk8kLx+BUxifLrf5V3sHvfK7IJcpiN9t+GXqMJq0E7KKDaBH1PYmyUvushxw8th5id38S6PaSgN6U4HwaC0rcLWf9yLAD1buvTFDzQSMHneGoQpYlFgTkCgYEA6CxuqoXL1nmq2PCLwy8XfCfDxDrkXGywpdOrokOCFbx79CZftBxv4lmB+tNj6Qdn4KFIeP9B+JzimYuSOntKfskVppERfNwAOA0AcS0D3gAfUqPezVv9ylLI8D6TpGzmeq/3AXLmz8E5vbUfEs2IW4DWIF/YjxR3xJfoAs4UktUCgYEAxosP5iUTRg957zlIWIz61wyOJG8be71DXS2gV+qffM1bfBRmxaFeFnvppU73Pjc6KX9KMbfxhPwdLSJbyrT+3BQMwp1H32M5ZPZzjMZ24jk5BgxhxzZc0t1DWYbDsMNFRS/NbXzSNuf6RJ5/rFktnUTK9RXMdeSlJUky7mevVecCgYAQ3dF4T9n8DcCsm+T7W/tvyI+/PKwETt0SXus0EYVswNGcbgE722kBX5FCwIKcli4ksnLKX3jSb8tCblJEL1q9FSyeeiF0GaNmbwNeNW/3e7jKzx7LemhYf2UbluAw7Lxdo1TlZQyBgT8JmhPU0NucEiL8HRplYo5E2OhA8+motQKBgDxeVjQ9O7IGzKWPfk7mdvLib2nmmq2yK4Rudh2lSl8xNcrxjRo0aZ5eiPlpnEW/lyC9AntBmd88pUZu9wgYppGWSxb1qb/jtLTdNt8sDUPV8F/FbgmbnvfCrVLQZjod9bcGxOiwll55hKBOrTVjXDpAi5Gf0i5amlhO/Hx+7FIrAoGAU/LsjtdgY+4G0R3mkjyC32MrNdaTRQrvufMjvgjXxsdtjUCtJSQkjn+onneOB+VES9IbT6p2V4mbOKFoF4oRx3OU7B39TCyfDzzJLc6nO2/Pbag5keYC7J3MYWvbq8qm0+Z0aIOHaWSy2MImndVoxmPgDErt4NbnrAMkYwovamE=";

        // 支付宝公钥,查看地址：https://openhome.alipay.com/platform/keyManage.htm 对应APPID下的支付宝公钥。
        public static string alipay_public_key = $"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtBB8I04Zn2/AWNaaagwOtZleItQ286RNe880dG3YGy/5bS1XUlkUEugn6vQDcW/731L3qt7wn21eJ8yvwaw7G+zU1QbJgtx5XtrQwWtCFi4eEqDHj+GA/PBaiV6mxTlV9ZgScDoA4cVdlS8zq3bZiV1Z+GWydMqBb9z+eD5R7YTwIr20w8/9wl3VyorO/4PPII8gge+dKByvT2ru0Gy1oYZbQ1hAn+3S5B0a3HErKyFfrQBEtWFf01QvS9i8J6naytm3CZ3FnVShBGrTp/1FAbP8y+2tTmuDPeXDYmagvJ+k/nB1+OE1InmcLNk07fDSxoaWQhdhEcTTe4we2+w3MwIDAQAB";

        // 签名方式
        public static string sign_type = "RSA2";

        // 编码格式
        public static string charset = "UTF-8";

        //服务器异步回调地址
        public static string NOTIFY_URL = "";

        //服务器同步回跳地址
        public static string RETURN_URL = "http://m.gdshiyanwang.com/wapReturn.html?wapSpId={0}&orderId={1}";
    }
}
