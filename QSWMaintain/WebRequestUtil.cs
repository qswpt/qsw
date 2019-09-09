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
        public static IRestResponse GetAdvType()
        {
            string requestUrl = "/Adv/GetAdvType";
            RestRequest request = new RestRequest(requestUrl, Method.GET);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }

        public static IRestResponse GetAdvList()
        {
            string brandHome = "/Adv/GetAdvList";
            RestRequest request = new RestRequest(brandHome, Method.GET);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }

        public static IRestResponse DeleteAdv(int advId)
        {
            string requestUrl = "/Adv/DeleteAdv";
            RestRequest request = new RestRequest(requestUrl, Method.POST);
            request.AddParameter("advId", advId);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }

        public static IRestResponse AddAdv(string advModelStr)
        {
            string requestUrl = "/Adv/AddAdv";
            RestRequest request = new RestRequest(requestUrl, Method.POST);
            request.AddParameter("advModelStr", advModelStr);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }

        public static IRestResponse UpdateAdv(int advId,string advModelStr)
        {
            string requestUrl = "/Adv/UpdateAdv";
            RestRequest request = new RestRequest(requestUrl, Method.POST);
            request.AddParameter("advId", advId);
            request.AddParameter("advModelStr", advModelStr);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }

        public static IRestResponse ReplaceAdsImg(int index, string imgContent)
        {
            string brandHome = "/FileUpload/ReplaceAdsImg";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("index", index);
            request.AddParameter("imgContent", imgContent);
            var result = ExecuteRequest(ConstDefine.Client,request);
            return result;
        }

        public static IRestResponse ReplaceAdsImg(string previousName, string imgName, string imgContent)
        {
            string brandHome = "/FileUpload/ReplaceAdsImg";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("previousName", previousName);
            request.AddParameter("imgName", imgName);
            request.AddParameter("imgContent", imgContent);
            var result = ExecuteRequest(ConstDefine.Client, request);
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

        public static IRestResponse GetAdsImage(string adImageName)
        {
            string brandHome = "/FileUpload/GetAdsImage";
            RestRequest request = new RestRequest(brandHome, Method.GET);
            request.AddParameter("adImageName", adImageName);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }

        public static IRestResponse DeleteAdsImage(string imageName)
        {
            string brandHome = "/FileUpload/DeleteAdsImage";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("imageName", imageName);
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

        public static IRestResponse DeleteBrandImage(string imageName)
        {
            string brandHome = "/FileUpload/DeleteBrandImage";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("imageName", imageName);
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

        public static IRestResponse DeleteCommodityImage(string imageName)
        {
            string brandHome = "/FileUpload/DeleteCommodityImage";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("imageName", imageName);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }
        #endregion

        #region City
        public static IRestResponse GetCityList()
        {
            string brandHome = "/City/GetCityList";
            RestRequest request = new RestRequest(brandHome, Method.GET);
            //request.AddParameter("size", defaultSize);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }

        public static IRestResponse AddCity(string cityName)
        {
            string brandHome = "/City/AddCity";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("cityName", cityName);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }

        public static IRestResponse UpdateCity(int cityId, string cityName)
        {
            string brandHome = "/City/UpdateCity";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("cityId", cityId);
            request.AddParameter("cityName", cityName);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }

        public static IRestResponse DeleteCity(int cityId)
        {
            string brandHome = "/City/DeleteCity";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("cityId", cityId);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }
        #endregion

        #region ExLogistic
        public static IRestResponse GetExLogisticList()
        {
            string brandHome = "/ExLogistic/GetExLogisticList";
            RestRequest request = new RestRequest(brandHome, Method.GET);
            //request.AddParameter("size", defaultSize);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }

        public static IRestResponse AddExLogistic(string exName)
        {
            string brandHome = "/ExLogistic/AddExLogistic";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("exName", exName);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }

        public static IRestResponse UpdateExLogistic(int exId, string exName)
        {
            string brandHome = "/ExLogistic/UpdateExLogistic";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("exId", exId);
            request.AddParameter("exName", exName);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }

        public static IRestResponse DeleteExLogistic(int exId)
        {
            string brandHome = "/ExLogistic/DeleteExLogistic";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("exId", exId);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }
        #endregion

        #region CityExLogisticsAmount
        public static IRestResponse GetCityExLogisticsAmountList()
        {
            string brandHome = "/CityExLogisticsAmount/GetCityExLogisticsAmountList";
            RestRequest request = new RestRequest(brandHome, Method.GET);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }
        public static IRestResponse GetCityExLogisticsAmount(int cityId, int exId)
        {
            string brandHome = "/CityExLogisticsAmount/GetCityExLogisticsAmount";
            RestRequest request = new RestRequest(brandHome, Method.GET);
            request.AddParameter("cityId", cityId);
            request.AddParameter("exId", exId);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }

        public static IRestResponse AddCityExLogisticsAmount(string cityExLogisticsAmountModelStr)
        {
            string brandHome = "/CityExLogisticsAmount/AddCityExLogisticsAmount";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("cityExLogisticsAmountModelStr", cityExLogisticsAmountModelStr);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }

        public static IRestResponse UpdateCityExLogisticsAmount(int id, string cityExLogisticsAmountModelStr)
        {
            string brandHome = "/CityExLogisticsAmount/UpdateCityExLogisticsAmount";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("id", id);
            request.AddParameter("cityExLogisticsAmountModelStr", cityExLogisticsAmountModelStr);
            var result = ExecuteRequest(ConstDefine.Client, request);
            return result;
        }

        public static IRestResponse DeleteCityExLogisticsAmount(int id)
        {
            string brandHome = "/CityExLogisticsAmount/DeleteCityExLogisticsAmount";
            RestRequest request = new RestRequest(brandHome, Method.POST);
            request.AddParameter("id", id);
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
