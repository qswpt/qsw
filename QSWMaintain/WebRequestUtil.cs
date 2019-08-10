using Framework.Common.Utils;
using RestSharp;
using System;

namespace QSWMaintain
{
    public class WebRequestUtil
    {
        private static int defaultSize = int.MaxValue;
        #region Brand
        public static IRestResponse GetBrandHome()
        {
            string brandHome = "/Brand/GetBrandHome";
            RestRequest request = new RestRequest(brandHome, Method.GET);
            request.AddParameter("size", defaultSize);
            var result = ExecuteRequest(ConstDefine.Client,request);
            return result;
        }

        public static IRestResponse AddBrand(string brandModelStr)
        {
            string brandHome = "/Brand/AddBrand";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("brandModelStr", brandModelStr);
            var result = ExecuteRequest(ConstDefine.Client,request);
            return result;
        }

        public static IRestResponse UpdateBrand(int id,string brandModelStr)
        {
            string brandHome = "/Brand/UpdateBrand";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("id", id);
            request.AddParameter("brandModelStr", brandModelStr);
            var result = ExecuteRequest(ConstDefine.Client,request);
            return result;
        }

        public static IRestResponse DeleteBrand(int id)
        {
            string brandHome = "/Brand/DeleteBrand";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("id", id);
            var result = ExecuteRequest(ConstDefine.Client,request);
            return result;
        }
        #endregion

        #region Commodity
        public static IRestResponse GetCommodityList()
        {
            string brandHome = "/Commodity/GetCommodityList";
            RestRequest request = new RestRequest(brandHome, Method.GET);
            request.AddParameter("index", 1);
            request.AddParameter("size", defaultSize);
            var result = ExecuteRequest(ConstDefine.Client,request);
            return result;
        }

        public static IRestResponse DeleteCommodityById(int id)
        {
            string brandHome = "/Commodity/DeleteCommodityById";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("id", id);
            var result = ExecuteRequest(ConstDefine.Client,request);
            return result;
        }

        public static IRestResponse AddCommodity(string commodityModelStr)
        {
            string brandHome = "/Commodity/AddCommodity";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("commodityModelStr", commodityModelStr);
            var result = ExecuteRequest(ConstDefine.Client,request);
            return result;
        }

        public static IRestResponse UpdateCommodity(int id,string commodityModelStr)
        {
            string brandHome = "/Commodity/UpdateCommodity";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("id", id);
            request.AddParameter("commodityModelStr", commodityModelStr);
            var result = ExecuteRequest(ConstDefine.Client,request);
            return result;
        }
        #endregion

        #region Unit
        public static IRestResponse GetUnit()
        {
            string brandHome = "/Unit/GetUnit";
            RestRequest request = new RestRequest(brandHome, Method.GET);
            request.AddParameter("size", defaultSize);
            var result = ExecuteRequest(ConstDefine.Client,request);
            return result;
        }
        #endregion

        #region CommodityType
        public static IRestResponse GetCommodityType()
        {
            string brandHome = "/CommodityType/GetCommodityType";
            RestRequest request = new RestRequest(brandHome, Method.GET);
            request.AddParameter("size", defaultSize);
            var result = ExecuteRequest(ConstDefine.Client,request);
            return result;
        }

        public static IRestResponse AddCommodityType(string commodityTypeModelStr)
        {
            string brandHome = "/CommodityType/AddCommodityType";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("commodityTypeModelStr", commodityTypeModelStr);
            var result = ExecuteRequest(ConstDefine.Client,request);
            return result;
        }

        public static IRestResponse UpdateCommodityType(int id,string commodityTypeModelStr)
        {
            string brandHome = "/CommodityType/UpdateCommodityType";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("id", id);
            request.AddParameter("commodityTypeModelStr", commodityTypeModelStr);
            var result = ExecuteRequest(ConstDefine.Client,request);
            return result;
        }

        public static IRestResponse DeleteCommodityType(int id)
        {
            string brandHome = "/CommodityType/DeleteCommodityType";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("typeId", id);
            var result = ExecuteRequest(ConstDefine.Client,request);
            return result;
        }
        #endregion

        #region Ads
        public static IRestResponse ReplaceAdsImg(int index, string imgContent)
        {
            string brandHome = "/FileUpload/ReplaceAdsImg";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("index", index);
            request.AddParameter("imgContent", imgContent);
            var result = ExecuteRequest(ConstDefine.Client,request);
            return result;
        }

        public static IRestResponse GetAdsImg(int index)
        {
            string brandHome = "/FileUpload/GetAdsImg";
            RestRequest request = new RestRequest(brandHome, Method.GET);
            request.AddParameter("index", index);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }

        public static IRestResponse ReplaceBrandImg(string previousName,string imgName, string imgContent)
        {
            string brandHome = "/FileUpload/ReplaceBrandImg";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("previousName", previousName);
            request.AddParameter("imgName", imgName);
            request.AddParameter("imgContent", imgContent);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }

        public static IRestResponse ReplaceCommodityImg(string previousName, string imgName, string imgContent)
        {
            string brandHome = "/FileUpload/ReplaceCommodityImg";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("previousName", previousName);
            request.AddParameter("imgName", imgName);
            request.AddParameter("imgContent", imgContent);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }
        #endregion

        #region RestSharp Test
        public static IRestResponse TestRequest()
        {
            string brandHome = "/category/android/";
            RestRequest request = new RestRequest(brandHome, Method.GET);
            var result = ExecuteRequest(ConstDefine.Client,request);
            return result;
        }
        #endregion

        #region Execute Wrapper
        private static IRestResponse ExecuteRequest(RestClient client,RestRequest request)
        {
            if(client == null || request == null)
            {
                throw new System.Exception("参数错误");
            }
            try
            {
               var result = client.Execute(request);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return result;
                }
                else
                {
                    return null;
                }
                    
            }
            catch (Exception ex)
            {
                LogUtil.Error(string.Format("ExecuteRequest failed!Message:{0},StackTrace:{1}",ex.Message,ex.StackTrace));
                return null;
            }
        }
        #endregion
    }
}
