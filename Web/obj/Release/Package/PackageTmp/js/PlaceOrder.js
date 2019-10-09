
$(document).ready(function () {
    loadInfo();
});
function loadInfo() {
    var token = getCok();
    var timestamp = Date.parse(new Date());
    if (token != null) {
        var cmId = getRequestParam('cmId'); //分割逗号，根据ID加载商品
        var sampleId = getRequestParam('sampleId'); //0正常购买,1样品
        var isource = getRequestParam('isource'); //来源，立即还是购物车       
        if (isource == 1) {
            loadCompat(cmId);
        } else {
            loadCmList(cmId, token);
        }
        if (sampleId == 0) {
            GetPayList();
            GetExList();
        }
        LoadAddresList();
        loadCityList();
    }
}
function showAddres() {
    $('#reAddress').css({ 'display': 'block' });
    //$('#orderDiv').css({ 'display': 'none' });
}
function LoadAddresList() {
    var token = getCok();
    var timestamp = Date.parse(new Date());
    var uaddresurl = '/UserAddres/GetUserAddresList?token=' + token + '&t=' + timestamp;
    $.getJSON(uaddresurl, function (data) {
        if (!isPasLogin(data)) {
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
                    html = html + '<div style="position:absolute; height:3.5rem; left:0.5rem; right:0.5rem; top:' + topNum + 'rem; background-color:#fff;">' +
                                  '<span id="adId' + data.Data[i].id + '" style="display:none;">' + data.Data[i].id + '</span><span id="adstate' + data.Data[i].id + '" style="display:none;">' + data.Data[i].DefaultAddress + '</span>' +
                                  '<span id="adContacts' + data.Data[i].id + '" style="display:none;">' + data.Data[i].Contacts + '</span><span id="City' + data.Data[i].id + '"  style="display:none;">' + data.Data[i].CityId + '</span>' +
                                  '<div style="position:absolute; width:2.5rem; height:2.5rem; top:50%; margin-top:-1.25rem; background-color:#aaaaaa; left:0.125rem; border-radius: 50%; text-align:center;">' +
                                  '<span style="position:absolute; width:100%; font-size:1rem; height:1.375rem; top:50%; margin-top:-0.6875rem; left:0px; color:#fff;">' + data.Data[i].Contacts.substring(0, 1) + '</span>' +
                                  '</div><div style="position:absolute; height:100%; left:2.75rem; right:2rem;" onclick="seleAddres(' + data.Data[i].id + ');">' +
                                  '<span style="position:absolute; left:0.5rem; top:0.25rem; font-size:0.75rem; width:2.7rem;white-space:nowrap; word-break:keep-all; overflow:hidden; text-overflow:ellipsis;">' + data.Data[i].Contacts + '</span>' +
                                  '<span id="ph' + data.Data[i].id + '" style="position:absolute; left:3.5rem; top:0.3rem; font-size:0.75rem; color:#999999;">' + data.Data[i].Telephone + '</span>' +
                                  '<span id="add' + data.Data[i].id + '" style="position:absolute; left:0.5rem; top:1.3rem; font-size:0.75rem;">' + data.Data[i].Address + '</span>' +
                                  '</div><div style="position:absolute; width:2rem; height:1.5rem; top:50%; margin-top:-0.75rem; right:0px; text-align:center; border-left:1px solid #dddddd;">' +
                                  '<span style="color:#999999; width:100%;  font-size:0.75rem;" onclick="editAdds(' + data.Data[i].id + ');">编辑</span></div></div>';
                    topNum = topNum + 3.5;
                }
            }
            $('#cityId').html(cityId);
            $('#SpAddres').html(cuadd);
            $('#shr').html(shr);
            $('#shrxm').html(xm);
            $('#shrdh').html(dh);
            $('#addressList').html(html);
        }
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
            if (!isPasLogin(data)) {
                if (data.Data != null && data.Data != '') {
                    if (data.Data.state) {
                        LoadAddresList();
                        cancelEditAdds();
                    } else {
                        alert('保存失败');
                    }
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
        if (!isPasLogin(data)) {
            if (data.Data != null && data.Data != '') {
                if (data.Data.state) {
                    LoadAddresList();
                    cancelEditAdds();
                } else {
                    alert('删除失败');
                }
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
    loadExAmount();
}
function sePay(id) {
    var payId = $('#payid' + id).html();
    var payname = $('#payName' + id).html();
    $('#payspId').html(payId);
    $('#payspName').html(payname);
    $('#paydivBk').css({ 'display': 'none' });
    $('#paytypeDiv').css({ 'display': 'none' });
    $('#pay' + id).prop("checked", "true");
}
function showPay() {
    var sampleId = getRequestParam('sampleId');
    if (sampleId == 0) {
        $('#paydivBk').css({ 'display': 'block' });
        $('#paytypeDiv').css({ 'display': 'block' });
    }
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
            var leftNum = 0; var topNum = 0.5; var payid = 0; var payName = '';
            for (var i = 0; i < data.Data.length; i++) {
                if (i == 0) {
                    payid = data.Data[i].PaymentId;
                    payName = data.Data[i].PaymentName;
                }
                html = html + '<div style="position:absolute; width:100%; height:1.875rem; left:' + leftNum + 'rem; top:' + topNum + 'rem; border-bottom:1px solid #eeeeee;" onclick="sePay(' + data.Data[i].PaymentId + ')">' +
                '<span style="display:none;" id="payid' + data.Data[i].PaymentId + '">' + data.Data[i].PaymentId + '</span><input type="radio" style="position:absolute; left:0.5rem; top:1px;" name="cheakRadios" id="pay' + data.Data[i].PaymentId + '" /><span id="payName' + data.Data[i].PaymentId + '" style="font-size:0.75rem; position:absolute; width:100%; left:1.75rem;  top:0.1rem;">' + data.Data[i].PaymentName + '</span>' +
                '</div>';
                topNum = topNum + 2.375;
            }
            $('#payspId').html(payid);
            $('#payspName').html(payName);
        }
        $('#paylist').html(html);
    });
}

function stState() {
    var st = $('#invs').html();
    var opinvce = $('#opInvoce').html();
    if (opinvce == 0) {
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
    $('#ex' + id).prop("checked", "true");
    loadExAmount();
}
function showExS() {
    var sampleId = getRequestParam('sampleId');
    if (sampleId == 0) {
        $('#exDivBk').css({ 'display': 'block' });
        $('#exListDiv').css({ 'display': 'block' });
    }
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
            var leftNum = 0; var topNum = 0.5;
            for (var i = 0; i < data.Data.length; i++) {
                html = html + '<div style="position:absolute; width:100%; height:1.875rem; left:' + leftNum + 'rem; top:' + topNum + 'rem; border-bottom:1px solid #eeeeee;" onclick="seEx(' + data.Data[i].ExId + ')">' +
                '<span style="display:none;" id="exId' + data.Data[i].ExId + '">' + data.Data[i].ExId + '</span><input type="radio" style="position:absolute; left:0.5rem; top:1px;" name="cheakRadios" id="ex' + data.Data[i].ExId + '" /><span id="ExName' + data.Data[i].ExId + '" style="font-size:0.75rem; position:absolute; width:95%; left:1.75rem; top:0.1rem;">' + data.Data[i].ExName + '</span>' +
                '</div>';
                topNum = topNum + 2.375;
            }
        }
        $('#exlist').html(html);
    });
}

function btnjia(id) {
    var cmgj = $('#gj' + id).html();
    var st = $('#' + id + '11').html();
    var sts = st - 1 + 2;
    $('#cmgj' + id).html(cmgj * sts);
    $('#' + id + '11').html(sts);
    getAmout();
}
function btnjian(id) {
    var cmgj = $('#gj' + id).html();
    var st = $('#' + id + '11').html();
    st = st - 1;
    if (st == 0) {
        st = 1;
    }
    $('#cmgj' + id).html(cmgj * st);
    $('#' + id + '11').html(st);
    getAmout();
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
        var cmgj = $('#gj' + id).html();
        $('#cmgj' + id).html(cmgj * num);
        $('#' + cmid + '11').html(num);
        $('#' + id).css({ 'display': 'none' });
        $('#' + id2).css({ 'display': 'none' });
        getAmout();
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

function loadCompat(cmid) {
    var timestamp = Date.parse(new Date());
    var uaddresurl = '/Commodity/GetCommodityId?id=' + cmid + '&t=' + timestamp;
    var spCount = getRequestParam('spCount');
    var sampleId = getRequestParam('sampleId');
    spCount = spCount == 0 ? 1 : spCount;
    $.getJSON(uaddresurl, function (data) {
        var html = ''; var allAmout = 0; var jiaShow = 'block'; var price = 0; var ex = '配送方式'; var waptext = '支付方式';
        if (data.Data != 'null' && data.Data != '') {
            if (sampleId == 1) {
                jiaShow = 'none';
                price = 0;
                $('#opInvoce').html(1);
                ex = '配送方式由商家指定';
                waptext = '样品配送费用到付';
            } else {
                price = (data.Data.CommoditySpec * data.Data.CommodityPrice).toFixed(2);
                $('#opInvoce').html(0);
            }
            html = '<div style="width:100%; height:7.25rem; background-color:#fff;  border-radius: 0.5rem;">' +
            '<div style="position:relative; width:100%; left:0px; top:0px;">' +
               '<div style="position:absolute; width:5.5rem; height:5.5rem; top:0.89rem; left:0.5rem; border-radius: 0.5rem; background-image:url(\'Images/commodity/' + data.Data.CommodityImg + '\'); background-size:100% 100%;"></div>' +
                '<div style="position:absolute; width:70%; height:6rem; left:0px; margin-left:6.5rem; top:0.325rem;">' +
                    '<span style="position:inherit; left:0.25rem; top:0.25rem; font-size:0.8rem; color:#666666;">' + data.Data.CommodityName + '</span>' +
                    '<span style="position:inherit; left:0.25rem; top:1.8rem; font-size:0.7rem; color:#999999;">' + data.Data.CommodityGeneral + '</span>' +
                    '<span style="position:inherit; left:0.25rem; top:2.97rem; font-size:0.7rem; color:#999999;">生产商: ' + data.Data.BrandName + '</span>' +
                    '<span id="gj' + data.Data.CommodityId + '" style="display:none;">' + data.Data.CommoditySpec + '</span><span id="cmgj' + data.Data.CommodityId + '" style="display:none;">' + data.Data.CommoditySpec * spCount + '</span>' +
                    '<span style="position:inherit; left:0.25rem; top:4.1rem; font-size:0.7rem; color:#999999;">规格: ' + data.Data.CommoditySpec + data.Data.UnitIdName + '</span>' +
                    '<span style="position:inherit; left:0.25rem; top:5.22rem; font-size:0.7rem; color:#999999;">价格:<span style="color:red;">￥</span><span id="' + data.Data.CommodityId + '111" style="color:red;">' + price + '</span>元</span>' +
                    '<span style="position:inherit; right:0.8rem; top:1.8rem; font-size:0.75rem; color:#999999;">索引号: ' + data.Data.CommodityIndex + '</span>' +
                    '<span style="position:inherit; right:0.8rem; top:2.97rem; font-size:0.75rem; color:#999999;">商品编码: ' + data.Data.CommodityCode + '</span>' +
                    '<div style="position:inherit; right:0.7rem; top:4.8rem;  width:5rem; height:1.3rem; border:1px solid #D9D9D9;  border-radius: 0.5rem; display:' + jiaShow + ';">' +
                    '<div style="position:inherit; left:0px; width:30%; height:100%; border-right:1px solid #D9D9D9; background-image:url(\'Images/ico/jian.png\'); background-size:100% 100%;" onclick="btnjian(' + data.Data.CommodityId + ');"></div>' +
                    '<div style="position:inherit; left:30%; width:40%; height:100%;"><span id="' + data.Data.CommodityId + '11" style="position:inherit; width:100%; height:80%; text-align:center; top:20%; font-size:0.8125rem; color:#999999;" onclick="setCount(' + data.Data.CommodityId + ', \'inCount\', \'inBg\')">' + spCount + '</span></div>' +
                    '<div style="position:inherit; left:70%; width:30%; height:100%; border-left:1px solid #D9D9D9; background-image:url(\'Images/ico/jia.png\'); background-size:100% 100%;" onclick="btnjia(' + data.Data.CommodityId + ');"></div>' +
                    '</div></div></div></div>';
            allAmout = price;
        }
        $('#seExName').html(ex);
        $('#payspName').html(waptext);
        $('#selAmount').html(allAmout);
        $('#shopList').html(html);
    });
}
function loadCmList(cmid, token) {
    var timestamp = Date.parse(new Date());
    var uaddresurl = '/Commodity/GetShoppingInId?token=' + token + '&idlist=' + cmid + '&t=' + timestamp;
    $.getJSON(uaddresurl, function (data) {
        if (!isPasLogin(data)) {
            var html = ''; var allAmout = 0;
            if (data.Data != 'null' && data.Data != '') {
                for (var i = 0; i < data.Data.length; i++) {
                    html = html + '<div style="width:100%; height:7.25rem; background-color:#fff;  border-radius: 0.5rem;">' +
                    '<div style="position:relative; width:100%; left:0px; top:0px;">' +
                       '<div style="position:absolute; width:5.5rem; height:5.5rem; top:0.89rem; left:0.5rem; border-radius: 0.5rem; background-image:url(\'Images/commodity/' + data.Data[i].CommodityImg + '\'); background-size:100% 100%;"></div>' +
                        '<div style="position:absolute; width:70%; height:6rem; left:0px; margin-left:6.5rem; top:0.325rem;">' +
                            '<span style="position:inherit; left:0.25rem; top:0.25rem; font-size:0.8rem; color:#666666;">' + data.Data[i].CommodityName + '</span>' +
                            '<span style="position:inherit; left:0.25rem; top:1.8rem; font-size:0.7rem; color:#999999;">颜色：' + data.Data[i].CommodityGeneral + '</span>' +
                            '<span style="position:inherit; left:0.25rem; top:2.97rem; font-size:0.7rem; color:#999999;">索引号: ' + data.Data[i].CommodityIndex + '</span>' +
                             '<span id="gj' + data.Data[i].CommodityId + '" style="display:none;">' + data.Data[i].CommoditySpec + '</span><span id="cmgj' + data.Data[i].CommodityId + '" style="display:none;">' + data.Data[i].CommoditySpec * data.Data[i].SpCount + '</span>' +
                            '<span style="position:inherit; left:0.25rem; top:4.1rem; font-size:0.7rem; color:#999999;">规格: ' + data.Data[i].CommoditySpec + data.Data[i].UnitIdName + '</span>' +
                            '<span style="position:inherit; left:0.25rem; top:5.22rem; font-size:0.7rem; color:#999999;">价格:<span style="color:red;">￥</span><span id="' + data.Data[i].CommodityId + '111" style="color:red;">' + (data.Data[i].CommoditySpec * data.Data[i].CommodityPrice).toFixed(2) + '</span>元</span>' +
                            '<span style="position:inherit; right:0.8rem; top:1.8rem; font-size:0.75rem; color:#999999;">商品编码: ' + data.Data[i].CommodityCode + '</span>' +
                            '<span style="position:inherit; right:0.8rem; top:2.97rem; font-size:0.75rem; color:#999999;">品牌: ' + data.Data[i].BrandName + '</span>' +
                            '<div style="position:inherit; right:0.7rem; top:4.8rem;  width:5rem; height:1.3rem; border:1px solid #D9D9D9;  border-radius: 0.5rem;">' +
                            '<div style="position:inherit; left:0px; width:30%; height:100%; border-right:1px solid #D9D9D9; background-image:url(\'Images/ico/jian.png\'); background-size:100% 100%;" onclick="btnjian(' + data.Data[i].CommodityId + ');"></div>' +
                            '<div style="position:inherit; left:30%; width:40%; height:100%;"><span id="' + data.Data[i].CommodityId + '11" style="position:inherit; width:100%; height:80%; text-align:center; top:20%; font-size:0.8125rem; color:#999999;" onclick="setCount(' + data.Data[i].CommodityId + ', \'inCount\', \'inBg\')">' + data.Data[i].SpCount + '</span></div>' +
                            '<div style="position:inherit; left:70%; width:30%; height:100%; border-left:1px solid #D9D9D9; background-image:url(\'Images/ico/jia.png\'); background-size:100% 100%;" onclick="btnjia(' + data.Data[i].CommodityId + ');"></div>' +
                            '</div></div></div></div> <div style="width:100%; height:6px;"></div>';
                    allAmout = allAmout + (data.Data[i].CommoditySpec * data.Data[i].CommodityPrice) * data.Data[i].SpCount;
                }
            }
            $('#selAmount').html(allAmout.toFixed(2));
            $('#shopList').html(html);
        }
    });
}
function loadExAmount() {
    var cityId = $('#cityId').html();
    var exId = $('#exId').html();
    var timestamp = Date.parse(new Date());
    if (cityId > 0 && exId > 0) {
        var uaddresurl = '/CityExLogisticsAmount/GetCityExLogisticsAmount?cityId=' + cityId + '&exId=' + exId + '&t=' + timestamp;
        $.getJSON(uaddresurl, function (data) {
            if (data.Data != 'null' && data.Data != '') {
                $('#hideExAmout').html(data.Data.Amount);
            } else {
                $('#exAmount').html('￥0');
                $('#hideExAmout').html(0);
            }
            getAmout();
        });
    }
}
function getAmout() {
    var cmId = getRequestParam('cmId');
    var idlist = cmId.split(',');
    var allAmount = 0;
    var exAmount = $('#hideExAmout').html() - 1 + 1;
    var gj = 0;
    for (var i = 0; i < idlist.length; i++) {
        var rAmout = $('#' + idlist[i] + '111').html();
        var rCount = $('#' + idlist[i] + '11').html();
        allAmount = allAmount + rCount * rAmout;
        var cmgj = $('#cmgj' + idlist[i]).html();
        cmgj = cmgj - 1 + 1;
        gj = gj - 1 + 1 + cmgj;
    }
    allAmount = allAmount + exAmount * gj;
    $('#exAmount').html('￥' + exAmount * gj);
    $('#selAmount').html(allAmount);
}
var xmlobj; //定义XMLHttpRequest对象
function CreateXMLHttpRequest() {
    if (window.ActiveXObject)
        //如果当前浏览器支持Active Xobject，则创建ActiveXObject对象
    {
        //xmlobj = new ActiveXObject("Microsoft.XMLHTTP");
        try {
            xmlobj = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (e) {
            try {
                xmlobj = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (E) {
                xmlobj = false;
            }
        }
    }
    else if (window.XMLHttpRequest)
        //如果当前浏览器支持XMLHttp Request，则创建XMLHttpRequest对象
    {
        xmlobj = new XMLHttpRequest();
    }
}
function submitorder() {
    orderWapay(function () {
        if (xmlobj.readyState == 4 && xmlobj.status == 200) {
            //接受返回信息
            var data = xmlobj.responseText;
            var json = JSON.parse(data);
            if (json.Data.hasOwnProperty("status")) {
                if (json.Data.status == true) {
                    alert('下单成功!');
                } else {
                    alert('下单失败!');
                }
                window.location.href = '/MyOrder.html';
            }
        }
    });
}
function orderWapay(StatHandler) {
    var token = getCok();
    if (token != null) {
        var spId = '', spCount = '', isSC = 0, cityId = 0, exId = 0, exName = '', addres = '', consignee = '', phone = '', isInvoice = 0, payid = 0, payName = '', ramrk = '';
        var invoicePayable = '', businessName = '', taxpayerNumber = '', billContactPhone = '', billContactEmail = '', billContent = '';
        var cmId = getRequestParam('cmId');
        spId = cmId; spCount = getSpXount(cmId);
        var isource = getRequestParam('isource');
        var sampleId = getRequestParam('sampleId');
        if (isource == 1) { isSC = 0; } else { isSC = 1; }
        cityId = $('#cityId').html(); //        
        exId = $('#exId').html(); //
        exName = $('#seExName').html();
        addres = $('#SpAddres').html();
        consignee = $('#shrxm').html();
        phone = $('#shrdh').html();
        isInvoice = $('#invs').html();
        payid = $('#payspId').html(); //
        payName = $('#payspName').html();
        var ttid = $('#invTId').html();
        if (ttid == 1) { invoicePayable = '个人'; } else { invoicePayable = '单位'; }
        businessName = $('#txtComName').val();
        taxpayerNumber = $('#txtNas').val();
        billContactPhone = $('#txtPhone').val();
        billContactEmail = $('#txtMa').val();
        var contType = $('#invCtId').html();
        if (contType == 1) { billContent = '商品明细'; } else { billContent = '商品类别'; }
        if (ckorder(cityId, exId, payid, isInvoice, ttid, businessName, taxpayerNumber, billContactPhone, billContactEmail, sampleId)) {
            CreateXMLHttpRequest(); //创建对象
            var parm = "spId=" + spId + "&spCount=" + spCount + "&token=" + token + "&isSC=" + isSC + "&cityId=" + cityId + "&exId=" + exId + "&exName=" + exName + "&addres=" + addres
             + "&consignee=" + consignee + "&phone=" + phone + "&isInvoice=" + isInvoice + "&payid=" + payid + "&payName=" + payName + "&ramrk=" + ramrk + "&invoicePayable=" + invoicePayable + "&businessName=" + businessName
             + "&taxpayerNumber=" + taxpayerNumber + "&billContactPhone=" + billContactPhone + "&billContactEmail=" + billContactEmail + "&billContent=" + billContent + '&IsSample=' + sampleId;
            xmlobj.open("POST", "/Order/WapPay", true);
            xmlobj.setRequestHeader("cache-control", "no-cache");
            xmlobj.setRequestHeader("contentType", "text/html;charset=uft-8");
            xmlobj.setRequestHeader("Content-Type", "application/x-www-form-urlencoded;");
            xmlobj.onreadystatechange = StatHandler;
            xmlobj.send(parm);
        }
    }
}
function ckorder(cityId, exId, payid, isInvoice, ttid, businessName, taxpayerNumber, billContactPhone, billContactEmail, sampleId) {
    if (cityId == 0) {
        alert('请在收货地址中设置地区...');
        return false;
    }
    if (exId == 0 && sampleId == 0) {
        alert('请选择配送方式...');
        return false;
    }
    if (payid == 0 && sampleId == 0) {
        alert('请选择支付方式...');
        return false;
    }
    if (isInvoice == 1) {
        if (ttid == 1) {
            if (billContactEmail == '' || billContactPhone == '') {
                alert('开个人发票，请填写收票人信息...');
                return false;
            }
        } else {
            if (billContactEmail == '' || billContactPhone == '' || businessName == '' || taxpayerNumber == '') {
                alert('请填写发票抬头信息...');
                return false;
            }
        }
    }
    return true;
}
function getSpXount(cmid) {
    var idlist = cmid.split(',');
    var reCount = '';
    for (var i = 0; i < idlist.length; i++) {
        var rCount = $('#' + idlist[i] + '11').html();
        if (reCount == '') {
            reCount = rCount;
        } else {
            reCount = reCount + "," + rCount;
        }
    }
    return reCount;
}