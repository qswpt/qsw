
function onForcusGetP() {
    var v = $('#txtPassword').val();
    if (v == '' || v == '请输入密码') {
        $('#txtPassword').val('');
        $('#txtPassword').attr('type', 'password');
    }
}
function onblurSetP() {
    var v = $('#txtPassword').val();
    if (v == '') {
        $('#txtPassword').attr('type', 'text');
        $('#txtPassword').val('请输入密码');
    }
}
function userNameOnforcus() {
    var v = $('#txtUserName').val();
    if (v == '用户名') {
        $('#txtUserName').val('');
    }
}
function userNameOnblur() {
    var v = $('#txtUserName').val();
    if (v == '') {
        $('#txtUserName').val('用户名');
    }
}
function txtOnchage() {
    var u = $('#txtUserName').val();
    var p = $('#txtPassword').val();
    if (u != '' && u != '用户名' && p != '' && p != '请输入密码') {
        $('#btnDiv').css({ 'background-color': 'red' });
    } else {
        $('#btnDiv').css({ 'background-color': '#f7cccc' });
    }
}

function ulogin() {
    var uName = $('#txtUserName').val();
    var pwd = $('#txtPassword').val();
    var url = '/User/Login?userName=' + uName + '&pwd=' + pwd + '';
    $.getJSON(url, function (data) {
        if (data.Data == null || data.Data.length == 0) {
            alert('用户名密码不存在！')
        } else {
            document.cookie = "name=" + data.Data[0].token;
            pageback();
        }
    });
}
function getCok() {
    var arr, reg = new RegExp("(^| )name=([^;]*)(;|$)");
    if (arr = document.cookie.match(reg)) {
        return unescape(arr[2]);
    }
    else
        return null;
}
function getShopCount() {
    var token = getCok();
    if (token != null) {
        var url = '/Commodity/GetShoppingCount?token=' + token + '';
        $.getJSON(url, function (data) {
            if (data.Data.state) {
                showShopd(data.Data.rcount);
            }
        });
    }
}
function showShopd(count) {
    if (count > 0) {
        $('#shpdCount').css({ 'display': 'block' });
        $('#spCount').html(count);
    } else {
        $('#shpdCount').css({ 'display': 'none' });
        $('#spCount').html(0);
    }
}
function isShop(cid) {
    var token = getCok();
    if (token == null || token == '' || token == "''") {
        window.location.href = '/login.html';
    } else {
        var url = '/Commodity/SetShopping?token=' + token + '&spId=' + cid + '';
        $.getJSON(url, function (data) {
            if (data.Data.state) {
                showgwcDiv();
                showShopd(data.Data.rcount);
            }
        });
    }
    stopBubble(event);
}
function isCkLogin() {
    var token = getCok();
    if (token == null || token == '' || token == "''") {
        return false;
    } else {
        return true;
    }
}
function stopBubble(e) {
    if (e && e.stopPropagation)
        e.stopPropagation();
    else
        window.event.cancelBubble = true;
}

function pageback() {
    window.history.back(-1);
}
function hidegwcInfo() {
    setTimeout(function () {
        $('#gwcInfo').hide();
    }, 2000);
}
function showgwcDiv() {
    $('#gwcInfo').show();
    hidegwcInfo();
}
function openIndex() {
    window.location.href = '/Index.html';
}

function openInfo(id) {
    window.location.href = '/CommodityInfo.html?id=' + id;
}
function BuyImmediately(id, spd, isource) {
    window.location.href = '/PlaceOrder.html?cmId=' + id + '&sampleId=' + spd + '&isource=' + isource;
}
//获取路径中传参值
function getRequestParam(param) {
    var requestString = location.search;
    var reg = new RegExp("(?:\\?|&)" + param + "=(.*?)(?:&|$)");
    if (reg.test(requestString)) {
        return decodeURIComponent(RegExp.$1);
    } else {
        return 0;
    }
}