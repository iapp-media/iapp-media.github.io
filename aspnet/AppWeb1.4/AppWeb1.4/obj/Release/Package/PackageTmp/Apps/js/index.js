//(function(){
var UPC =0;
var now = { row:1, col:1 }, last = { row:0, col:0};
const towards = { up:1, right:2, down:3, left:4};
var isAnimating = false;
var openOption = 'width=400,height=400';

//最大頁數設定
var maxPage=document.getElementById('MaxNum').value;

s=window.innerHeight/500;
ss=250*(1-s);

$('.wrap').css('-webkit-transform','scale('+s+','+s+') translate(0px,-'+ss+'px)');

//手勢，滑鼠，滾輪，鍵盤
document.addEventListener('touchmove',function(event){ event.preventDefault(); },false);

// document.addEventListener('mousemove',function(event){ event.preventDefault(); },false); 
// document.addEventListener('keyup',function(event){ event.preventDefault(); },false); 
// document.addEventListener('scroll',function(event){ event.preventDefault(); },false);
// document.addEventListener('keydown',function(event){ event.preventDefault(); },false);

$(document).swipeUp(function(){
    if (isAnimating) return;
    last.row = now.row;
    last.col = now.col;
    if (last.row != maxPage) { now.row = last.row+1; now.col = 1; pageMove(towards.up);}
    //判斷最後一頁跳至第一頁
    if (last.row == maxPage) { now.row = 1; now.col = 1; pageMove(towards.up);}	
})

$(document).keyup(function(){
    pageturn(); 
})
 

$(document).swipeDown(function(){
    if (isAnimating) return;
    last.row = now.row;
    last.col = now.col;
    if (last.row!=1) { now.row = last.row-1; now.col = 1; pageMove(towards.down);}	
    //判斷第一頁跳至最後一頁
    if (last.row == 1) { now.row = maxPage; now.col = 1; pageMove(towards.down);}	
})
 
function pageturn() {
    if (UPC==0) {
        UPC=1; 
    }else
    { 
        if (isAnimating) return;
        last.row = now.row;
        last.col = now.col;
        if (last.row != maxPage) { now.row = last.row+1; now.col = 1; pageMove(towards.up);}
        //判斷keyboard最後一頁跳至第一頁	
        if (last.row == maxPage) { now.row = 1; now.col = 1; pageMove(towards.up);}	
    }
}
function pageMove(tw){
    var lastPage = "#page-"+last.row+"-"+last.col,
		nowPage = "#page-"+now.row+"-"+now.col;
	 
    switch(tw) {
        case towards.up:
            outClass = 'moveToTop';
            inClass = 'moveFromBottom';
            break;
        case towards.right:
            outClass = 'moveToRight';
            inClass = 'moveFromLeft';
            break;
        case towards.down:
            outClass = 'moveToBottom';
            inClass = 'moveFromTop';
            break;
        case towards.left:
            outClass = 'moveToLeft';
            inClass = 'moveFromRight';
            break;
    }
    isAnimating = true;
    $(nowPage).removeClass("hide");
	
    $(lastPage).addClass(outClass);
    $(nowPage).addClass(inClass);
	
    setTimeout(function(){
        $(lastPage).removeClass('page-current');
        $(lastPage).removeClass(outClass);
        $(lastPage).addClass("hide");
        $(lastPage).find("img").addClass("hide");
		
        $(nowPage).addClass('page-current');
        $(nowPage).removeClass(inClass);
        $(nowPage).find("img").removeClass("hide");
		
        isAnimating = false;
    },600);
}

//})(); 
   
 
/*
    v1.2.0 說明  (以下說明上版時拿掉)
    使用zepto 執行原來的功能 
    $("body").append...要測試
    為了讓preview可以呼叫上下頁的動作，關閉了自閉函數的設定，未來要注意變數衝突的問題
    App中固定的div 分別是  #loading , .pagecover , .pagelast , .sharediv
    App中固定的物件className分別是  .logo .up .logo2 .qr .share .create .lastpg  #sharecancel #sharefb #sharetwitter #shareline

*/


Zepto(function($){ 

    $("#loading").hide();  

    $("body").append("<iframe src='http://www.iapp-media.com/act/click.aspx' style='display:none' />");

    // v1.2.0 加入click機制  //
    $(".up").click(function(){ 
        pageturn(); 
    });

    $(".share").click(function(){ 
        $(".sharediv").show();
    });

    $(".create").click(function(){ 
        window.open('../me/capp.aspx?i=' + getPathNoExt(),'_parent'); 
    });

    $("#sharecancel").click(function(){ 
        $(".sharediv").hide();
    });

    $("#sharefb").click(function(){ 
        if(document.cookie.indexOf("iapp_fbId=") != -1){

            FB.getLoginStatus(function (response) {
                if (response.status === 'connected') {
                 var params = {};
                 params['name'] = $("head meta[property='og:title']").attr('content'); 
                 params['description'] = $("head meta[property='og:description']").attr('content');
                 params['link'] = $("head meta[property='og:link']").attr('content'); 
                 params['picture'] = $("head meta[property='og:picture']").attr('content'); 

                 FB.api('/me/feed', 'post', params, function (response) {
                    if (!response || response.error) { 
                        window.open('https://www.facebook.com/sharer.php?u=' + window.location.href,'_blank',openOption);
                    } else { 
                        SendAjax('http://www.iapp-media.com/act/share.aspx?to=1&i=' + getPathNoExt());
                        alert('分享成功http://www.iapp-media.com/act/share.aspx?to=1&i=' + getPathNoExt());
                    }
                    });
                } else {
                    SendAjax('http://www.iapp-media.com/act/share.aspx?to=1&i=' + getPathNoExt());
                    window.open('https://www.facebook.com/sharer.php?u=' + window.location.href,'_blank', openOption); 
                }    
            });
        } else {    
            SendAjax('http://www.iapp-media.com/act/share.aspx?to=1&i=' + getPathNoExt());    
            window.open('https://www.facebook.com/sharer.php?u=' + window.location.href,'_blank', openOption);
        }
    });

    $("#sharetwitter").click(function(){ 
        SendAjax('http://www.iapp-media.com/act/share.aspx?to=2&i=' + getPathNoExt()); 
        window.open('http://twitter.com/intent/tweet?text=' + $("head meta[property='og:title']").attr('content') + $("head meta[property='og:url']").attr('content'),'_blank', openOption);
    });

    $("#shareline").click(function(){ 
        SendAjax('http://www.iapp-media.com/act/share.aspx?to=3&i=' + getPathNoExt()); 
        window.open('http://line.naver.jp/R/msg/text/?' + $("head meta[property='og:title']").attr('content') + $("head meta[property='og:url']").attr('content'),'_blank', openOption);
    });

});


// <!-- Google Analytics 分析 -->
// (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
//     (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
//     m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
// })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

// ga('create', 'UA-62535634-4', 'auto');
// ga('send', 'pageview');


//工具函數放在下面

function SendAjax(sendurl){
    var result='';
    $.ajax({
      type: 'GET',
      url: sendurl,
      success: function (w) {
        return 'success';
      },
      error: function () {
        return 'err';
      }
    }); 
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

function getPathNoExt() {
    var url = window.location.pathname;
    if (url.indexOf(".") > 0) { url = url.substring(url.lastIndexOf("/") + 1, url.indexOf(".")); } else { url = url.substring(url.lastIndexOf("/") + 1); }
    return url;
}
 