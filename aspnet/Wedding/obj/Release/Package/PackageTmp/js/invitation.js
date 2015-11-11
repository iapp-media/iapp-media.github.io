(function (i, s, o, g, r, a, m) {
    i['GoogleAnalyticsObject'] = r;
    i[r] = i[r] || function () {
        (i[r].q = i[r].q || []).push(arguments)
    }, i[r].l = 1 * new Date();
    a = s.createElement(o),
        m = s.getElementsByTagName(o)[0];
    a.async = 1;
    a.src = g;
    m.parentNode.insertBefore(a, m)
})(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

ga('create', 'UA-62535634-5', 'auto');
ga('send', 'pageview');



document.write('<style>#loading{display:none}</style>');

function Reply_attn() {
    $.ajax({
        type: 'GET',
        url: '../WAttendance.aspx?N=' + $("#TName").val() + '&T=' + $("#TTel").val() + '&A=' + $("#TAttendance").val() + '&C=' + $("#carFrom").val(),
        success: function () {
            $.colorbox.close();
            //alert('sdfsd');
        },
        error: function () {
            //alert('WAttendance.aspx?N=' + $("#TName").val() + '&T=' + $("#TTel").val() + '&A=' + $("#TAttendance").val() + '&C=8023');
        }
    });
}

function Reply_bless() {
    $.ajax({
        type: 'GET',
        url: '../WBless.aspx?N=' + $("#TName").val() + '&T=' + $("#TTel").val() + '&M=' + $("#TMemo").val() + '&C=' + $("#carFrom").val(),
        success: function () {
            $.colorbox.close();
        },
        error: function () {
        }
    });
}