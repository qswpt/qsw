
function loadAdvList() {
    var url = '/Adv/GetAdvList';
    $.getJSON(url, function (data) {
        var html = "", halist = "";
        for (var i = 0; i < data.Data.length; i++) {
            var hat = "", haw = "";
            switch (data.Data[i].AdvTypeId) {
                case 1:  //品牌
                    hat = "<a href=\"/Commodity.html?brandId=" + data.Data[i].AdvInnerId + "\">";
                    haw = "</a>";
                    break;
                case 2: //商品
                    hat = "<a href=\"/CommodityInfo.html?id=" + data.Data[i].AdvInnerId + "\">";
                    haw = "</a>";
                    break;
                case 3:  //促销商品
                    break;
            }
            html = html + '<li>' + hat + '<img src="Images/Adv/' + data.Data[i].AdvImage + '" title="' + i + '">' + haw + '</li>';
            halist = halist + '<a href="#"></a>';
        }
        $('#advInfo').html('<div id="wowslider-container1"><div class="ws_images"><ul>' + html + '</ul></div><div class="ws_bullets"><div>' + halist + '</div>' +
            '</div> </div><script type="text/javascript" src="js/wowslider.js"></script><script type="text/javascript" src="js/script.js"></script>');
    });
}