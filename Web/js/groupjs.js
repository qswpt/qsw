$(document).ready(function () {
    var typeId = getRequestParam('typeId');
    var url = '/CommodityType/GetCommodityType?size=500';
    var typeCount = 0;
    $.getJSON(url, function (data) {
        var html = "", seliIndex = 0;
        for (var i = 0; i < data.Data.length; i++) {
            if (data.Data[i].TypeId == typeId || (i == typeId && typeId == 0)) {
                seliIndex = i;
                typeId = data.Data[i].TypeId;
                html += '<li class="groupLiSe" onclick="getCommodityTypeBrandid(' + data.Data[i].TypeId + ',' + i + ')">' + data.Data[i].TypeName + '</li>';
                $('#brandName').html(data.Data[i].BrandName);
            } else {
                html += '<li class="groupLi" onclick="getCommodityTypeBrandid(' + data.Data[i].TypeId + ',' + i + ')">' + data.Data[i].TypeName + '</li>';
            }
        }
        typeCount = data.Data.length;
        getCommodityTypeDtil(typeId, 1, 5000);
        $('#groupLi').html(html);
    });
    getShopCount();
});

function getCommodityTypeBrandid(typeId, liIndex) {
    var $carousel = document.getElementById('carousel'),
     $ul = $carousel.querySelector('ul'),
     liArray = $carousel.querySelectorAll('li'), width = 0, vsrollLeft = 0;
    for (var i = 0; i < liArray.length; i++) {
        if (i == liIndex) {
            liArray[i].className = 'groupLiSe';
        } else {
            liArray[i].className = 'groupLi';
        }
    }
    getCommodityTypeDtil(typeId, 1, 5000);
}

function getCommodityTypeDtil(typeId, index, size) {
    var url = '/Commodity/GetCommodityFamily?familyId=' + typeId + '&index=' + index + '&size=' + size + '';
    $.getJSON(url, function (data) {
        var html = "";
        var topNum = 0;
        if (data.Data.length > 0) {
            for (var i = 0; i < data.Data.length; i++) {
                html += '<div style="width:100%; position:absolute; top:' + topNum + 'rem; height:6.2rem; background-color:#fff border-radius: 0.5rem;" onclick="openInfo(' + data.Data[i].CommodityId + ')">' +
                    '<div style="position:inherit; width:94%; height:6.2rem; left:0.5rem; margin-left:0rem; border-bottom:solid 1px #eeeeee; top:0rem;"><span id="sName" style="position:inherit;' +
                    ' left:0.2rem; top:0.2rem; font-size:0.75rem; color:#666666; width:100%; text-overflow:ellipsis; white-space:nowrap; word-break:keep-all;  overflow:hidden;">' + data.Data[i].CommodityName + '</span><span id="general" style="position:inherit; left:0.25rem; top:1.5rem;' +
                    ' font-size:0.7rem; color:#999999;">颜色：' + data.Data[i].CommodityGeneral + '</span><span style="position:inherit; left:0.25rem; top:2.67rem; font-size:0.7rem; color:#999999;">索引号: ' + data.Data[i].CommodityIndex + '</span>' +
                    ' <span style="position:inherit; left:0.25rem; top:3.8rem; font-size:0.7rem; color:#999999;">规格: ' + data.Data[i].CommoditySpec + data.Data[i].UnitIdName + '</span><span style="position:inherit; left:0.25rem; top:4.92rem;' +
                    ' font-size:0.7rem; color:#999999;">价格:<span style="color:red;">￥' + (data.Data[i].CommoditySpec * data.Data[i].CommodityPrice).toFixed(2) + '</span>元</span><span style="position:inherit; right:0.5rem; top:1.5rem; font-size:12px; color:#999999;">商品编码: ' + data.Data[i].CommodityCode + '</span>' +
                    '<span style="position:inherit; right:0.5rem; top:2.67rem; font-size:12px; color:#999999;">品牌: ' + data.Data[i].BrandName + '</span>' +
                     '<div style="position:inherit; right:3rem; top:3.89rem;  width:2.15rem; height:2.15rem; background-size:100% 100%; background-image:url(\'Images/ico/sp.png\')" onclick="spBuyImmediately(' + data.Data[i].CommodityId + ')"></div>' +
                    '<div style="position:inherit; right:0.75rem; top:4rem;  width:2rem; height:2rem; background-size:100% 100%; background-image:url(\'Images/ico/gwc.png\')" onclick="isShop(' + data.Data[i].CommodityId + ')">' +
                    '</div>' +
                    '</div></div>';
                topNum = topNum + 6.25;
                if (i + 1 == data.Data.length) {
                    html += ' <div id="refsh" style="position:absolute;width:100%; top:' + topNum + 'rem; height:3.125rem; background-color:#fff;"></div>';
                }
            }
        } else {
            html = " <span style=\"position:inherit; left:0px; width:100%; text-align:center; top:3.12rem;\">该商品被管家藏起来了...</span>";
        }
        //$('#ctlist').append(html);
        $('#ctlist').html(html);
    });
}
function spBuyImmediately(id) {
    BuyImmediately(id, 0, 1);
    stopBubble(event);
}