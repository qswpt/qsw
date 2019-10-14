
$(document).ready(function () {
    var wapSpId = getRequestParam('wapSpId');
    var orderId = getRequestParam('orderId'); //分割逗号，根据ID加载商品 
    if (orderId > 0 && wapSpId != '') {
        var url = '/Order/wapOk?wapSpid=' + wapSpId + '&orderId=' + orderId;
        $.getJSON(url, function (data) {

        });
    }
});


function opMyOrlder() {
    window.location.href = '/MyOrder.html';
}