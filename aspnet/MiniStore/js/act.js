 
function likeit(obj) {
    if (document.cookie.indexOf("iapp_uid=") == -1) { alert('請先登入'); window.open('../Login/m-login.aspx?done=../MiniStore/default.aspx?SN=' + getValue("SN") + ''); return; }
    var fn = "";
    var apid = obj.id;
    if ($("#" + obj.id).prop("checked") == true) { fn = "&fn=1"; }
    apid = apid.substring(1, apid.length);
    $.ajax({
        type: 'POST',
        url: 'Buy_Like.aspx?i=' + apid + fn,
        success: function (feedback) {
            var cc = parseInt($("#kn" + apid).html());
            if (fn == "") { cc -= 1; } else { cc += 1; }
            $("#kn" + apid).html(cc.toString());
        },
        error: function () {
            alert("error!!");
        }
    });
}

function cint2(obj) {
    if ($.isNumeric(obj)) {
        return parseInt(obj);
    } else {
        return 0;
    }
}


function plus(obj, max) {
     var a1 = cint2($("#Num_" + obj).val().replace(/\,/g, "")); 
    if (a1 == max) {
        alert('超過現貨數量');
    } else {
        
        $.ajax({
            type: 'GET',
            url: 'FastShop.aspx?K0=1&K1=' + obj + '',
            success: function (msg) {
                if (msg == "err") { return false; }
                $("#Num_" + obj).val(cint2(msg))  ;
            },
            error: function (msg) {
                alert(msg)
            }
        });
    }
}

function minus(obj) {

    var a1 = cint2($("#Num_" + obj).val().replace(/\,/g, ""));
    if (a1 <= 0) { 
    } else {
        $.ajax({
            type: 'GET',
            url: 'FastShop.aspx?K0=2&K1=' + obj + '',
            success: function (msg) {
                if (msg == "err") { return false; }
                $("#Num_" + obj).val(cint2(msg)); 
            },
            error: function (msg) {
                alert(msg)
            }
        });
    }
}


function getValue(varname) {
    var url = window.location.href;
    try {
        var qparts = url.split('?');
        if (qparts.length === 0) {
            return '';
        }
        var query = qparts[1];
        var vars = query.split('&');
        var value = '';
        for (var i = 0; i < vars.length; i++) {
            var parts = vars[i].split('=');
            if (parts[0] == varname) {
                value = parts[1];
                break;
            }
        }
        value = unescape(value);
        value.replace(/\+/g, ' ');
        return value;
    } catch (err) {
        return '';
    }
}
