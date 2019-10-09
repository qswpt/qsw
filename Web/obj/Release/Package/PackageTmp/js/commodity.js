
$(document).ready(function () {
    var brandId = getRequestParam('brandId');
    var url = '/Brand/GetBrandHome?size=500';
    $.getJSON(url, function (data) {
        var html = "", seliIndex = 0;
        for (var i = 0; i < data.Data.length; i++) {
            if (data.Data[i].BrandId == brandId || (i == brandId && brandId == 0)) {
                seliIndex = i;
                brandId = data.Data[i].BrandId;
                html += ' <li class="tiltelLiSe" onclick="getCommoditByBrandid(' + data.Data[i].BrandId + ',' + i + ')">' + data.Data[i].BrandName + '</li>';
                //$('#brandName').html(data.Data[i].BrandName);
            } else {
                html += ' <li class="tiltelLi" onclick="getCommoditByBrandid(' + data.Data[i].BrandId + ',' + i + ')">' + data.Data[i].BrandName + '</li>';
            }
        }
        $('#brandUl').html(html);
        var $carousel = document.getElementById('carousel'),
       $ul = $carousel.querySelector('ul'),
       liArray = $carousel.querySelectorAll('li'), width = 0, vsrollLeft = 0;
        for (var i = 0; i < liArray.length; i++) {
            if (i == seliIndex) {
                vsrollLeft = width;
            }
            width += liArray[i].clientWidth + 16;
        }
        $ul.style.width = (width + 9) + "px";
        var carousel = new iScroll("carousel", { hScrollbar: false, vScrollbar: false, vScroll: false });
        $ul.style.transform = 'translate(-' + vsrollLeft + 'px, 0px) translateZ(0px)';
        getCommodityDtil(brandId, 1, 5000);
    });
    getShopCount();
    //判断页面滚动到顶部和底部
    //$(window).scroll(function () {
    //    var doc_height = $(document).height();
    //    var scroll_top = $(document).scrollTop();
    //    var window_height = $(window).height();

    //    if (scroll_top + window_height >= doc_height) {
    //        getNextCommodity();
    //        //alert("到底啦啦");   //翻页加载数据
    //    }
    //});  
});

function getCommoditByBrandid(brandId, liIndex) {
    var $carousel = document.getElementById('carousel'),
     $ul = $carousel.querySelector('ul'),
     liArray = $carousel.querySelectorAll('li'), width = 0, vsrollLeft = 0;
    for (var i = 0; i < liArray.length; i++) {
        if (i == liIndex) {
            liArray[i].className = 'tiltelLiSe';
        } else {
            liArray[i].className = 'tiltelLi';
        }
    }
    getCommodityDtil(brandId, 1, 5000);
}

function getCommodityDtil(brandId, index, size) {
    var url = '/Commodity/GetCommodityByBrand?brandId=' + brandId + '&index=' + index + '&size=' + size + '';
    $.getJSON(url, function (data) {
        var html = "";
        var topNum = 0;
        if (data.Data.length > 0) {
            for (var i = 0; i < data.Data.length; i++) {
                html += '<div style="width:100%; position:absolute; top:' + topNum + 'rem; height:7.25rem; background-color:#fff;  border-radius: 0.5rem;" onclick="openInfo(' + data.Data[i].CommodityId + ')">' +
                    '<div style="position:inherit; width:6rem; height:6rem; top:0.625rem; left:0.625rem; border-radius: 0.5rem; background-image:url(\'Images/commodity/' + data.Data[i].CommodityImg + '\');' +
                    ' background-size:100% 100%;"></div><div style="position:inherit; width:68%; height:6rem; left:0px; margin-left:7rem; top:0.325rem;"><span id="sName" style="position:inherit;' +
                    ' left:0.25rem; top:0.25rem; font-size:0.8rem; color:#666666;">' + data.Data[i].CommodityName + '</span><span id="general" style="position:inherit; left:0.25rem; top:1.8rem;' +
                    ' font-size:0.7rem; color:#999999;">颜色：' + data.Data[i].CommodityGeneral + '</span><span style="position:inherit; left:0.25rem; top:2.97rem; font-size:0.7rem; color:#999999;">索引号: ' + data.Data[i].CommodityIndex + '</span>' +
                    ' <span style="position:inherit; left:0.25rem; top:4.1rem; font-size:0.7rem; color:#999999;">规格: ' + data.Data[i].CommoditySpec + data.Data[i].UnitIdName + '</span><span style="position:inherit; left:0.25rem; top:5.22rem;' +
                    ' font-size:0.7rem; color:#999999;">价格:<span style="color:red;">￥' + (data.Data[i].CommoditySpec * data.Data[i].CommodityPrice).toFixed(2) + '</span>元</span><span style="position:inherit; right:0.5rem; top:1.8rem; font-size:12px; color:#999999;">商品编码: ' + data.Data[i].CommodityCode + '</span>' +
                    '<span style="position:inherit; right:0.5rem; top:2.97rem; font-size:12px; color:#999999;">品牌: ' + data.Data[i].BrandName + '</span>' +
                    '<div style="position:inherit; right:3rem; top:4.4rem;  width:2.15rem; height:2.15rem; background-size:100% 100%; background-image:url(\'Images/ico/sp.png\')" onclick="spBuyImmediately(' + data.Data[i].CommodityId + ')"></div>' +
                    '<div style="position:inherit; right:0.75rem; top:4.5rem;  width:2rem; height:2rem; background-size:100% 100%; background-image:url(\'Images/ico/gwc.png\')" onclick="isShop(' + data.Data[i].CommodityId + ')">' +
                    '</div>' +
                    '</div></div>';
                topNum = topNum + 7.25;
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
    $('#pageIndex').html(index);
}
function getNextCommodity() {
    var brandId = getRequestParam('brandId');
    var pageIndex = parseInt($('#pageIndex').html());
    getCommodityDtil(brandId, pageIndex + 1, 5000);
}
function spBuyImmediately(id) {
    BuyImmediately(id, 0, 1);
    stopBubble(event);
}

