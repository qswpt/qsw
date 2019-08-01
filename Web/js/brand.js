
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
    getCommodityDtil(1, 5000);
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
            var leftNum = 2;
            if (i % 2 == 1)
                leftNum = 50.5;
            html += '<div style="width:47.5%; position:absolute; top:' + topNum + 'rem; height:13rem; left:' + leftNum + '%; background-color:#fff; border-radius: 0.5rem;" onclick="openInfo(' + data.Data[i].CommodityId + ');">' +
                '<div style="position:inherit; width:100%; height:9rem; top:0rem; left:0rem; border-radius: 0.5rem; background-size:100% 100%; background-image:url(\'Images/commodity/' + data.Data[i].CommodityImg + '\');"></div>' +
                '<div style="position:inherit; width:100%; height:5rem; left:0px; top:9.1rem;">' +
                '<span id="sName" style="position:inherit; width:98.8%; left:0.25rem; top:0.1rem; font-size:0.7rem; color:#666666;' +
                '">' + data.Data[i].CommodityName + '</span>' +
                '<span style="position:inherit;left:0.25rem; top:2.3rem; font-size:0.8rem; color:red;">￥' + (data.Data[i].CommoditySpec * data.Data[i].CommodityPrice).toFixed(2) + '元' +
                '<span style="font-size:0.12rem; color:red;">&nbsp;&nbsp;&nbsp;&nbsp;销量 2358&nbsp;</span></span>' +
                 '<span style="position:inherit; right:0.3rem; top:2.3rem; font-size:0.8rem;">...</span>' +
                '</div> </div>';
            if (i > 0 && i % 2 == 1)
                topNum = topNum + 13.6;
            if (i + 1 == data.Data.length) {
                if (i % 2 == 0)
                    topNum = topNum + 13.6;
                html += ' <div style="position:absolute;width:100%; top:' + topNum + 'rem; height:3.125rem; background-color:#fff;"></div>';
            }
        }
        $('#commodityList').html(html);
    });
}