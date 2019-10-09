
function ckUname() {
    var uname = $('#txUName').val();
    if (uname != '') {
        var url = '/User/CkUname?uName=' + uname;
        $.getJSON(url, function (data) {
            if (data.Data.hasOwnProperty("msg") && data.Data.msg == true) {
                $('#uNameState').html(1);
                alert('该用户名已被注册!');
            } else {
                $('#uNameState').html(0);
            }
        });
    } else {
        $('#uNameState').html(1);
    }
}
function ckPwd() {
    var pwd = $('#txpwd').val();
    var ckPwd = $('#txckpwd').val();
    if (pwd == '' || ckPwd == '') {
        $('#pwdState').html(1);
    } else {
        if (pwd != ckPwd) {
            $('#pwdState').html(1);
            alert('输入的密码有误!');
        } else {
            if (pwd.length >= 6) {
                $('#pwdState').html(0);
            }
            else {
                alert('密码不能少于6位!');
            }
        }
    }
}
function sub() {
    ckPwd();
    var ps = $('#pwdState').html();
    if (ps == 0) {
        var uName = $('#txUName').val();
        var pwd = $('#txpwd').val();
        var sex = '';
        var nickname = $('#txnickname').val();
        var entName = $('#txentName').val();
        var phones = $('#txPhone').val();
        var entPhone = $('#txentPhone').val();
        var entAddres = $('#txentAddres').val();
        var url = '/User/Register?uName=' + uName + '&pwd=' + pwd + '&sex=' + sex + '&nickname=' + nickname + '&entName=' + entName + '&phones=' + phones + '&entPhone=' + entPhone + '&entAddres=' + entAddres;
        $.getJSON(url, function (data) {
            if (data.Data.hasOwnProperty("msg")) {
                if (data.Data.msg == true) {
                    $('#uNameState').html(1);
                    alert('该用户名已被注册!');
                } else {
                    alert('注册失败!');
                }
            } else {
                alert('注册成功!');
                document.cookie = "name=" + data.Data[0].token;
                openIndex();
            }
        });
    }
}