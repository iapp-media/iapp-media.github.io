//抓值電話的值
var phoneNum = $('#phoneNUM').text().trim();;
console.log(phoneNum);
$('#phoneAttr').attr('onclick', "location.href=" + "'tel:" + phoneNum + "'");

//觸發

$(document).ready(function () {
    $("#mSearch").keydown(function () {
        var x = $("#mSearch").val().length;
        if (x >= 2) {
            $('#listbox').empty();
            $.ajax({
                type: 'GET',
                url: 'search_List.aspx?SN=' + encodeURI(getQValue("SN")) + '&w=' + encodeURI($("#mSearch").val()),
                success: function (word) {
                    if (word != "") {
                        $("#listbox").append(word);
                        $('.finder').show();
                        $(".theme").hide();
                    }
                },
                error: function () {
                    alert('search_List.aspx?SN=' + getQValue("SN") + '&w=' + encodeURI($("#mSearch").val()));
                }
            });
        } 
    });
    $("#mSearch").keypress(function (e) {
        var key = window.event ? e.keyCode : e.which;
        if (key == 13) {
            // alert('jump');
            window.open('Default.aspx?SN=OfficACC&w=' + encodeURI($("#mSearch").val()), "_blank");
            //window.open('Default.aspx?SN=OfficACC&w=' + encodeURI($("#mSearch").val()), "_self");
           
        }
    });
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
            value.replace(/\+/g, " ").replace("#", "");
            return value;
        }
    }


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
        $("#Rightwich").animate({
            height: 'toggle',
            overflowY: 'scroll !important' //doesn't work
        }, {
            duration: 200,
            queue: false,
            complete: function(e) {
                $('.scrollable-menu').css('overflowY', 'scroll');
            }
        });
        $("#Leftwich").css('display', 'none');
        $(".m-profile").hide();
        $('.finder').hide();
    });
    $(".iapplogo").click(function () {
        $("#Leftwich").animate({
            height: 'toggle',
            overflowY: 'scroll !important' //doesn't work
        }, {
            duration: 200,
            queue: false,
            complete: function (e) {
                $('.scrollable-menu').css('overflowY', 'scroll');
            }
        });
        $("#Rightwich").css('display', 'none');
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
    $('#Mapclick').stop(true,false).click(function () {
        $('.Mapbox').css('transform', 'scale(1)');
        $('.Mapbox,#map,.colorBG').show();
        $('.colorBG').stop(true, false).click(function () {
            $('.Mapbox,#map,.colorBG').fadeOut(function () {
                $('.Mapbox').stop(true, false).removeAttr('style', 'transform:scale(1)')
                return;
            });
        });
    });

    jQuery(document).ready(function ($) {
        var slideCount = $('#slider ul li').length;
        var slideWidth = $('#slider ul li').width();
        var slideHeight = $('#slider ul li').height();
        var sliderUlWidth = slideCount * slideWidth;
        var screenW = $('#slider').width();
        console.log(screenW);

        //$('#slider').css({
        //    width: screenW,
        //    height: slideHeight
        //});

        $('#slider ul').css({
            width: screenW * slideCount
        });
        $('#slider ul li').css({
            width: screenW
        })

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

    // menu swipe

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
            console.log(_SliderJum, "抓到第"+(_Sliderindex + 1)+"個選單")
            //window.location = _SliderJum;
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
                    console.log(NewSrc, "抓到第"+(NewIndex+1)+"個選單")
                    //window.location = NewSrc;
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

    
    

}); //end document ready
