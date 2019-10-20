
$(document).ready(function () {
    var id = getRequestParam('id');
    var idArr = id.split('t');
    var timestamp = Date.parse(new Date());
    var url = '/Commodity/GetCommodityId?id=' + idArr[0] + '&t=' + timestamp;
    $.getJSON(url, function (data) {
        UM.getEditor('myEditor').setContent(data.Data.CommodityRemark);
    })
});
function getTxtinfo() {
    var str = UM.getEditor('myEditor').getContent();
    $('#cmtxt').html(str);
}