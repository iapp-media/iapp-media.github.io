'use strict';
//Parse.initialize("QjdehMNJpHm3oPhLP5sB4W6RFU4nsWnXJGXaw5nO", "t733V304NxKk6xmdZKXLopqNOc2NKVnLLLWQioEj");
Parse.initialize("LD5YXs0MuB68HbSzl6QW0RMXKfHlYRNgGx1zi7y8", "lJrNywD6Nwg385fbD2iZXYMu28qMneb75UkYVVJB");
var objectId = getValue('id');
var picNum = 10;
var textNum = 4;
var iObject = Parse.Object.extend('j');
var query = new Parse.Query(iObject);
// query.equalTo("objectId", objectId);
query.get(objectId, {
  success: function(object) {
    // for (var i = 0; i < results.length; i++) {
    // var object = results;
    picNum = object.get('picNum');
    textNum = object.get('textNum');
    // console.log(document.getElementById('p2-text1').value);
    for (var j = 1; j <= textNum; j++) {
      document.getElementById('text' + ('0' + j).slice(-2)).innerText = object.get('text' + ('0' + j).slice(-2));

    }
    for (var k = 1; k <= picNum; k++) {
      if (object.get('f' + ('0' + k).slice(-2))) {
        document.getElementById('p' + ('0' + k).slice(-2)).src = object.get('pic' + ('0' + k).slice(-2)).url();
      }
    }
    // $('#shareLink').attr('href', 'm-setshare.html?id=' + objectId);
    // $("meta[property='og\\:image']").attr("content", document.getElementById('p01').src);
    $('.qr').attr('src', 'http://chart.apis.google.com/chart?chs=200x200&chl=http://www.iapp-media.net/iappsocial/index.html?id=' + objectId + '&chld=L|0&choe=UTF-8&cht=qr');
    $('.create').click(function() {
      object.increment('createNumber');
      object.save();
      // window.location = 'maker.html';
    });
    $('.share').click(function() {
      object.increment('shareNumber');
      object.save();
      window.location = 'm-setshare.html?id=' + objectId;
    });
    // }
  },
  error: function(error) {}
});

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
      IObject.set('text' + ('0' + j).slice(-2),document.getElementById('text' + ('0' + j).slice(-2)).innerText);

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
