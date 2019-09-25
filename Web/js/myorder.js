
$(document).ready(function () {
    loadOrders(0);
});

function loadOrders(orderType) {
    var token = getCok();
    if (token != null) {
        var url = '/Order/GetOrderList?orderType=' + orderType + '&token=' + token;
        $.getJSON(url, function (data) {
            loadData(data);
        });
        $('#cuType').html(orderType);
    }
}
function canceOrder(orderId) {
    var token = getCok();
    if (token != null) {
        if (confirm("是否取消该订单？")) {
            var orderType = $('#cuType').html();
            var url = '/Order/CanceOrderList?token=' + token + '&orderId=' + orderId + '&orderType=' + orderType;
            $.getJSON(url, function (data) {
                loadData(data);
            });
        }
    }
}
function gowapPay(orderId) {
    var token = getCok();
    if (token != null) {
        var orderType = $('#cuType').html();
        var url = '/Order/GetOrder?orderId=' + orderId + '&token=' + token + '&orderType=' + orderType;
        $.getJSON(url, function (data) {
            loadData(data);
        });
    }
}
function loadData(data) {
    if (!isPasLogin(data)) {
        var html = '';
        if (data != null && data.Data.length > 0) {
            for (var i = 0; i < data.Data.length; i++) {
                var wapstr = wapshow(data.Data[i].OrderState);
                html = html + ' <div style="position:inherit; left:2%; width:96%; top:8px;">' +
             '<div style="position:inherit; width:100%; height:25px; border-bottom:1px solid #eeeeee;">' +
             '<span style="position:absolute; left:0px; top:1px;">订单号：' + data.Data[i].OrderId + '</span>' +
             '<span style="position:absolute; right:18px; color:#ff6a00;">' + wapState(data.Data[i].OrderState) + '</span></div>';
                var dtl = data.Data[i].OrdrList;
                var dtlhtml = '';
                for (var x = 0; x < dtl.length; x++) {
                    dtlhtml = dtlhtml + '<div style="position:inherit; left:2%;">' +
                    '<div style="position:inherit; left:8px; top:8px; bottom:8px; height:5rem; width:5rem; background-image:url(\'Images/commodity/' + dtl[x].CommodityImg + '\'); background-size:100% 100%; border-radius: 0.5rem;"></div>' +
                    '<span style="position:absolute; left:95px; top:8px;">' + dtl[x].CommodityName + '</span>' +
                    '<span style="position:absolute; left:95px; top:32px; font-size:12px;">颜色：' + dtl[x].CommodityGeneral + '</span>' +
                    '<span style="position:absolute; left:95px; top:50px; font-size:12px;">品牌：' + dtl[x].CommodityBrandName + '</span>' +
                    '<span style="position:absolute; right:12px; top:50px;font-size:12px;">数量：' + dtl[x].CommNumber + '</span>' +
                    '<span style="position:absolute; left:95px; top:68px; font-size:12px;">规格：' + dtl[x].CommoditySpec + dtl[x].CommodityUnitName + '</span>' +
                    '<span style="position:absolute;  right:12px; top:68px; font-size:12px;">合计：<span style="color:red;">￥' + (dtl[x].CommodityPrice * dtl[x].CommoditySpec * dtl[x].CommNumber) + '</span></span>' +
                   ' <div style="position:inherit; width:100%; height:0.5rem;"></div></div>';
                }
                var exCode = data.Data[i].ExpressCode == null ? '' : data.Data[i].NameExpress + ' ' + data.Data[i].ExpressCode;
                html = html + dtlhtml + '<div style="position:inherit; width:100%; height:1rem;"></div></div>' +
               '<div style="position:inherit; width:100%; height:30px; background-color:#fff;">' +
                  '<span style="position:absolute; left:1.5rem; top:3px;">物流单号：' + exCode + '</span>' +
                  '<span style="position:absolute; right:12px; top:3px;">运费:<span style="color:red;">￥' + data.Data[i].ExpressAmount + '</span></span></div>' +
               '<div style="position:inherit; width:100%; height:30px; background-color:#fff;">' +
                  '<span style="position:absolute; right:12px; top:3px;">订单金额:<span style="color:red;">￥' + data.Data[i].OrderAmount + '</span></span></div>' +
               '<div style="position:inherit; width:100%; height:30px; display:' + wapstr + ';">' +
               '<div style="position:absolute; right:100px; top:0px; text-align:center; border-radius: 0.6rem; width:75px; height:23px; border:solid 1px #696767; color:#696767;" onclick="canceOrder(' + data.Data[i].OrderId + ');">取消订单</div>' +
               '<div style="position:absolute; right:12px; top:0px; text-align:center; border-radius: 0.6rem; width:75px; height:24px; border:solid 1px red; color:red;" onclick="gowapPay(' + data.Data[i].OrderId + ');">付款</div>' +
               '</div>' +
               '<div style="position:inherit; width:100%; height:0.5rem; background-color:#eeeeee;"></div>';
            }
        }
        $('#orderList').html(html);
    }
}
function wapState(state) {
    var str = '';
    switch (state) {
        case 0:
            str = '未支付';
            break;
        case 1:
            str = '已付款';
            break;
        case 2:
        case 3:
            str = '已发货';
            break;
    }
    return str;
}
function wapshow(state) {
    var str = 'none';
    if (state == 0) {
        str = 'block';
    }
    return str;
}