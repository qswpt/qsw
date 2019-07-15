
$(document).ready(function () {
    var url = '/Brand/GetBrandHome';
    $.getJSON(url, function (data) {
        var html = "";
        var leftNum = 0, topNum = 0;
        for (var i = 0; i < data.Data.length; i++) {
            html += '<div style="position:inherit; width:20%; height:82px; top:' + topNum + 'px; left:' + leftNum + '%;" onclick="openCommodity(' + data.Data[i].BrandId + ')">' +
                       '<div style="position:inherit; width:60px; height:60px; left:50%; margin-left:-30px; top:4px; background-image:url(\'Images/logo/' + data.Data[i].BrandImg + '\'); background-size:100% 100%;  border-radius: 50%;' +
                       ' -moz-border-radius: 50%; -webkit-border-radius: 50%;"></div>' +
                       '<span style="position:inherit; font-size:12px; width:100%; bottom:0px; text-align:center;">' + data.Data[i].BrandName + '</span> ' +
                '</div>';
            if (i == 4) {
                leftNum = 0;
                topNum = 88;
            } else {
                leftNum += 20;
            }
        }
        $('#advList').html(html);
    });
    getCommodityDtil(1, 3);
    getShopCount();
});

function openCommodity(id) {
    window.location.href = '/Commodity.html?brandId=' + id;
}
function getCommodityDtil(index, size) {
    var url = '/Commodity/GetCommodityList?index=' + index + '&size=' + size + '';
    $.getJSON(url, function (data) {
        var html = "";
        var topNum = 0;
        for (var i = 0; i < data.Data.length; i++) {
            html += '<div style="width:100%; position:absolute; top:' + topNum + 'rem; height:7.25rem; background-color:#fff;  border-radius: 0.5rem;" onclick="openInfo(' + data.Data[i].CommodityId + ')">' +
                '<div style="position:inherit; width:6rem; height:6rem; top:0.625rem; left:0.625rem; border-radius: 0.5rem; background-image:url(\'Images/commodity/' + data.Data[i].CommodityImg + '\');' +
                ' background-size:100% 100%;"></div><div style="position:inherit; width:68%; height:6rem; left:0px; margin-left:7rem; top:0.325rem;"><span id="sName" style="position:inherit;' +
                ' left:0.25rem; top:0.25rem; font-size:0.8rem; color:#666666;">' + data.Data[i].CommodityName + '</span><span id="general" style="position:inherit; left:0.25rem; top:1.8rem;' +
                ' font-size:0.7rem; color:#999999;">' + data.Data[i].CommodityGeneral + '</span><span style="position:inherit; left:0.25rem; top:2.97rem; font-size:0.7rem; color:#999999;">生产商: ' + data.Data[i].BrandName + '</span>' +
                ' <span style="position:inherit; left:0.25rem; top:4.1rem; font-size:0.7rem; color:#999999;">规格: ' + data.Data[i].CommoditySpec + '/' + data.Data[i].UnitIdName + '</span><span style="position:inherit; left:0.25rem; top:5.22rem;' +
                ' font-size:0.7rem; color:#999999;">价格: ￥' + (data.Data[i].CommoditySpec * data.Data[i].CommodityPrice).toFixed(2) + '元</span><span style="position:inherit; right:0.8rem; top:1.8rem; font-size:12px; color:#999999;">索引号: ' + data.Data[i].CommodityIndex + '</span>' +
                '<span style="position:inherit; right:0.8rem; top:2.97rem; font-size:12px; color:#999999;">商品编码: ' + data.Data[i].CommodityCode + '</span>' +
                '<div style="position:inherit; right:1.5rem; top:4.5rem;  width:2rem; height:2rem; background-size:100% 100%; background-image:url(\'Images/ico/gwc.png\')" onclick="isShop(' + data.Data[i].CommodityId + ')" >' +
                 '</div></div></div>';
            topNum = topNum + 8.25;
            if (i + 1 == data.Data.length) {
                html += ' <div style="position:absolute;width:100%; top:' + topNum + 'rem; height:3.125rem; background-color:#fff;"></div>';
            }
        }
        $('#commodityList').html(html);
    });
}