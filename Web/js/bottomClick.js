function btClick(idx) {
    if (idx == 0) {
        $('#dfbtn').css("background-image", "url(Images/ico/df2.png)");
    } else {
        $('#dfbtn').css("background-image", "url(Images/ico/df1.png)");
    }
    if (idx == 1) {
        $('#ppbtn').css("background-image", "url(Images/ico/pp2.png)");
    } else {
        $('#ppbtn').css("background-image", "url(Images/ico/pp1.png)");
    }
    if (idx == 2) {
        $('#flbtn').css("background-image", "url(Images/ico/gp2.png)");
    } else {
        $('#flbtn').css("background-image", "url(Images/ico/gp1.png)");
    }
    if (idx == 3) {
        $('#gwcbtn').css("background-image", "url(Images/ico/sp2.png)");
    } else {
        $('#gwcbtn').css("background-image", "url(Images/ico/sp1.png)");
    }
    if (idx == 4) {
        $('#mybtn').css("background-image", "url(Images/ico/my2.png)");
    } else {
        $('#mybtn').css("background-image", "url(Images/ico/my1.png)");
    }
    switch (idx) {
        case 0:
            window.location.href = '/Index.html';
            break;
        case 1:
            window.location.href = '/Commodity.html?brandId=0';
            break;
        case 2:
            window.location.href = '/GroupCommodity.html?typeId=0';
            break;
        case 3:
            window.location.href = '/ShoppingCart.html';
            break;
        case 4:
            window.location.href = '#';
            break;
    }
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
        //写入cache
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