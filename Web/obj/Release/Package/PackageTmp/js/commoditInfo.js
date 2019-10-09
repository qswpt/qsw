
$(document).ready(function () {
    var id = getRequestParam('id');
    var url = '/Commodity/GetCommodityId?id=' + id;
    $.getJSON(url, function (data) {
        $('#spName').html(data.Data.CommodityName);
        $('#spAmount').html('￥' + (data.Data.CommoditySpec * data.Data.CommodityPrice).toFixed(2));
        $('#psImg').css("background-image", 'url(Images/commodity/' + data.Data.CommodityImg + ')');
        $('#infoName').html(data.Data.CommodityName);
        $('#infoImg').css("background-image", 'url(Images/commodity/' + data.Data.CommodityImg + ')');
        $('#comPrice').html('￥' + (data.Data.CommoditySpec * data.Data.CommodityPrice).toFixed(2));
        $('#comName').html(data.Data.CommodityName);
        $('#comGeneral').html('颜色：' + data.Data.CommodityGeneral);
        $('#comBrand').html('品牌：' + data.Data.BrandName);
        $('#comSpec').html('规格：' + data.Data.CommoditySpec + data.Data.UnitIdName);
        $('#comRH').html('CAS：' + data.Data.CommodityRH);
        $('#comCode').html('编码：' + data.Data.CommodityCode);
        $('#comIndex').html('索引号：' + data.Data.CommodityIndex);
        $('#comFL').html('分子式：' + data.Data.CommodityFL);
        $('#comRemark').html(data.Data.CommodityRemark);
    });
});
function spBuyImmediatelySample() {
    var id = getRequestParam('id');
    BuyImmediately(id, 1, 1);
}
function showSp(tp) {
    $('#spNum').val(1);
    $('#isokBk').css({ 'display': 'block' });
    $('#psDiv').css({ 'display': 'block' });
    $('#spType').html(tp);
}
function hidebak() {
    $('#isokBk').css({ 'display': 'none' });
    $('#psDiv').css({ 'display': 'none' });
}
function btnjia() {
    var st = $('#spNum').val();
    var sts = st - 1 + 2;
    $('#spNum').val(sts);
}
function btnjian() {
    var st = $('#spNum').val();
    st = st - 1;
    if (st <= 0) {
        st = 1;
    }
    $('#spNum').val(st);
}
function goShop() {
    var tp = $('#spType').html();
    var spCount = $('#spNum').val();
    if (tp == 0) {
        var id = getRequestParam('id');
        isp(id, spCount);
    } else {
        var id = getRequestParam('id');
        GoSp(id, 0, 1, spCount);
    }
}
function isp(id, spCount) {
    var token = getCok();
    if (token == null || token == '' || token == "''") {
        window.location.href = '/login.html';
    } else {
        var url = '/Commodity/SetShopping?token=' + token + '&spId=' + id + '&spCount=' + spCount;
        $.getJSON(url, function (data) {
            if (!isPasLogin(data)) {
                if (data.Data.state) {
                    showgwcDiv();
                    hidebak();
                }
            }
        });
    }
}
function GoSp(id, spd, isource, spCount) {
    window.location.href = '/PlaceOrder.html?cmId=' + id + '&sampleId=' + spd + '&isource=' + isource + '&spCount=' + spCount;
}