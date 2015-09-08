'use strict';
var picNum = 10;
var textNum = 4;
Parse.initialize("QjdehMNJpHm3oPhLP5sB4W6RFU4nsWnXJGXaw5nO", "t733V304NxKk6xmdZKXLopqNOc2NKVnLLLWQioEj");
var iObject = Parse.Object.extend("i");
var objectId = getValue('id');
var query = new Parse.Query(iObject);
// query.equalTo("objectId", objectId);
query.get(objectId, {
  success: function(object) {
    var picNum = object.get('picNum');
    var textNum = object.get('textNum');
    for (var j = 1; j <= textNum; j++) {
      document.getElementById('text' + ('0' + j).slice(-2)).value = object.get('text' + ('0' + j).slice(-2));

    }
    for (var k = 1; k <= picNum; k++) {
      if (object.get('f' + ('0' + k).slice(-2))) {
        document.getElementById('p' + ('0' + k).slice(-2)).src = object.get('pic' + ('0' + k).slice(-2)).url();
      }
    }
  },
  error: function(error) {}
});

var IObject = new iObject();
for (var i = 1; i <= picNum; i++) {
  IObject.set('f' + ('0' + i).slice(-2), false);
}
IObject.save({
  picNum: picNum,
  textNum: textNum
});

function sendImageToParse(num, imgBase64) {
  var parseFile = new Parse.File('p' + num + '.jpg', {
    base64: imgBase64
  }); //Parse 部分
  IObject.set('pic' + num, parseFile);
  IObject.set('f' + num, true);
  IObject.save({
    title: "maker",


  }, {
    success: function(object) {
      // alert("save image success");
    },
    error: function(object, error) {
      alert("上傳失敗");
      // The save failed.
      // error is a Parse.Error with an error code and message.
    }
  }).then(function(object) {});
}


function send() {
  document.getElementById('uploading').style.display = 'inline';
  var query = new Parse.Query(iObject);
  // console.log(query);
  query.get(IObject.id, {
    success: function(object) {
      var flag = true;
      for (var i = picNum; i > 0; i--) {
        flag = flag && object.get('f' + ('0' + i).slice(-2));

      }
      if (flag) {
        for (var i = 1; i <= textNum; i++) {
          IObject.set('text' + ('0' + i).slice(-2), document.getElementById('text'+ ('0' + i).slice(-2)).value);
        }
        IObject.save({
          
        }).then(function(object) {
          document.getElementById('uploading').style.display = 'none';
          alert("上傳完成");
          window.location = 'm-set.html?id=' + object.id;
        });
      } else {
        document.getElementById('uploading').style.display = 'none';
        alert("圖片尚未全部更換");
      }
    },
    error: function(object, error) {
      //
    }
  });
}

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