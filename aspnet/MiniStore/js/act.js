function likeit(obj) {
    if (document.cookie.indexOf("iapp_uid=") == -1) { alert('請先登入'); return; }
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
