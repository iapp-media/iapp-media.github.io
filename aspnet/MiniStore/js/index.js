//抓值電話的值
var phoneNum = $('#phoneNUM').text().trim();
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

    if ($('#ContentPlaceHolder1_Image1').attr('src') == '') {
        $('#SinfoTop img').hide();
    } else {
        $('#SinfoTop img').show();
    }

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

   
    
    // gray bar PC
    //$('.swiper-button-next,.swiper-button-prev').click(function () {
    //    $("#Allswiper").each(function () {
    //        var _Sliderindex = $(this).find('.swiper-slide-active').index(),
    //            _SliderJum = $(this).find('.swiper-slide').eq(_Sliderindex).attr('data-src');
    //        console.log(_SliderJum, "抓到第"+(_Sliderindex + 1)+"個選單")
    //        window.location = _SliderJum;
    //    });
    //});

    // gray bar mobile
    

    //判斷mobile PC
    var detectmobile = false;
    (function (a, b) {
        if (!(/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino/i.test(a) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(a.substr(0, 4)))) detectmobile = true
    })(navigator.userAgent || navigator.vendor || window.opera, 'http://detectmobilebrowser.com/mobile');
    if (detectmobile) {
        // PC

        //抓取slider li 個數
        var slider_cou = $('#Allswiper .swiper-slide').length;
        var Nowindex = 0;
        var lastindex = $('#Allswiper .swiper-slide:last').index();
        //console.log('總共幾個' + slider_cou, lastindex);

        // slider ul 寬度
        $('.swiper-wrapper').css('width', slider_cou * 100 + '%');
        var slider_width = $('.swiper-wrapper').width();

        // slider li 寬度
        $('.swiper-slide').css('width', slider_width / slider_cou);
        var slider_li_width = $('.swiper-slide').width();

        // slider控制 左右
        //function moveRight() {
        //    $('.swiper-wrapper').animate({
        //        left: -slider_li_width
        //    }, 200, function () {
        //        $('.swiper-wrapper .swiper-slide:first-child').appendTo('.swiper-wrapper');
        //        $('.swiper-wrapper').css('left', '');
        //    });
        //    if (Nowindex <= slider_cou - 1) {
        //        Nowindex++;
        //    } else if (Nowindex = slider_cou - 1) {
        //        Nowindex = 1;
        //    }
            
        //};
        function moveRight() {
            if (Nowindex < slider_cou - 1) {
                Nowindex++;
            }
            $('.swiper-wrapper').animate({
                left: -slider_li_width * Nowindex
            }, 200);
            console.log(Nowindex);
        };

        //function moveLeft() {
        //    $('.swiper-wrapper').animate({
        //        left: +slider_li_width
        //    }, 200, function () {
        //        $('.swiper-wrapper .swiper-slide:last-child').prependTo('.swiper-wrapper');
        //        $('.swiper-wrapper').css('left', '');
        //    });
            
        //    if (Nowindex > 0 && Nowindex == 1) {
        //        Nowindex = slider_cou;
        //    }else {
        //        Nowindex--;
        //    }
            
        //};
        function moveLeft() {
            if (Nowindex > 0) {
                Nowindex--;
            }
            $('.swiper-wrapper').animate({
                left: slider_li_width - slider_li_width * (Nowindex + 1)
            },200);
            console.log(Nowindex, slider_li_width)

            

        };

        // 灰色子選單右邊按鈕
        $('.swiper-button-next').click(function () {
            moveRight();
            //alert('你抓到' + Nowindex + '個');
        });

        // 灰色子選單左邊按鈕
        $('.swiper-button-prev').click(function () {
            moveLeft();
            //alert('你抓到' + Nowindex + '個');
        });

    } else {
        // mobile
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
        $("#Allswiper").swipe({
            //Generic swipe handler for all directions
            swipe: function (event, direction, distance, duration, fingerCount, fingerData) {
                $(this).each(function (e) {
                    if ($('.swiper-slide').hasClass('swiper-slide-active')) {
                        var NewSrc = '',
                            NewIndex = $('.swiper-slide-active').index(),
                            NewSrc = $('.swiper-slide').eq(NewIndex).attr('data-src');
                        console.log(NewSrc, "抓到第" + (NewIndex + 1) + "個選單")
                    }
                    window.location = NewSrc;
                })
            },
            threshold: 0
        });

    }

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
