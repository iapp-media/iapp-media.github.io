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
    $(".menusandwich").click(function () {
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

    //頁面ajax

    // if click img

    //$('.item-pic').click(function() {
    //    $('.menuAJAX li:nth-child(1)').addClass('fadeInRight');
    //    $('.product,.allClassification').addClass('movecss').fadeOut(function() {
    //        $(window).scrollTop(0);
    //        $('.clickimg').fadeIn(function() {
    //            $('.imgbuy').click(function() {
    //                $('.menuAJAX li:nth-child(1)').addClass('fadeInRight_Double');
    //                $('.menuAJAX li:nth-child(2)').addClass('fadeInRight');
    //                $('.clickimg').addClass('movecss').fadeOut(function() {
    //                    $('.productcare').fadeIn(function() {
    //                        $('.sendcareButtom').click(function() {
    //                            $('.menuAJAX li:nth-child(2)').addClass('fadeInRight_Double');
    //                            $('.menuAJAX li:nth-child(3)').addClass('fadeInRight');
    //                            $('.productcare').addClass('movecss').fadeOut(function() {
    //                                $(window).scrollTop(0);
    //                                $('.productcareEnd').fadeIn(function() {
    //                                    $('.sendcareButtomeEnd').click(function() {
    //                                        alert('恭喜你完成訂單囉 ^_^                                                     工作天3~4天請耐心等候');
    //                                    });
    //                                });
    //                            });
    //                        });
    //                    });
    //                });
    //            });
    //        });
    //    });
    //});

    // if click buyButton
    
    //$('.buy').click(function() {
    //    $('.menuAJAX li:nth-child(2)').addClass('fadeInRight');
    //    $('.product,.allClassification').addClass('movecss').fadeOut(function() {
    //        $(window).scrollTop(0);
    //        $('.productcare').fadeIn(function() {
    //            $('.sendcareButtom').click(function() {
    //                $('.menuAJAX li:nth-child(2)').addClass('fadeInRight_Double');
    //                $('.menuAJAX li:nth-child(3)').addClass('fadeInRight');
    //                $('.productcare').addClass('movecss').fadeOut(function() {
    //                    $(window).scrollTop(0);
    //                    $('.productcareEnd').fadeIn(function() {
    //                        $('.sendcareButtomeEnd').click(function() {
    //                            alert('恭喜你完成訂單囉 ^_^                                                     工作天3~4天請耐心等候');
    //                        });
    //                    });
    //                });
    //            });
    //        });
    //    });
    //});
    jQuery(document).ready(function ($) {

        $('#checkbox').change(function () {
            setInterval(function () {
                moveRight();
            }, 3000);
        });

        var slideCount = $('#slider ul li').length;
        var slideWidth = $('#slider ul li').width();
        var slideHeight = $('#slider ul li').height();
        var sliderUlWidth = slideCount * slideWidth;

        $('#slider').css({
            width: slideWidth,
            height: slideHeight
        });

        $('#slider ul').css({
            width: sliderUlWidth,
            marginLeft: -slideWidth
        });

        $('#slider ul li:last-child').prependTo('#slider ul');

        function moveLeft() {
            $('#slider ul').animate({
                left: +slideWidth
            }, 200, function () {
                $('#slider ul li:last-child').prependTo('#slider ul');
                $('#slider ul').css('left', '');
            });
        };

        function moveRight() {
            $('#slider ul').animate({
                left: -slideWidth
            }, 200, function () {
                $('#slider ul li:first-child').appendTo('#slider ul');
                $('#slider ul').css('left', '');
            });
        };

        $('.control_prev').click(function () {
            moveLeft();
        });

        $('.control_next').click(function () {
            moveRight();
        });

    });

    // menu swipe

    $(function () {
        //Enable swiping...
        $(".allClassification").swipe({
            //Generic swipe handler for all directions
            swipe: function (event, direction, distance, duration, fingerCount, fingerData) {
                $('.swiper-wrapper li').each(function (e) {
                    if ($(this).hasClass('swiper-slide-active')) {
                        var swipeindex = $(this).index();
                        $('.allmodify').eq(swipeindex).fadeIn().siblings().fadeOut();
                    }
                })
            },
            threshold: 0
        });
    });


    var swiper = new Swiper('.swiper-container', {
        slidesPerView: 3,
        centeredSlides: true,
        paginationClickable: true,
        spaceBetween: 0,
        grabCursor: true,
        initialSlide: 1
    });


    //瀑布流

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

});
