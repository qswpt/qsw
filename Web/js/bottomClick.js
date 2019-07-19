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
