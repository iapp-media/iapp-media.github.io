'use strict';
(function() {

    var now = {
            row: 1,
            col: 1
        },
        last = {
            row: 0,
            col: 0
        };
    var towards = {
        up: 1,
        right: 2,
        down: 3,
        left: 4
    };
    var isAnimating = false;

    //最大頁數設定
    var maxPage = 7;

    var s = window.innerHeight / 500;
    var ss = 250 * (1 - s);

    $('.wrap').css('-webkit-transform', 'scale(' + s + ',' + s + ') translate(0px,-' + ss + 'px)');

    //手勢，滑鼠，滾輪，鍵盤
    document.addEventListener('touchmove', function(event) {
        event.preventDefault();
    }, false);

    // document.addEventListener('mousemove',function(event){ event.preventDefault(); },false);

    document.addEventListener('keyup', function(event) {
        event.preventDefault();
    }, false);

    //document.addEventListener('scroll',function(event){ event.preventDefault(); },false);
    // document.addEventListener('keydown',function(event){ event.preventDefault(); },false);

    $(document).swipeUp(function() {
        if (isAnimating) return;
        last.row = now.row;
        last.col = now.col;
        if (last.row != maxPage) {
            now.row = last.row + 1;
            now.col = 1;
            pageMove(towards.up);
        }
        $(function() {
                if (now.row == 5) {
                    $(".flipster").flipster({
                        style: 'carousel',
                        start: 0
                    });
                    $('.flip-items').css('width', '100%')
                } else if (now.row !== 5) {
                    $('.flipster').unbind('flipster');
                    var classes = $(".flipster,.flipster-active, .flipster-carousel").attr("style", "class");
                    $(".flipster").removeAttr("style", "class");

                }
            })
            //判斷最後一頁跳至第一頁
        if (last.row == maxPage) {
            now.row = 1;
            now.col = 1;
            pageMove(towards.up);

        }

    });

    $(document).keyup(function(e) {
        if (isAnimating) return;
        last.row = now.row;
        last.col = now.col;
        if (e.keyCode == 40) {
            if (last.row != maxPage) {
                now.row = last.row + 1;
                now.col = 1;
                pageMove(towards.up);
                $(function() {
                    var Classflips = $(".flipster");
                    if (now.row == 5) {
                        Classflips.flipster({
                            style: 'carousel',
                            start: 0
                        });
                        $('.flip-items').css('width', '100%')
                    } else if (now.row !== 5) {
                        Classflips.unbind('flipster');
                        var classes = $(".flipster,.flipster-active, .flipster-carousel").attr("style", "class");
                        Classflips.removeAttr("style", "class");

                    }
                })
            }
            //判斷keyboard最後一頁跳至第一頁 
            if (last.row == maxPage) {
                now.row = 1;
                now.col = 1;
                pageMove(towards.up);
            }
        } else if (e.keyCode == 38) {
            if (last.row != 1) {
                now.row = last.row - 1;
                now.col = 1;
                pageMove(towards.down);
            }
            //判斷第一頁跳至最後一頁
            if (last.row == 1) {
                now.row = maxPage;
                now.col = 1;
                pageMove(towards.down);
            }
        }
    });



    // $(document).mouseup(function(){
    // if (isAnimating) return;
    //  last.row = now.row;
    //  last.col = now.col;
    //  if (last.row != maxPage) { now.row = last.row+1; now.col = 1; pageMove(towards.up);}  
    //  if (last.row == maxPage) { now.row = 1; now.col = 1; pageMove(towards.up);}
    // }) 
    // $(document).scrollup(function(){
    // if (isAnimating) return;
    //  last.row = now.row;
    //  last.col = now.col;
    //  if (last.row != maxPage) { now.row = last.row+1; now.col = 1; pageMove(towards.up);}  
    // })  

    $(document).swipeDown(function() {
        if (isAnimating) return;
        last.row = now.row;
        last.col = now.col;
        if (last.row != 1) {
            now.row = last.row - 1;
            now.col = 1;
            pageMove(towards.down);
        }
        //判斷第一頁跳至最後一頁
        if (last.row == 1) {
            now.row = maxPage;
            now.col = 1;
            pageMove(towards.down);
        }
    });

    // $(document).mouseDown(function(){
    //  if (isAnimating) return;
    //  last.row = now.row;
    //  last.col = now.col;
    //  if (last.row!=1) { now.row = last.row-1; now.col = 1; pageMove(towards.down);}  
    // })
    // $(document).keydown(function(){
    //  if (isAnimating) return;
    //  last.row = now.row;
    //  last.col = now.col;
    //  if (last.row!=1) { now.row = last.row-1; now.col = 1; pageMove(towards.down);}  
    // })

    // $(document).swipeLeft(function(){
    //  if (isAnimating) return;
    //  last.row = now.row;
    //  last.col = now.col;
    //  if (last.row>1 && last.row<maxPage+1 && last.col==1) { now.row = last.row; now.col = 2; pageMove(towards.left);}  
    // })

    // $(document).swipeRight(function(){
    //  if (isAnimating) return;
    //  last.row = now.row;
    //  last.col = now.col;
    //  if (last.row>1 && last.row<maxPage && last.col==2) { now.row = last.row; now.col = 1; pageMove(towards.right);} 
    // })


    document.getElementById('jump2').addEventListener('click', function() {
        pageJump(2, 1);
    });

    function pageJump(row, col) {

        if (isAnimating) return;
        last.row = now.row;
        last.col = now.col;
        if (last.row < row) {
            now.row = row;
            now.col = col;
            pageMove(towards.up);
        }
        //判斷keyboard最後一頁跳至第一頁 
        else if (last.row > row) {
            now.row = row;
            now.col = col;
            pageMove(towards.down);
        } else {
            if (last.col < col) {
                now.row = row;
                now.col = col;
                pageMove(towards.left);
            } else if (last.col > col) {
                now.row = row;
                now.col = col;
                pageMove(towards.right);
            }
        }
    }

    function pageMove(tw) {
        var lastPage = '.page-' + last.row + '-' + last.col,
            nowPage = '.page-' + now.row + '-' + now.col,
            outClass, inClass;

        switch (tw) {
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
        $(nowPage).removeClass('hide');

        $(lastPage).addClass(outClass);
        $(nowPage).addClass(inClass);

        setTimeout(function() {
            $(lastPage).removeClass('page-current');
            $(lastPage).removeClass(outClass);
            $(lastPage).addClass('hide');
            $(lastPage).find('img').addClass('hide');

            $(nowPage).addClass('page-current');
            $(nowPage).removeClass(inClass);
            $(nowPage).find('img').removeClass('hide');

            isAnimating = false;
        }, 600);
    }


})();
