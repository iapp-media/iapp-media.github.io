 
$(document).ready(function () {

    //判斷微店狀態

    //$('.theme li:contains(哈雷)').click(function () {
    //    console.log(123213)
    //    alert(12312313)
    //    $('html:contains(微創作)').text(哈囉)
    //});

    //Examples of how to assign the Colorbox event to elements

    var boxwidth = "80%";
    if ($(window).width() <= 1000) { boxwidth = "95%"; }
    $(".apps-info").colorbox({
        iframe: true,
        width: boxwidth,
        height: "100%"
    });
    $(".iframe-info").colorbox({
        iframe: true,
        width: "700px",
        height: "600px"
    });

    //$('.jumbotron').hide();
    //$("#user-login").click(function () {
    //    $(".m-profile").animate({
    //        height: 'toggle'
    //    }, 300);
    //    $(".theme").hide();
    //});
    $("#op-search").click(function () {
        $(".search-bar").animate({
            height: 'toggle'
        }, 300);
        $(".theme").hide();
        $(".m-profile").hide();
    });
    //$(".bar-text").click(function () {
    //    $('.finder').show();
    //    $(".theme").hide();
    //});
    $(".select").click(function () {
        $(".theme").animate({
            height: 'toggle'
        }, 300);
        $(".m-profile").hide();
        $('.finder').hide();
    });
    $(".cancel").click(function () {
        $('.finder').hide();
        $('.search-bar').slideToggle(300);
        hide();
    });
    $(".login-box").click(function () {
        //$('.login-box').hide();
        //$('.icon-box').addClass('openlogin');
    });
    $(".icon-box,.login-sm").click(function () {
        $('.jumbotron').toggleClass('jumbotronAni');
        if ($('.jumbotron').hasClass('jumbotronAni')) {
            $('.user-icon').fadeIn('slow', function () {
                $('.option-user').fadeIn(function () {
                    $('.logout-user').fadeIn();
                });
            });
        } else {
            //$('.user-icon').fadeOut();
            $('.option-user,.user-icon,.logout-user').css('display', 'none');
        }
        //window.open('portal.aspx?fn=my', '_self');
        //$('.jumbotron').show();
    });
    //$("#logout").click(function () {
    //    $('.jumbotron').hide();
    //    $('.icon-box').hide();
    //    $('.login-box').show();
    //});
    //$(".m-logout").click(function () {
    //    $('.circle-login').hide();
    //    $('.m-profile').hide();
    //    $('#m-login').show();
    //});


    var $container = $('#container');

    $container.imagesLoaded(function () {
        $container.masonry({
            itemSelector: '.item',
            columnWidth: 20,
            isAnimated: true,
            isFitWidth: true
        });
    });
    // 在背景取出下一頁的內容, 並將指定的 selector 資料 append 到目前的網頁上
    $container.infinitescroll({
        navSelector: 'div.nav', // selector for the paged navigation 
        nextSelector: 'div.nav a', // selector for the NEXT link (to page 2)
        itemSelector: '.item', // selector for all items you'll retrieve
        loading: {
            img: 'img/6RMhx.gif',
            msgText: 'loading....',
            finishedMsg: 'no more...'
        }

    },
        // trigger Masonry as a callback
        function (newElements) {
            // hide new items while they are loading
            var $newElems = $(newElements).css({
                opacity: 0
            });
            // ensure that images load before adding to masonry layout
            $newElems.imagesLoaded(function () {
                // show elems now they're ready
                $newElems.animate({
                    opacity: 1
                });
                $container.masonry('appended', $newElems, true);
                $(".apps-info").colorbox({
                    iframe: true,
                    width: "80%",
                    height: "100%"
                });
            });
        }
    );

});
  
 
$("#Search").keyup(function () {
    var x = $("#Search").val().length;
    if (x >= 2) {
        $('#listbox').empty();
        $.ajax({
            type: 'GET',
            url: 'search_List.aspx?w=' + $("#Search").val(),
            success: function (word) {
                if (word != "") {
                    $("#listbox").append(word);
                    $('.finder').show();
                    $(".theme").hide();
                }
            },
            error: function () {
                //alert("PassValue Error!!");
            }
        });
    }
});

$("#mSearch").keydown(function () {
    var x = $("#mSearch").val().length;
    if (x >= 2) {
        $('#listbox').empty();
        $.ajax({
            type: 'GET',
            url: 'search_List.aspx?w=' + $("#mSearch").val(),
            success: function (word) {
                if (word != "") {
                    $("#listbox").append(word);
                    $('.finder').show();
                    $(".theme").hide();
                }
            },
            error: function () {
                alert("PassValue Error!!");
            }
        });
    }
});

$("#Search").keypress(function (e) {
    var key = window.event ? e.keyCode : e.which;
    if (key == 13) {
        window.open("portal.aspx?w=" + encodeURI($("#Search").val()), "_self");
    }
});

$("#mSearch").keypress(function (e) {
    var key = window.event ? e.keyCode : e.which;
    if (key == 13) {
        window.open("portal.aspx?w=" + encodeURI($("#mSearch").val()), "_self");
    }
});


function ref() {
    location.reload();
}

function goodit(obj) {
    if (document.cookie.indexOf("iapp_uid=") == -1) { alert('請先登入'); return; }
    var fn = "";
    var apid = obj.id;
    if ($("#" + obj.id).prop("checked") == true) { fn = "&fn=1"; }
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
}

function likeit(obj) {
    if (document.cookie.indexOf("iapp_uid=") == -1) { alert('請先登入'); return; }
    var fn = "";
    var apid = obj.id;
    if ($("#" + obj.id).prop("checked") == true) { fn = "&fn=1"; }
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
}

function starit(obj) {
    if (document.cookie.indexOf("iapp_uid=") == -1) { alert('請先登入'); return; }
    var fn = "";
    var apid = obj.id;
    if ($("#" + obj.id).prop("checked") == true) { fn = "&fn=1"; }
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
}

function toggleMy() {
    if (getValue("fn") == "my") { window.open("portal.aspx", "_self"); } else { window.open("portal.aspx?fn=my", "_self"); }
}
function clickMin() {
    if (getValue("t") == "10") {
        $('.tile1 a').text('開微店');
    }
}
clickMin();

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
