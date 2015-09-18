//觸發

$(document).ready(function() {
    $("#user-login").click(function() {
        $(".m-profile").animate({
            height: 'toggle'
        }, 300);
        $(".theme").hide();
    });
    $("#op-search").click(function() {
        $(".search-bar").animate({
            height: 'toggle'
        }, 300);
        $(".theme").hide();
        $(".m-profile").hide();
    });
    $(".bar-text").click(function() {
        $('.finder').show();
        $(".theme").hide();
    });
    $(".select").click(function() {
        $(".theme").animate({
            height: 'toggle',
            overflowY: 'scroll !important' //doesn't work
        }, {
            duration: 200,
            queue: false,
            complete: function(e) {
                $('.scrollable-menu').css('overflowY', 'scroll');
            }
        });

        $(".m-profile").hide();
        $('.finder').hide();
    });
    $(".cancel").click(function() {
        $('.finder').hide();
        $('.search-bar').slideToggle(300);
        // hide();
    });
    $(".login-box").click(function() {
        $('.login-box').hide();
        $('.icon-box').addClass('openlogin');
    });
    $(".icon-box").click(function() {
        $('.jumbotron').show();
    });
    $("#logout").click(function() {
        Parse.User.logOut();
        $('.jumbotron').hide();
        $('.icon-box').hide();
        $('.login-box').show();
    });
    $(".m-logout").click(function() {
        Parse.User.logOut();
        $('.circle-login').hide();
        $('.m-profile').hide();
        $('#m-login').show();
    });
}); // 觸發 end


//光箱

$(document).ready(function() {
    //Examples of how to assign the Colorbox event to elements
    $(".apps-info").colorbox({
        iframe: true,
        width: "80%",
        height: "100%"
    });
    $(".iframe-info").colorbox({
        iframe: true,
        width: "700px",
        height: "600px"
    });
}); //光箱 end

//頁面ajax
$(function() {
    $('.buy').click(function() {
        $('.buydivmove').addClass('movecss');
        var window_w = $(window).width();
        var allajax = $('.buydivmove').css('width', window_w * 2);
        var alldivajax = allajax.width();
        $('.product').css('width', alldivajax / 2);
        $('.productcare').css('width', '50%').delay(1000).fadeIn();
        console.log(ajax1_w, ajax2_w, alldivajax);
    })
});
//瀑布流

$(function() {

    var $container = $('#container');

    $container.imagesLoaded(function() {
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
        function(newElements) {
            // hide new items while they are loading
            var $newElems = $(newElements).css({
                opacity: 0
            });
            // ensure that images load before adding to masonry layout
            $newElems.imagesLoaded(function() {
                // show elems now they're ready
                $newElems.animate({
                    opacity: 1
                });
                $container.masonry('appended', $newElems, true);
            });
        }
    );
}); //瀑布流 end
