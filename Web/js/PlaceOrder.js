﻿
$(document).ready(function () {
    loadInfo();
});
function loadInfo() {
    var token = getCok();
    var timestamp = Date.parse(new Date());
    if (token == null || token == '' || token == "''") {
        window.location.href = '/login.html';
    } else {
        var cmId = getRequestParam('cmId'); //分割逗号，根据ID加载商品
        var sampleId = getRequestParam('sampleId'); //0正常购买,1样品
        var isource = getRequestParam('isource'); //来源，立即还是购物车
        //如果是购物车那么要把cache中的数量等信息获取出来
        //如果是购物车过来的那么数量就是1
        //用户可以调整当前的数量 
        GetPayList();
        GetExList();
        LoadAddresList();
        loadCityList();
    }
}
function showAddres() {
    $('#reAddress').css({ 'display': 'block' });
    $('#orderDiv').css({ 'display': 'none' });
}
function LoadAddresList() {
    var token = getCok();
    var timestamp = Date.parse(new Date());
    var uaddresurl = '/UserAddres/GetUserAddresList?token=' + token + '&t=' + timestamp;
    $.getJSON(uaddresurl, function (data) {
        var html = ''; var cityId = 0; var cuadd = ''; var shr = ''; var xm = ''; var dh = '';
        if (data.Data != 'null' && data.Data != '') {
            var topNum = 0;
            for (var i = 0; i < data.Data.length; i++) {
                if (i == 0 || data.Data[i].DefaultAddress == 1) {
                    cityId = data.Data[i].CityId;
                    cuadd = data.Data[i].Address;
                    shr = data.Data[i].Contacts + '&nbsp;&nbsp;' + data.Data[i].Telephone;
                    xm = data.Data[i].Contacts;
                    dh = data.Data[i].Telephone;
                }
                html = html + '<div style="position:absolute; height:4.375rem; left:0.5rem; right:0.5rem; top:' + topNum + 'rem; background-color:#fff;">' +
                              '<span id="adId' + data.Data[i].id + '" style="display:none;">' + data.Data[i].id + '</span><span id="adstate' + data.Data[i].id + '" style="display:none;">' + data.Data[i].DefaultAddress + '</span>' +
                              '<span id="adContacts' + data.Data[i].id + '" style="display:none;">' + data.Data[i].Contacts + '</span><span id="City' + data.Data[i].id + '"  style="display:none;">' + data.Data[i].CityId + '</span>' +
                              '<div style="position:absolute; width:2.5rem; height:2.5rem; top:50%; margin-top:-1.25rem; background-color:#aaaaaa; left:0.125rem; border-radius: 50%; text-align:center;">' +
                              '<span style="position:absolute; width:100%; font-size:1rem; height:1.375rem; top:50%; margin-top:-0.6875rem; left:0px; color:#fff;">' + data.Data[i].Contacts.substring(0, 1) + '</span>' +
                              '</div><div style="position:absolute; height:100%; left:2.75rem; right:2.6875rem;" onclick="seleAddres(' + data.Data[i].id + ');">' +
                              '<span style="position:absolute; left:0.5rem; top:0.25rem; font-size:1rem; width:3.75rem;white-space:nowrap; word-break:keep-all; overflow:hidden; text-overflow:ellipsis;">' + data.Data[i].Contacts + '</span>' +
                              '<span id="ph' + data.Data[i].id + '" style="position:absolute; left:4.25rem; top:0.5rem; font-size:0.75rem; color:#999999;">' + data.Data[i].Telephone + '</span>' +
                              '<span id="add' + data.Data[i].id + '" style="position:absolute; left:0.5rem; top:1.75rem; font-size:0.875rem;">' + data.Data[i].Address + '</span>' +
                              '</div><div style="position:absolute; width:2.6875rem; height:1.5rem; top:50%; margin-top:-0.75rem; right:0px; text-align:center; border-left:1px solid #dddddd;">' +
                              '<span style="color:#999999; width:100%;" onclick="editAdds(' + data.Data[i].id + ');">编辑</span></div></div>';
                topNum = topNum + 4.375;
            }
        }
        $('#cityId').html(cityId);
        $('#SpAddres').html(cuadd);
        $('#shr').html(shr);
        $('#shrxm').html(xm);
        $('#shrdh').html(dh);
        $('#addressList').html(html);
    });
}
function loadCityList() {
    var uaddresurl = '/City/GetCityList';
    $.getJSON(uaddresurl, function (data) {
        var html = '';
        if (data.Data != 'null' && data.Data != '') {
            for (var i = 0; i < data.Data.length; i++) {
                html = html + '<option value="' + data.Data[i].CityId + '">' + data.Data[i].CityName + '</option>';
            }
        }
        $('#cityList').html(html);
    });
}
function editReAddress() {
    $('#reAddress').css({ 'display': 'block' });
}
function cancelEdit() {
    $('#reAddress').css({ 'display': 'none' });
    loadInfo();
}
function cancelManagerAddres() {
    $('#orderDiv').css({ 'display': 'block' });
    $('#reAddress').css({ 'display': 'none' });

}
function editAdds(id) {
    var adId = $('#adId' + id).html();
    var adstate = $('#adstate' + id).html();
    var adContacts = $('#adContacts' + id).html();
    var ph = $('#ph' + id).html();
    var add = $('#add' + id).html();
    var city = $('#City' + id).html();
    $('#reAddress').css({ 'display': 'none' });
    $('#editAddressInfo').css({ 'display': 'block' });
    $('#edId').html(adId);
    $('#txadContacts').val(adContacts);
    $('#txph').val(ph);
    $('#txadd').val(add);
    $('#cityList').val(city);
    $('#deAdd').css({ 'display': 'block' });
    $('#txadContacts').css({ 'color': 'black' });
    $('#txph').css({ 'color': 'black' });
    $('#txadd').css({ 'color': 'black' });
    if (adstate == 0) {
        $('#stbk').css("background-image", "url(Images/ico/stClose.png)");
    } else {
        $('#stbk').css("background-image", "url(Images/ico/stOpen.png)");
    }
    $('#stv').html(adstate);
}
function addAddres() {
    $('#reAddress').css({ 'display': 'none' });
    $('#editAddressInfo').css({ 'display': 'block' });
    $('#stv').html(0);
    $('#stbk').css("background-image", "url(Images/ico/stClose.png)");
    $('#edId').html(0);
    $('#deAdd').css({ 'display': 'none' });
    $('#txadContacts').val('收货人');
    $('#txadContacts').css({ 'color': '#999999' });
    $('#txph').val('手机号码');
    $('#txph').css({ 'color': '#999999' });
    $('#txadd').val('收货详细地址...');
    $('#txadd').css({ 'color': '#999999' });
    $('#cityList').val(0);
}
function addFoucs(ty) {
    var id = $('#edId').html();
    if (id == 0) {
        var contacts = $('#txadContacts').val();
        if (contacts == '收货人' && ty == 1) {
            $('#txadContacts').val('');
            $('#txadContacts').css({ 'color': 'black' });
        }
        var txph = $('#txph').val();
        if (txph == '手机号码' && ty == 2) {
            $('#txph').val('');
            $('#txph').css({ 'color': 'black' });
        }
        var txadd = $('#txadd').val();
        if (txadd == '收货详细地址...' && ty == 3) {
            $('#txadd').val('');
            $('#txadd').css({ 'color': 'black' });
        }
    }
}
function stState() {
    var st = $('#stv').html();
    if (st == 0) {
        $('#stbk').css("background-image", "url(Images/ico/stOpen.png)");
        $('#stv').html(1);
    } else {
        $('#stbk').css("background-image", "url(Images/ico/stClose.png)");
        $('#stv').html(0);
    }
}
function cancelEditAdds() {
    $('#editAddressInfo').css({ 'display': 'none' });
    $('#reAddress').css({ 'display': 'block' });
}
function saveAddres() {
    var token = getCok();
    var adId = $('#edId').html();
    var adContacts = $('#txadContacts').val();
    var ph = $('#txph').val();
    var add = $('#txadd').val();
    var adstate = $('#stv').html();
    var city = $('#cityList').val();
    if (adContacts == '' || ph == '' || add == '' || city == '' || adContacts == null || ph == null || add == null || city == null) {
        return false;
    } else {
        var url = '';
        if (adId > 0) {
            url = '/UserAddres/UpdateUserAddres?token=' + token + '&adId=' + adId + '&Address=' + add + '&telephone=' + ph + '&contacts=' + adContacts + '&defaultAddress=' + adstate + '&city=' + city;
        } else {
            url = '/UserAddres/InserUserAddres?token=' + token + '&adId=' + adId + '&Address=' + add + '&telephone=' + ph + '&contacts=' + adContacts + '&defaultAddress=' + adstate + '&city=' + city;
        }
        $.getJSON(url, function (data) {
            if (data.Data != null && data.Data != '') {
                if (data.Data.state) {
                    LoadAddresList();
                    cancelEditAdds();
                } else {
                    alert('保存失败');
                }
            }
        });
    }
}
function deleteAddres() {
    var token = getCok();
    var adId = $('#edId').html();
    var url = '/UserAddres/DeleteUserAddres?token=' + token + '&adId=' + adId;
    $.getJSON(url, function (data) {
        if (data.Data != null && data.Data != '') {
            if (data.Data.state) {
                LoadAddresList();
                cancelEditAdds();
            } else {
                alert('删除失败');
            }
        }
    });
}
function seleAddres(id) {
    var adId = $('#adId' + id).html();
    var adContacts = $('#adContacts' + id).html();
    var add = $('#add' + id).html();
    var ph = $('#ph' + id).html();
    $('#cityId').html(adId);
    $('#SpAddres').html(add);
    $('#shr').html(adContacts + '&nbsp;&nbsp;' + ph);
    $('#shrxm').html(adContacts);
    $('#shrdh').html(ph);
    $('#reAddress').css({ 'display': 'none' });
    $('#orderDiv').css({ 'display': 'block' });
}
function sePay(id) {
    var payId = $('#payid' + id).html();
    var payname = $('#payName' + id).html();
    $('#payspId').html(payId);
    $('#payspName').html(payname);
    $('#paydivBk').css({ 'display': 'none' });
    $('#paytypeDiv').css({ 'display': 'none' });
}
function showPay() {
    $('#paydivBk').css({ 'display': 'block' });
    $('#paytypeDiv').css({ 'display': 'block' });
}
function hidPay() {
    $('#paydivBk').css({ 'display': 'none' });
    $('#paytypeDiv').css({ 'display': 'none' });
}

function GetPayList() {
    var uaddresurl = '/Payment/GetPayList';
    $.getJSON(uaddresurl, function (data) {
        var html = '';
        if (data.Data != 'null' && data.Data != '') {
            var leftNum = 0.5; var topNum = 0.5; var payid = 0; var payName = '';
            for (var i = 0; i < data.Data.length; i++) {
                if (i == 0) {
                    payid = data.Data[i].PaymentId;
                    payName = data.Data[i].PaymentName;
                }
                html = html + '<div style="position:absolute; width:5rem; height:1.875rem; left:' + leftNum + 'rem; top:' + topNum + 'rem; border-radius: 0.5rem; background-color:#c3c3c3;" onclick="sePay(' + data.Data[i].PaymentId + ')">' +
                '<span style="display:none;" id="payid' + data.Data[i].PaymentId + '">' + data.Data[i].PaymentId + '</span><span id="payName' + data.Data[i].PaymentId + '" style="font-size:0.875rem; position:absolute; width:100%; text-align:center; left:0px; top:0.25rem;">' + data.Data[i].PaymentName + '</span>' +
                '</div>';
                if ((i + 1) % 3 == 0) {
                    topNum = topNum + 2.375;
                    leftNum = 0.5;
                } else {
                    leftNum = leftNum + 5.5;
                }
            }
            $('#payspId').html(payid);
            $('#payspName').html(payName);
        }
        $('#paytypeDiv').html(html);
    });
}

function stState() {
    var st = $('#invs').html();
    if (st == 0) {
        $('#invSt').css("background-image", "url(Images/ico/stOpen.png)");
        $('#invs').html(1);
        $('#invInfoMation').css({ 'display': 'block' });
        ivnt(1);
    } else {
        $('#invSt').css("background-image", "url(Images/ico/stClose.png)");
        $('#invs').html(0);
        $('#invInfoMation').css({ 'display': 'none' });
        $('#ivnInfos').css({ 'height': '2.5rem' });
    }
}
function ivnt(id) {
    if (id == 1) {
        $('#pSp').css({ 'color': 'red' });
        $('#perDiv').css({ 'background-color': '#f8b8b8' });
        $('#cpSp').css({ 'color': '#666666' });
        $('#compDiv').css({ 'background-color': '#eeeeee' });
        perInfo();
    } else {
        $('#cpSp').css({ 'color': 'red' });
        $('#compDiv').css({ 'background-color': '#f8b8b8' });
        $('#pSp').css({ 'color': '#666666' });
        $('#perDiv').css({ 'background-color': '#eeeeee' });
        compInfo();
    }
    $('#invTId').html(id);
}
function ivTy(id) {
    if (id == 1) {
        $('#centDtlSp').css({ 'color': 'red' });
        $('#centDtl').css({ 'background-color': '#f8b8b8' });
        $('#centTypeSp').css({ 'color': '#666666' });
        $('#centType').css({ 'background-color': '#eeeeee' });
    } else {
        $('#centTypeSp').css({ 'color': 'red' });
        $('#centType').css({ 'background-color': '#f8b8b8' });
        $('#centDtlSp').css({ 'color': '#666666' });
        $('#centDtl').css({ 'background-color': '#eeeeee' });
    }
    $('#invCtId').html(id);
}
function compInfo() {
    $('#ivnInfos').css({ 'height': '20rem' });
    $('#dwInfo').css({ 'display': 'block' });
    $('#lxrinfo').css({ 'top': '8.125rem' });
    $('#ivnContent').css({ 'top': '13.75rem' });
}
function perInfo() {
    $('#ivnInfos').css({ 'height': '16.25rem' });
    $('#dwInfo').css({ 'display': 'none' });
    $('#lxrinfo').css({ 'top': '4rem' });
    $('#ivnContent').css({ 'top': '10rem' });
}
function seEx(id) {
    var exId = $('#exId' + id).html();
    var exName = $('#ExName' + id).html();
    $('#exId').html(exId);
    $('#seExName').html(exName);
    $('#exDivBk').css({ 'display': 'none' });
    $('#exListDiv').css({ 'display': 'none' });
}
function showExS() {
    $('#exDivBk').css({ 'display': 'block' });
    $('#exListDiv').css({ 'display': 'block' });
}
function hideExS() {
    $('#exDivBk').css({ 'display': 'none' });
    $('#exListDiv').css({ 'display': 'none' });
}
function GetExList() {
    var uaddresurl = '/ExLogistic/GetExLogisticList';
    $.getJSON(uaddresurl, function (data) {
        var html = '';
        if (data.Data != 'null' && data.Data != '') {
            var leftNum = 0.5; var topNum = 0.5;
            for (var i = 0; i < data.Data.length; i++) {
                html = html + '<div style="position:absolute; width:5rem; height:1.875rem; left:' + leftNum + 'rem; top:' + topNum + 'rem; border-radius: 0.5rem; background-color:#c3c3c3;" onclick="seEx(' + data.Data[i].ExId + ')">' +
                '<span style="display:none;" id="exId' + data.Data[i].ExId + '">' + data.Data[i].ExId + '</span><span id="ExName' + data.Data[i].ExId + '" style="font-size:0.875rem; position:absolute; width:100%; text-align:center; left:0px; top:0.25rem;">' + data.Data[i].ExName + '</span>' +
                '</div>';
                if ((i + 1) % 3 == 0) {
                    topNum = topNum + 2.375;
                    leftNum = 0.5;
                } else {
                    leftNum = leftNum + 5.5;
                }
            }
        }
        $('#exListDiv').html(html);
    });
}

function btnjia(id) {
    var st = $('#' + id + '11').html();
    var sts = st - 1 + 2;
    $('#' + id + '11').html(sts);
}
function btnjian(id) {
    var st = $('#' + id + '11').html();
    st = st - 1;
    if (st == 0) {
        st = 1;
    }
    $('#' + id + '11').html(st);
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
        $('#' + id).css({ 'display': 'none' });
        $('#' + id2).css({ 'display': 'none' });
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