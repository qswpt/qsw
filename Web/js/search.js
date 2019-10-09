
$(document).ready(function () {
    var token = getCok();
    if (token != null) {
        var uaddresurl = '/Search/GetSearchList?token=' + token;
        $.getJSON(uaddresurl, function (data) {
            if (!isPasLogin(data)) {
                var mysearch = ''; var hotSearch = '';
                for (var i = 0; i < data.Data.length; i++) {
                    if (data.Data[i].Hot == 0) {
                        mysearch = mysearch + '<span style="padding:6px;margin-top:6px; margin-left:6px; background-color:#dddddd; color:#666666; border-radius:40px; font-size:0.75rem; display:inline-block;" onclick="search(\'' + data.Data[i].SearchName + '\');">' + data.Data[i].SearchName + '</span>';
                    } else {
                        hotSearch = hotSearch + '<span style="padding:6px;margin-top:6px; margin-left:6px; background-color:#dddddd; color:#666666; border-radius:40px; font-size:0.75rem; display:inline-block;" onclick="search(\'' + data.Data[i].SearchName + '\');">' + data.Data[i].SearchName + '</span>';
                    }
                }
                $('#searchHistory').html(mysearch);
                $('#hotSearchDiv').html(hotSearch);
            }
        });
        $('#searchtext').focus();
    }
});

function clearSearch() {
    var token = getCok();
    if (token != null) {
        var uaddresurl = '/Search/ClearSearch?token=' + token;
        $.getJSON(uaddresurl, function (data) {
            if (!isPasLogin(data)) {
                var mysearch = ''; var hotSearch = '';
                for (var i = 0; i < data.Data.length; i++) {
                    if (data.Data[i].Hot == 0) {
                        mysearch = mysearch + '<span style="padding:6px;margin-top:6px; margin-left:6px; background-color:#dddddd; color:#666666; border-radius:40px; font-size:0.75rem; display:inline-block;" onclick="search(\'' + data.Data[i].SearchName + '\');">' + data.Data[i].SearchName + '</span>';
                    } else {
                        hotSearch = hotSearch + '<span style="padding:6px;margin-top:6px; margin-left:6px; background-color:#dddddd; color:#666666; border-radius:40px; font-size:0.75rem; display:inline-block;" onclick="search(\'' + data.Data[i].SearchName + '\');">' + data.Data[i].SearchName + '</span>';
                    }
                }
                $('#searchHistory').html(mysearch);
                $('#hotSearchDiv').html(hotSearch);
            }
        });
        $('#searchtext').focus();
    }
}
function btnSearch() {
    var txt = $('#searchtext').val();
    if (txt != '') {
        search(txt);
    } else {
        $('#searchtext').focus();
    }
}
function search(txt) {
    window.location.href = '/SearchInfo.html?searchTxt=' + txt;
}
