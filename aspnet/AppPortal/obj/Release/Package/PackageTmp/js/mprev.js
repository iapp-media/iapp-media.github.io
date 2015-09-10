





$().ready(function () {
    $(".good").click(function () {
        if (document.cookie.indexOf("iapp_uid=") == -1) { alert('請先登入'); return; }
        var fn = "";
        var apid = $(this).attr("id").toString();
        if ($(this).prop("checked") == true) { fn = "&fn=1"; }
        apid = apid.substring(1, apid.length);
        $.ajax({
            type: 'POST',
            url: '../act/good.aspx?i=' + apid + fn,
            success: function (feedback) {
                var cc = parseInt($("#gn" + apid).html());
                if (fn == "") { cc -= 1; } else { cc += 1; }
                $("#gn" + apid).html(cc.toString());
            },
            error: function () {
                alert("error!!");
            }
        });
    });

    $(".like").click(function () {
        if (document.cookie.indexOf("iapp_uid=") == -1) { alert('請先登入'); return; }
        var fn = "";
        var apid = $(this).attr("id").toString();
        if ($(this).prop("checked") == true) { fn = "&fn=1"; }
        apid = apid.substring(1, apid.length);
        $.ajax({
            type: 'POST',
            url: '../act/Like.aspx?i=' + apid + fn,
            success: function (feedback) {
                var cc = parseInt($("#kn" + apid).html());
                if (fn == "") { cc -= 1; } else { cc += 1; }
                $("#kn" + apid).html(cc.toString());
            },
            error: function () {
                alert("error!!");
            }
        });
    });

    $(".startoggle").click(function () {
        if (document.cookie.indexOf("iapp_uid=") == -1) { alert('請先登入'); return; }
        var fn = "";
        var apid = $(this).attr("id").toString();
        if ($(this).prop("checked") == true) { fn = "&fn=1"; }
        apid = apid.substring(1, apid.length);
        $.ajax({
            type: 'POST',
            url: '../act/Favor.aspx?i=' + apid + fn,
            success: function (feedback) {
            },
            error: function () {
                alert("error!!");
            }
        });
    });

});

