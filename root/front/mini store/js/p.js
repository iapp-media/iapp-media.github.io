'use strict';
//Parse.initialize("QjdehMNJpHm3oPhLP5sB4W6RFU4nsWnXJGXaw5nO", "t733V304NxKk6xmdZKXLopqNOc2NKVnLLLWQioEj");
Parse.initialize("LD5YXs0MuB68HbSzl6QW0RMXKfHlYRNgGx1zi7y8", "lJrNywD6Nwg385fbD2iZXYMu28qMneb75UkYVVJB");
var iObject = Parse.Object.extend('j');
// var query = new Parse.Query(iObject);
// query.limit(1000);
// // query.equalTo("objectId", objectId);
// query.find({
//   success: function(results) {
//     //query.limit(1000); // limit to at most 10 results
//     //query.skip(99); // skip the first 10 results
//     console.log("Successfully retrieved : " + results.length);
//     //alert("Successfully retrieved" + results.length);
//     for (var i = 0; i < results.length; i++) {
//       var object = results[i];
//       console.log(object.id + '-' + object.get('picNum'));
//     }
//   },
//   error: function(error) {
//     console.log("Error : " + error.code + " " + error.message);
//     //alert("Error:" + error.code + " " + error.message);
//   }
// });
getAllRecords(0);

function getAllRecords(loopCount) {

  ///set your record limit
  var limit = 100;

  ///create your eggstra-special query
  var query = new Parse.Query(iObject)
    .descending("updatedAt")
    .limit(limit)
    .skip(limit * loopCount) //<-important
    .find({
      success: function(results) {
        if (results.length > 0) {

          //we do stuff in here like "add items to a collection of cool things"
          for (var j = 0; j < results.length; j++) {
            if (results[j].get('f01')) {
              $('#container').append('<div class="item" id="'+results[j].id+'"><div class = "imgcenter" ><div> <a class = "apps-info"href = "iapp-mobile.html?url=' + 'ilife/index.html' + '&id=' + results[j].id + '" > <img class = "item-pic"src = ' + results[j].get('pic01').url() + ' / > </a> <div class = "item-bar" > <section class = "content" ><ul class = "list" ><li class = "list__item" ><label class = "label--checkbox" ><input type = "checkbox"class = "good" ><p >' + results[j].get('likeNumber') + '</p> </label > </li> <li class = "list__item" > <label class = "label--checkbox" ><input type = "checkbox"class = "like" ><p >' + results[j].get('loveNumber') + ' </p> </label > </li> <li class = "list__item" > <label class = "label--checkbox" ><input type = "checkbox"class = "startoggle" ></label> </li > </ul> </section > </div> </div > <p class = "describe" >' + results[j].get('memo') + '</p> <img class = "circle" alt = "頭貼" src = "" ><p class = "iapp-name" >' + results[j].get('title') + '<p class = "author" > by <a href = "http://www.iapp-media.net/mommy/"" target="_blank ">' + 'name' + '</a></p> </div> </div>');
            }

          }

          loopCount++; //<--increment our loop because we are not done

          getAllRecords(loopCount); //<--recurse
        } else {
          //our query has run out of steam, this else{} will be called one time only
          // coolCollection.each(function(coolThing) {
          //do something awesome with each of your cool things
          // });
          var $container = $('#container');

          $container.imagesLoaded(function() {
            $container.masonry({
              itemSelector: '.item',
              columnWidth: 20,
              isAnimated: true,
              isFitWidth: true
            });
          });
        }
      },
      error: function(error) {
        //badness with the find
      }
    });

}



//console.log(query);


//query.get(objectId, {
//success: function(object) {
// for (var i = 0; i < results.length; i++) {
// var object = results;
//picNum = object.get('picNum');
//textNum = object.get('textNum');
// console.log(document.getElementById('p2-text1').value);
//for (var j = 1; j <= textNum; j++) {
//  document.getElementById('text' + ('0' + j).slice(-2)).innerText = object.get('text' + ('0' + j).slice(-2));

//}
//for (var k = 1; k <= picNum; k++) {
//  if (object.get('f' + ('0' + k).slice(-2))) {
//    document.getElementById('p' + ('0' + k).slice(-2)).src = object.get('pic' + ('0' + k).slice(-2)).url();
//  }
//}
// $('#shareLink').attr('href', 'm-setshare.html?id=' + objectId);
// $("meta[property='og\\:image']").attr("content", document.getElementById('p01').src);
//$('.qr').attr('src', 'http://chart.apis.google.com/chart?chs=200x200&chl=http://www.iapp-media.net/iappsocial/index.html?id=' + objectId + '&chld=L|0&choe=UTF-8&cht=qr');
//$('.create').click(function() {
//  object.increment('createNumber');
//  object.save();
// window.location = 'maker.html';
//});
//$('.share').click(function() {
//  object.increment('shareNumber');
//  object.save();
//  window.location = 'm-setshare.html?id=' + objectId;
//});
// }
// },
// error: function(error) {}
//});

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


$('.create').click(function() {
  var IObject = new iObject();
  for (var i = 1; i <= picNum; i++) {
    IObject.set('f' + ('0' + i).slice(-2), false);
  }
  for (var j = 1; j <= textNum; j++) {
    IObject.set('text' + ('0' + j).slice(-2), document.getElementById('text' + ('0' + j).slice(-2)).innerText);

  }
  IObject.save({
    picNum: picNum,
    textNum: textNum
  }, {
    success: function(object) {
      window.location = 'maker.html?id=' + IObject.id + '&from=' + objectId;
    },
    error: function(object, error) {
      alert("建立失敗");
    }
  });
});

$('#search').change(function() {
  // $('.item').remove();
  this.blur();
  $('#container').focus();
  $('#container').masonry('remove',$('.item')).masonry();
  var keyword = $('#search').val();
  searchKeyword(0, keyword);

});
$('#searchWeb').change(function() {
  this.blur();
  $('#container').focus();
  $('#container').masonry('remove',$('.item')).masonry();
  var keyword = $('#searchWeb').val();
  searchKeyword(0, keyword);

});
function searchKeyword(loopCount, keyword) {
  var limit = 100;

  var searchTitle = new Parse.Query(iObject)
    .contains('title', keyword);
  var searchMemo = new Parse.Query(iObject)
    .contains('memo', keyword);

  var search = new Parse.Query.or(searchTitle, searchMemo);
  search
    .descending("updatedAt")
    .limit(limit)
    .skip(limit * loopCount)
    .find({
      success: function(results) {
        console.log(results);
        if (results.length > 0) {
          for (var j = 0; j < results.length; j++) {
            if (results[j].get('f01')) {
              var $container = $('#container');
              var $items = $('<div class="item" id="item-iapp"><div class = "imgcenter" ><div> <a class = "apps-info"href = "iapp-mobile.html?url=' + 'ilife/index.html' + '&id=' + results[j].id + '" > <img class = "item-pic"src = ' + results[j].get('pic01').url() + ' / > </a> <div class = "item-bar" > <section class = "content" ><ul class = "list" ><li class = "list__item" ><label class = "label--checkbox" ><input type = "checkbox"class = "good" ><p >' + results[j].get('likeNumber') + '</p> </label > </li> <li class = "list__item" > <label class = "label--checkbox" ><input type = "checkbox"class = "like" ><p >' + results[j].get('loveNumber') + ' </p> </label > </li> <li class = "list__item" > <label class = "label--checkbox" ><input type = "checkbox"class = "startoggle" ></label> </li > </ul> </section > </div> </div > <p class = "describe" >' + results[j].get('memo') + '</p> <img class = "circle" alt = "頭貼" src = "" ><p class = "iapp-name" >' + results[j].get('title') + '<p class = "author" > by <a href = "http://www.iapp-media.net/mommy/"" target="_blank ">' + 'name' + '</a></p> </div> </div>');

              $container.append($items).masonry( 'appended', $items );
;
            }
          }

          loopCount++;
          searchKeyword(loopCount, keyword);
        } else {
          //           setTimeout(function() {
          // var $container = $('#container');
          // console.log($container);

          // $container.imagesLoaded(function() {

          //   $container.masonry({
          //     itemSelector: '.item',
          //     columnWidth: 20,
          //     isAnimated: true,
          //     isFitWidth: true
          //   });
          // });
          //           },500);

        }
      },
      error: function(object, error) {
        alert("建立失敗");
      }
    });
}
