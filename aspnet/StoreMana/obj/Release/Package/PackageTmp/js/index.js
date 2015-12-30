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

    $(document).ready(function () {
        // window.scrollTo(0, 10);
        $("#slider ul li label,.uploadBTN").click(function () {
            $('.preview-container').hide();
            $('.img-container').show();
            $(".upload-img").show();
            $(".pages").hide();
            $('.compress').hide();
            $('.cut').show();
            $('.cut').attr("disabled", true);
            $('.rotate-btn').hide();

        });
        $(".cut").click(function () {
            $(".cut").hide();
            $(".compress").show();

        });
        $(".compress").click(function () {
            $(".upload-img").hide();
            $(".pages").show();

        });
        $('#inputImage').change(function () {
            $('.preview-container').hide();
            $('.img-container').show();
            $('.compress').hide();
            $('.cut').show();
            $('.rotate-btn').show();
        });
        $('.cancelimgfun').click(function () {
            $(".upload-img").hide();
            $(".pages").show();
        });

        $('.cancelimgfun').click(function () {
            $(".upload-img").hide();
            $(".pages").show();
        }); 
    });

    //頁面ajax

    

    //products slider
    jQuery(document).ready(function ($) {
        var slideCount = $('#slider ul li').length;
        var slideWidth = $('#slider ul li').width();
        var slideHeight = $('#slider ul li').height();
        var sliderW2 = $('#slider').width();
        var sliderUlWidth = slideCount * sliderW2;
        
        console.log('slider寬' + sliderW2);
        

        $('#slider').css({
            width: sliderW2
        });

        $('#slider ul').css({
            width: sliderW2 * slideCount,
            marginLeft: -slideWidth
        });
        $('#slider ul li').css({
            width: sliderW2
        });

        //$('#slider ul li:last-child').prependTo('#slider ul');

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

   

    $('.openslider').on('click', function () {
        $('.productDIV').fadeIn();
    });

    // swipe
    var swiper = new Swiper('.swiper-container', {
        pagination: '.swiper-pagination',
        slidesPerView: 2,
        centeredSlides: true,
        paginationClickable: true,
        spaceBetween: 0,
        initialSlide: 1,
        nextButton: '.swiper-button-next',
        prevButton: '.swiper-button-prev'
    });

   


    // gray bar PC
    $('.swiper-button-next,.swiper-button-prev').click(function () {
        $("#Allswiper").each(function () {
            var _Sliderindex = $(this).find('.swiper-slide-active').index(),
                _SliderJum = $(this).find('.swiper-slide').eq(_Sliderindex).attr('data-src');
            console.log(_Sliderindex, _SliderJum)
            window.location = _SliderJum;
        });
    });

    // gray bar mobile
    $("#Allswiper").swipe({
        //Generic swipe handler for all directions
        swipe: function (event, direction, distance, duration, fingerCount, fingerData) {
            $(this).each(function (e) {
                if ($('.swiper-slide').hasClass('swiper-slide-active')) {
                    var NewSrc = '',
                        NewIndex = $('.swiper-slide-active').index(),
                        NewSrc = $('.swiper-slide').eq(NewIndex).attr('data-src');
                        console.log(NewSrc, NewIndex)
                        window.location = NewSrc;
                }
            })
        },
        threshold: 0
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
