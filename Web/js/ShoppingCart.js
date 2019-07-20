
$(document).ready(function () {
    var token = getCok();
    if (token == null || token == '') {
        window.location.href = '/login.html';
    } else {
        var url = '/Commodity/GetShoppingList?token=' + token;
        $.getJSON(url, function (data) {
            if (data.Data != 'null') {
                loadDataList(data);
            }
        });
    }
});

function loadDataList(data) {
    var html = "", spIdList = '', seliIndex = 0, dtop = 0;
    for (var i = 0; i < data.Data.length; i++) {
        if (spIdList == '') {
            spIdList = data.Data[i].CommodityId;
        } else {
            spIdList = spIdList + ',' + data.Data[i].CommodityId;
        }
        html = html +
            '<div style="width:94%; position:absolute; left:3%; right:3%; top:' + dtop + 'rem; height:7.25rem; background-color:#fff;  border-radius: 0.5rem;">' +
               '<div id="' + data.Data[i].CommodityId + '" style="position:absolute; left:0.25rem; width:1.5rem; height:1.5rem; top:50%; margin-top:-0.75rem; background-image:url(\'Images/ico/ckY.png\');' +
                   ' background-size:100% 100%;" onclick="ckeClick(' + data.Data[i].CommodityId + ')"><span id="' + data.Data[i].CommodityId + '1" style="display:none;">0</span> </div> ' +
                   '<div style="position:inherit; width:5.5rem; height:5.5rem; top:0.89rem; left:2rem; border-radius: 0.5rem; background-image:url(\'Images/commodity/' + data.Data[i].CommodityImg + '\'); background-size:100% 100%;"></div>' +
                   ' <div style="position:inherit; width:66%; height:6rem; left:0px; margin-left:7.5rem; top:0.325rem;"> ' +
                   '<span id="sName" style="position:inherit; left:0.25rem; top:0.25rem; font-size:0.8rem; color:#666666;">' + data.Data[i].CommodityName + '</span>' +
                   '<span id="general" style="position:inherit; left:0.25rem; top:1.8rem; font-size:0.7rem; color:#999999;">' + data.Data[i].CommodityGeneral + '</span>' +
                   '<span style="position:inherit; left:0.25rem; top:2.97rem; font-size:0.7rem; color:#999999;">生产商: ' + data.Data[i].BrandName + '</span>' +
                   '<span style="position:inherit; left:0.25rem; top:4.1rem; font-size:0.7rem; color:#999999;">规格: ' + data.Data[i].CommoditySpec + data.Data[i].UnitIdName + '</span>' +
                   '<span style="position:inherit; left:0.25rem; top:5.22rem; font-size:0.7rem; color:#999999;">价格:<span style="color:red;">￥</span>' +
                      '<span id="' + data.Data[i].CommodityId + '111" style="color:red;">' + (data.Data[i].CommoditySpec * data.Data[i].CommodityPrice).toFixed(2) + '</span>元</span>' +
                   '<span style="position:inherit; right:0.8rem; top:1.8rem; font-size:0.75rem; color:#999999;">索引号: ' + data.Data[i].CommodityIndex + '</span>' +
                   '<span style="position:inherit; right:0.8rem; top:2.97rem; font-size:0.75rem; color:#999999;">商品编码: ' + data.Data[i].CommodityCode + '</span>' +
                   '<div style="position:inherit; right:0.55rem; top:4.8rem;  width:5rem; height:1.3rem; border:1px solid #D9D9D9;  border-radius: 0.5rem;">' +
                   '<div style="position:inherit; left:0px; width:30%; height:100%; border-right:1px solid #D9D9D9; background-image:url(\'Images/ico/jian.png\'); background-size:100% 100%;"' +
                   'onclick="btnjian(' + data.Data[i].CommodityId + ')"></div><div style="position:inherit; left:30%; width:40%; height:100%;"><span id="' + data.Data[i].CommodityId + '11" style="position:inherit; width:100%; height:80%; text-align:center;' +
                   'top:20%; font-size:0.8125rem; color:#999999;" onclick="setCount(' + data.Data[i].CommodityId + ', \'inCount\', \'inBg\')">' + data.Data[i].SpCount + '</span></div><div style="position:inherit; left:70%; width:30%; height:100%;' +
                   ' border-left:1px solid #D9D9D9; background-image:url(\'Images/ico/jia.png\'); background-size:100% 100%;" onclick="btnjia(' + data.Data[i].CommodityId + ')"></div></div></div></div>';
        dtop = dtop + 7.75;
        if (i + 1 == data.Data.length) {
            html += ' <div style="position:absolute;width:100%; top:' + dtop + 'rem; height:3.125rem; background-color:#f0f0f0;"></div>';
        }
    }
    if (data.Data.length > 0) {
        $('#spCount').html('购物车<span style="font-size:0.875rem;">(' + data.Data.length + ')</span>');
    } else {
        $('#spCount').html('购物车');
    }
    $('#spListInfo').html(html);
    $('#spIdList').html(spIdList);
}

function ckeClick(id) {
    var st = $('#' + id + '1').html();
    if (st == 0) {
        $('#' + id + '').css("background-image", "url(Images/ico/checked.png)");
        $('#' + id + '1').html(1);
    } else {
        $('#' + id + '').css("background-image", "url(Images/ico/ckY.png)");
        $('#' + id + '1').html(0);
    }
    getCkAmout();
}
function cheAllClick() {
    var idSp = $('#spIdList').html();
    var ckS = $('#01').html();
    if (idSp != null) {
        var idArr = idSp.split(',');
        for (var i = 0; i < idArr.length; i++) {
            ckeSelect(idArr[i], ckS);
        }
    }
    getCkAmout();
}
function getCkAmout() {
    var idSp = $('#spIdList').html();
    if (idSp != null) {
        var idArr = idSp.split(',');
        var isAll = true;
        var allAmout = 0, seCount = 0;
        for (var i = 0; i < idArr.length; i++) {
            var ckstate = $('#' + idArr[i] + '1').html();
            if (ckstate == 1) {
                var comPrice = $('#' + idArr[i] + '111').html();
                var comCount = $('#' + idArr[i] + '11').html();
                allAmout = allAmout + comPrice * comCount;
                seCount++;
            } else {
                isAll = false;
            }
        }
        $('#spAmout').html(allAmout.toFixed(2));
        if (seCount == 0) {
            $('#jsCount').html('结算');
        } else {
            $('#jsCount').html('结算(' + seCount + ')');
        }
        if (isAll) {
            $('#0').css("background-image", "url(Images/ico/checked.png)");
            $('#01').html(1);
        } else {
            $('#0').css("background-image", "url(Images/ico/ckY.png)");
            $('#01').html(0);
        }
    }
}
function ckeSelect(id, st) {
    $('#' + id + '1').html(st);
    if (st == 0) {
        $('#' + id + '').css("background-image", "url(Images/ico/checked.png)");
        $('#' + id + '1').html(1);
    } else {
        $('#' + id + '').css("background-image", "url(Images/ico/ckY.png)");
        $('#' + id + '1').html(0);
    }
}

function btnjia(id) {
    var st = $('#' + id + '11').html();
    var sts = st - 1 + 2;
    upComCount(id, sts);
    $('#' + id + '11').html(sts);
    getCkAmout();
}
function btnjian(id) {
    var st = $('#' + id + '11').html();
    st = st - 1;
    if (st == 0) {
        st = 1;
    }
    upComCount(id, st);
    $('#' + id + '11').html(st);
    getCkAmout();
}

function canceInput(id, id2) {
    $('#' + id).css({ 'display': 'none' });
    $('#' + id2).css({ 'display': 'none' });
}
function btnInput(id, id2) {
    var num = $('#txtSpCount').val();
    if (num == 0) {
        alert('数量必须大于0');
    } else {
        var cmid = $('#cmId').html();
        $('#' + cmid + '11').html(num);
        upComCount(cmid, num);
        $('#' + id).css({ 'display': 'none' });
        $('#' + id2).css({ 'display': 'none' });
        getCkAmout();
    }
}
function setCount(cmid, id, id2) {
    $('#' + id).css({ 'display': 'block' });
    $('#' + id2).css({ 'display': 'block' });
    var num1 = $('#' + cmid + '11').html();
    $('#txtSpCount').val(num1);
    $('#cmId').html(cmid);
    $('#txtSpCount').focus();
}
function upComCount(cmid, cmCount) {
    var token = getCok();
    if (token == null || token == '') {
        window.location.href = '/login.html';
    } else {
        var url = '/Commodity/SetShoppingCount?token=' + token + '&spId=' + cmid + '&spCount=' + cmCount;
        $.getJSON(url, function (data) {
            if (data.Data.state) {

            }
        });
    }
}
function deleteCom() {
    var idSp = $('#spIdList').html();
    if (idSp != null) {
        var idArr = idSp.split(',');
        var idStr = '';
        for (var i = 0; i < idArr.length; i++) {
            var ckstate = $('#' + idArr[i] + '1').html();
            if (ckstate == 1) {
                if (idStr == '') {
                    idStr = idArr[i];
                } else {
                    idStr = idStr + ',' + idArr[i];
                }
            }
        }
        if (idStr != '') {
            deleByid(idStr);
        }
    }
    showDInfo();
}
function deleByid(idStr) {
    var token = getCok();
    if (token == null || token == '') {
        window.location.href = '/login.html';
    } else {
        var url = '/Commodity/DeleteShopping?idStr=' + idStr + '&token=' + token;
        $.getJSON(url, function (data) {
            if (data.Data != 'null') {
                loadDataList(data);
            } else {
                $('#spCount').html('购物车');
                $('#spListInfo').html('');
                $('#spIdList').html('');
            }
            getCkAmout();
        });
    }
}
function deleAllCom() {
    var token = getCok();
    if (token == null || token == '') {
        window.location.href = '/login.html';
    } else {
        var url = '/Commodity/DeleteAllShopping?token=' + token;
        $.getJSON(url, function (data) {
            $('#spCount').html('购物车');
            $('#spListInfo').html('');
            $('#spIdList').html('');
            getCkAmout();
        });
    }
    showClerInfo();
}
function editComList() {
    var st = $('#speditState').html();
    if (st == 0) {
        $('#spEdit').html('完成');
        $('#allCler').css({ 'display': 'block' });
        $('#dele').css({ 'display': 'block' });
        $('#adiv').css({ 'display': 'none' });
        $('#jsdiv').css({ 'display': 'none' });
        $('#speditState').html(1);
    } else {
        $('#spEdit').html('编辑');
        $('#allCler').css({ 'display': 'none' });
        $('#dele').css({ 'display': 'none' });
        $('#adiv').css({ 'display': 'block' });
        $('#jsdiv').css({ 'display': 'block' });
        $('#speditState').html(0);
    }
}
function showDInfo() {
    var st = $('#deState').html();
    if (st == 0) {
        $('#deState').html(1);
        $('#deBg').css({ 'display': 'block' });
        $('#indelete').css({ 'display': 'block' });
        $('#deCom').css({ 'display': 'block' });
        $('#showInfoSp').html('确认将选择的商品删除？');
        $('#deCler').css({ 'display': 'none' });
    } else {
        $('#deState').html(0);
        $('#deBg').css({ 'display': 'none' });
        $('#indelete').css({ 'display': 'none' });
        $('#deCom').css({ 'display': 'none' });
    }
}
function showClerInfo() {
    var st = $('#deState').html();
    if (st == 0) {
        $('#deState').html(1);
        $('#deBg').css({ 'display': 'block' });
        $('#indelete').css({ 'display': 'block' });
        $('#deCler').css({ 'display': 'block' });
        $('#showInfoSp').html('确认清空购物车所有商品？');
        $('#deCom').css({ 'display': 'none' });
    } else {
        $('#deState').html(0);
        $('#deBg').css({ 'display': 'none' });
        $('#indelete').css({ 'display': 'none' });
        $('#deCler').css({ 'display': 'none' });
    }
}