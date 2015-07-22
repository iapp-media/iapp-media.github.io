//初始化page
//1746694
function format(num) {
    var str = '0000000' + num;
    return str.slice(-7);
}
var tid = null;
var pid = null;
function initPage1() {
    window.clearTimeout(tid);
    window.clearTimeout(pid);
    var str = format(0);
    var arr = str.split('').map(function (val, key) {
        return '<div class="num num' + key + '">' + val + '</div>';
    });
    $('.page1 .num-wp').html(arr.join(''));
    var time = 3000;
    var step = parseInt(1746694 / (3000/15));
    function loop(num) {
        if (num >= 1746694) {
            return 0;
        }

        var str = format(num);
        var arr = str.split('').map(function (val, key) {
            return '<div class="num num' + key + '">' + val + '</div>';
        });
        $('.page1 .num-wp').html(arr.join(''));
        tid = window.setTimeout(function (){loop(num + step)}, 15);
    }
    loop(0);
    $('.page1 .wp').removeClass('no-anim');
    pid = window.setTimeout(function() {$('.page1 .wp').addClass('no-anim')}, 3500);
}
function initPage3() {
    window.clearTimeout(pid);
    $('.page3 .wp').removeClass('no-anim');
    pid = window.setTimeout(function() {$('.page3 .wp').addClass('no-anim')}, 3500);
}
function anim($svg, deg) {
    function loop(cur) {
        if (cur >= deg) {
            return 0;
        }
        var rad = cur / 180 * Math.PI;
        var x1 = 110 + Math.sin(rad) * 110;
        var y1 = 110 - Math.cos(rad) * 110;
        var x2 = 110 + Math.sin(rad) * 70;
        var y2 = 110 - Math.cos(rad) * 70;
        var flag1 = cur > 180 ? 1 : 0;
        $svg.attr('d', 'M110 0 A110 110 0 ' + flag1 + ' 1 ' + x1 + ' ' + y1 + ' L' + x2 + ' ' + y2 + ' A70 70 0 ' + flag1 + ' 0 110 40 L110 0');

        window.setTimeout(function () {loop(cur + 5)}, 10);
    }

    loop(5);
}
function initPage2() {
    $('.path1, .path2').attr('d', '');

    window.setTimeout(function () { anim($('.path1'), 230) }, 500);
    window.setTimeout(function () { anim($('.path2'), 200) }, 4500);
}
function initPage7(v) {
    var t = 0;
     function loop1() {
         if (t < 13) {
             sroll(v, t);
             t = t + 1;
             window.setTimeout(function () { loop1() }, 300);
         }
         else {
             sroll1(v);
         }

    }
    loop1();
  
//    window.setTimeout(function () { sroll(v, 1) }, 200);
//    window.setTimeout(function () { sroll(v, 2) }, 400);
//    window.setTimeout(function () { sroll(v, 3) }, 600);
//    window.setTimeout(function () { sroll(v, 5) }, 800);
//    window.setTimeout(function () { sroll(v, 6) }, 1000);
//    window.setTimeout(function () { sroll(v, 7) }, 1200);
//    window.setTimeout(function () { sroll(v, 8) }, 1400);
//    window.setTimeout(function () { sroll(v, 9) }, 1600);
//    window.setTimeout(function () { sroll(v, 10) }, 1800);
//    window.setTimeout(function () { sroll(v, 11) }, 2000);
//    window.setTimeout(function () { sroll(v, 12) }, 2200);
  
}
function sroll(v, i) {
    $('#page7-' + v).addClass('chart' + i);
}
function sroll1(v) {
    $('#page7-' + v).removeClass('chart0');
    $('#page7-' + v).removeClass('chart1');
    $('#page7-' + v).removeClass('chart2');
    $('#page7-' + v).removeClass('chart3');
    $('#page7-' + v).removeClass('chart4');
    $('#page7-' + v).removeClass('chart5');
    $('#page7-' + v).removeClass('chart6');
    $('#page7-' + v).removeClass('chart7');
    $('#page7-' + v).removeClass('chart8');
    $('#page7-' + v).removeClass('chart9');
    $('#page7-' + v).removeClass('chart10');
    $('#page7-' + v).removeClass('chart11');
    $('#page7-' + v).removeClass('chart12');
    $('#page7-' + v).addClass('chart');
}
function change(data) {
    if (data.cur === 1) {
        initPage1();
        return 1;
    }
    if (data.cur === 2) {
        initPage2();
        return 2;
    }
    if (data.cur === 3) {
        initPage3();
        return 3;
    }
    if (data.cur === 7) {
        initPage7(1);
        return 7;
    }
    if (data.cur === 8) {
        initPage7(2);
        return 8;
    }
}
function beforeChange(data) {
    if (data.cur in {'1': 0, '3': 0, '4': 0}) {
        $('.page' + data.cur + ' .wp').attr('style', '');
        return 1;
    }
}
;(function (g) {
    $('.container-inner').fullPage({start: 0, onchange: change, beforeChange: beforeChange});    
}(window));

function init() {
    var x = 0;
    $('.page1 .wp, .page3 .wp, .page4 .wp').on('touchstart', function(e) {
        e.preventDefault();
        x = e.targetTouches[0].pageX;
    });
    $('.page1 .wp, .page3 .wp, .page4 .wp').on('touchmove', function(e) {
        e.preventDefault();
        var temp = e.changedTouches[0].pageX - x;
        x = e.changedTouches[0].pageX;
        var $this = $(this);
        var w = $('body').width() + 200;
        var left = parseInt($this.css('left'), 10) + temp;
        left = left > 0 ? 0 : left && left < -w ? -w : left;
        $this.css('left',  left + 'px');
    });
    $('.page9').on('tap', function () { window.open("http://a.app.qq.com/o/simple.jsp?pkgname=com.ebodoo.babyplan"); });
//    var once = function () {
//        var au = new Audio();
//        au.src = 'media/bg.mp3';
//        au.loop = true;
//        au.play();
//        once = function () {};
//    }
//    $('.page0').on('touchstart', function () {
//        once();
//    }); 
}

init();


