
$(document).ready(function () {
    var id = getRequestParam('id');
    var url = '/Commodity/GetCommodityId?id=' + id;
    $.getJSON(url, function (data) {
        $('#infoName').html(data.Data.CommodityName);
        $('#infoImg').css("background-image", 'url(Images/commodity/' + data.Data.CommodityImg + ')');
    });
});