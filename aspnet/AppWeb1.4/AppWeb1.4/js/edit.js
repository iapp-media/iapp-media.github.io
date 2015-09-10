

function goValue(Img) {
    //alert(Img);
    var thisPageUrl = location.pathname.replace("/Pages/", "");
    $('#select', window.parent.document).hide();
    $('.edit', window.parent.document).show();
    //var ID = $.url.param("ID");
    window.parent.ChangeEditUrl(getQValue("ID").replace("#", ""), thisPageUrl, Img)
   
}

function passValue(text) {
    var thisPageUrl = location.pathname.replace("/Pages/", "");
    $('#select', window.parent.document).hide();
    $('.edit', window.parent.document).show();
    //var ID = $.url.param("ID");
    window.parent.ChangeEditWD(getQValue("ID").replace("#",""), thisPageUrl, text)
}

function ref() {
    location.reload();
}


function getQValue(varname) {
    var url = window.location.href;
    var qparts = url.split("?");
    if (qparts.length <= 1) {
        return "";
    } else {
        var query = qparts[1];
        var vars = query.split("&amp;");
        var value = "";
        for (i = 0; i < vars.length; i++) {
            var parts = vars[i].split("=");
            if (parts[0] == varname) {
                value = parts[1];
                break;
            }
        }
        value = unescape(value);
        value.replace(/\+/g, " ");
        return value;
    }
}
