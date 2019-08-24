
$(document).ready(function () {
    var id = getRequestParam('id');
    var url = '/Commodity/GetCommodityId?id=' + id;
    $.getJSON(url, function (data) {
        $('#infoName').html(data.Data.CommodityName);
        $('#infoImg').css("background-image", 'url(Images/commodity/' + data.Data.CommodityImg + ')');
        $('#comPrice').html('￥' + (data.Data.CommoditySpec * data.Data.CommodityPrice).toFixed(2));
        $('#comName').html(data.Data.CommodityName);
        $('#comGeneral').html(data.Data.CommodityGeneral);
        $('#comBrand').html('生产商：' + data.Data.BrandName);
        $('#comSpec').html('规格：' + data.Data.CommoditySpec + data.Data.UnitIdName);
        $('#comRH').html('耐热：' + data.Data.CommodityRH);
        $('#comRM').html('耐迁移性：' + data.Data.CommodityRM);
        $('#comCode').html('编码：' + data.Data.CommodityCode);
        $('#comIndex').html('索引号：' + data.Data.CommodityIndex);
        $('#comFL').html('耐光：' + data.Data.CommodityFL);
        $('#comRemark').html(data.Data.CommodityRemark);
    });
    getShopCount();
});
function spBuyImmediately() {
    var id = getRequestParam('id');
    BuyImmediately(id, 0, 1);
}
function spBuyImmediatelySample() {
    var id = getRequestParam('id');
    BuyImmediately(id, 1, 1);
}
function setShopingCart() {
    var id = getRequestParam('id');
    isShop(id);
}