
$(document).ready(function () {
    loadInfo();
});
function loadInfo() {
    var token = getCok();
    var timestamp = Date.parse(new Date());
    if (token == null || token == '' || token == "''") {
        window.location.href = '/login.html';
    } else {
        var url = '/User/GetUserInfo?token=' + token + '&t=' + timestamp;
        $.getJSON(url, function (data) {
            if (data.Data != 'null' && data.Data != '') {
                if (data.Data.UserImg != null && data.Data.UserImg != 'null') {
                    $('#phImg').css("background-image", "url(" + data.Data.UserImg + '?t=' + timestamp + ")");
                    $('#uImg').css("background-image", "url(" + data.Data.UserImg + '?t=' + timestamp + ")");
                    $('#phImgbk').html(data.Data.UserImg);
                }
                else {
                    $('#phImg').css("background-image", "url('Images/UserImg/sysPh.png')");
                    $('#uImg').css("background-image", "url('Images/UserImg/sysPh.png')");
                    $('#phImgbk').html('Images/UserImg/sysPh.png');
                }
                $('#unickname').html(data.Data.Nickname);
                $('#txtnickname').val(data.Data.Nickname);
                $('#uName').val(data.Data.UserName);
                $('#uName1').html('账号:' + data.Data.UserName);
                $('#inSex').val(data.Data.Sex);
            } else {
                window.location.href = '/login.html';
            }
        });
        LoadAddresList();
    }
}
function LoadAddresList() {
    var token = getCok();
    var timestamp = Date.parse(new Date());
    var uaddresurl = '/UserAddres/GetUserAddresList?token=' + token + '&t=' + timestamp;
    $.getJSON(uaddresurl, function (data) {
        var html = '';
        if (data.Data != 'null' && data.Data != '') {
            var topNum = 0;
            for (var i = 0; i < data.Data.length; i++) {
                html = html + '<div style="position:absolute; height:4.375rem; left:0.5rem; right:0.5rem; top:' + topNum + 'rem; background-color:#fff;">' +
                              '<span id="adId' + data.Data[i].id + '" style="display:none;">' + data.Data[i].id + '</span><span id="adstate' + data.Data[i].id + '" style="display:none;">' + data.Data[i].DefaultAddress + '</span>' +
                              '<span id="adContacts' + data.Data[i].id + '" style="display:none;">' + data.Data[i].Contacts + '</span>' +
                              '<div style="position:absolute; width:2.5rem; height:2.5rem; top:50%; margin-top:-1.25rem; background-color:#aaaaaa; left:0.125rem; border-radius: 50%; text-align:center;">' +
                              '<span style="position:absolute; width:100%; font-size:1rem; height:1.375rem; top:50%; margin-top:-0.6875rem; left:0px; color:#fff;">' + data.Data[i].Contacts.substring(0, 1) + '</span>' +
                              '</div><div style="position:absolute; height:100%; left:2.75rem; right:2.6875rem;">' +
                              '<span style="position:absolute; left:0.5rem; top:0.25rem; font-size:1rem; width:3.75rem;white-space:nowrap; word-break:keep-all; overflow:hidden; text-overflow:ellipsis;">' + data.Data[i].Contacts + '</span>' +
                              '<span id="ph' + data.Data[i].id + '" style="position:absolute; left:4.25rem; top:0.5rem; font-size:0.75rem; color:#999999;">' + data.Data[i].Telephone + '</span>' +
                              '<span id="add' + data.Data[i].id + '" style="position:absolute; left:0.5rem; top:1.75rem; font-size:0.875rem;">' + data.Data[i].Address + '</span>' +
                              '</div><div style="position:absolute; width:2.6875rem; height:1.5rem; top:50%; margin-top:-0.75rem; right:0px; text-align:center; border-left:1px solid #dddddd;">' +
                              '<span style="color:#999999; width:100%;" onclick="editAdds(' + data.Data[i].id + ');">编辑</span></div></div>';
                topNum = topNum + 4.375;
            }
        }
        $('#addressList').html(html);
    });
}
function outLogin(cType) {
    if (cType == 1) {
        var cval = getCok();
        document.cookie = "name=''";
    }
    window.location.href = '/login.html';
}
function pothClick() {
    $('#tuploadFiles').click();
}
function getImgUrl() {
    getFullPath();
}
function getFullPath() {
    //获取读取我文件的File对象
    var selectedFile = document.getElementById('tuploadFiles').files[0];
    var url = "";
    if (window.createObjectURL != undefined) {
        url = window.createObjectURL(selectedFile);
    }
    else if (window.URL != undefined) {
        url = window.URL.createObjectURL(selectedFile);
    }
    else if (window.webkitURL != undefined) {
        url = window.webkitURL.createObjectURL(selectedFile);
    }
    $('#phImg').css("background-image", "url(" + url + ")");
}
//初始化上传
function initUpload() {
    var fileName = $('#phImgbk').html();
    var selectedFile = document.getElementById('tuploadFiles').files[0];
    if (selectedFile != null) {
        var chunk = selectedFile.size;
        var query = {};
        var chunks = [];
        var start = 0;
        //扩展名的文件名
        var pos = selectedFile.name.lastIndexOf(".");
        var aaa = selectedFile.name.substring(pos);
        fileName = 'Images//UserImg//' + getCok() + '.jpg';
        for (var i = 0; i < Math.ceil(selectedFile.size / chunk) ; i++) {
            var end = start + chunk;
            chunks[i] = selectedFile.slice(start, end);
            start = end;
        }
        query = {
            fileSize: selectedFile.size,
            dataSize: chunk,
            fileName: fileName,
            nextOffset: 0
        }
        upload(chunks, query, fileName);
    } else {
        updateUserInfo(fileName);
    }
}
// 执行上传
function upload(chunks, query, fileName) {
    var queryStr = Object.getOwnPropertyNames(query).map(key => {
        return key + "=" + query[key];
    }).join("&");
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "FileUpload/upload?" + queryStr);
    xhr.overrideMimeType("application/octet-stream");
    var index = Math.floor(query.nextOffset / query.dataSize);
    getFileBinary(chunks[index], function (binary) {
        if (xhr.sendAsBinary) {
            xhr.sendAsBinary(binary);
        } else {
            xhr.send(binary);
        }
    });
    xhr.onreadystatechange = function (e) {
        if (xhr.readyState === 4) {
            if (xhr.status === 200) {
                //上传完成
                updateUserInfo(fileName);
            }
        }
    }
}
// 获取文件二进制数据
function getFileBinary(file, cb) {
    var reader = new FileReader();
    reader.readAsArrayBuffer(file);
    reader.onload = function (e) {
        if (typeof cb === "function") {
            cb.call(this, this.result);
        }
    }
}

function getSexValue(val) {
    if (val == 1) {
        $('#inSex').val('男');
    } else if (val == 2) {
        $('#inSex').val('女');
    }
    $('#sexBg').css({ 'display': 'none' });
    $('#sexIn').css({ 'display': 'none' });
}
function showSexIn() {
    $('#sexBg').css({ 'display': 'block' });
    $('#sexIn').css({ 'display': 'block' });
}

function updateUserInfo(imgName) {
    var token = getCok();
    var nickname = $('#txtnickname').val();
    var sex = $('#inSex').val();
    var url = '/User/UpdateUserInfo?token=' + token + '&nickname=' + nickname + '&sex=' + sex + '&uImg=' + imgName;
    $.getJSON(url, function (data) {
        location.reload();
    });
}

function editUserInfo() {
    $('#myInfo').css({ 'display': 'none' });
    $('#editInfo').css({ 'display': 'block' });
}
function editReAddress() {
    $('#myInfo').css({ 'display': 'none' });
    $('#reAddress').css({ 'display': 'block' });
}
function cancelEdit() {
    $('#myInfo').css({ 'display': 'block' });
    $('#editInfo').css({ 'display': 'none' });
    $('#reAddress').css({ 'display': 'none' });
    loadInfo();
}
function cancelManagerAddres()
{
    $('#myInfo').css({ 'display': 'block' });
    $('#editInfo').css({ 'display': 'none' });
    $('#reAddress').css({ 'display': 'none' });
}
function editAdds(id) {
    var adId = $('#adId' + id).html();
    var adstate = $('#adstate' + id).html();
    var adContacts = $('#adContacts' + id).html();
    var ph = $('#ph' + id).html();
    var add = $('#add' + id).html();
    $('#reAddress').css({ 'display': 'none' });
    $('#editAddressInfo').css({ 'display': 'block' });
    $('#edId').html(adId);
    $('#txadContacts').val(adContacts);
    $('#txph').val(ph);
    $('#txadd').val(add);
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
    var url = '';
    if (adId > 0) {
        url = '/UserAddres/UpdateUserAddres?token=' + token + '&adId=' + adId + '&Address=' + add + '&telephone=' + ph + '&contacts=' + adContacts + '&defaultAddress=' + adstate + '&city=' + 0;
    } else {
        url = '/UserAddres/InserUserAddres?token=' + token + '&adId=' + adId + '&Address=' + add + '&telephone=' + ph + '&contacts=' + adContacts + '&defaultAddress=' + adstate + '&city=' + 0;
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