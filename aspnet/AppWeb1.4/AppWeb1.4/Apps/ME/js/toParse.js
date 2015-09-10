Parse.initialize("QjdehMNJpHm3oPhLP5sB4W6RFU4nsWnXJGXaw5nO", "t733V304NxKk6xmdZKXLopqNOc2NKVnLLLWQioEj");
var iObject = Parse.Object.extend("i");
var IObject = new iObject();
IObject.save({
  f1: false,
  f2: false,
  f31: false,
  f32: false,
  f33: false,
  f41: false,
  f42: false,
  f43: false,
  f5: false,
  f6: false
});

function sendImageToParse(num, imgBase64) {
  var parseFile = new Parse.File('p0' + num + '.jpg', {
    base64: imgBase64
  }); //Parse 部分
  IObject.set('pic' + num, parseFile);
  IObject.set('f' + num, true);
  IObject.save({
    title: "maker",


  }, {
    success: function(object) {
      alert("save image success");
    },
    error: function(object, error) {
      alert("save image failed");
      // The save failed.
      // error is a Parse.Error with an error code and message.
    }
  }).then(function(object) {});
}

function preview() {
  document.getElementById('uploading').style.display = 'inline';
  var t21 = document.getElementById('p2-text1').value;
  var t22 = document.getElementById('p2-text2').value;
  var t61 = document.getElementById('p6-text1').value;
  var t71 = document.getElementById('p7-text1').value;
  IObject.save({
    t21: t21,
    t22: t22,
    t61: t61,
    t71: t71
  }).then(function(object) {
    document.getElementById('uploading').style.display = 'none';
    alert("save comment success");
    window.location = 'preview.html?id=' + object.id;
  });

}

function send() {
  document.getElementById('uploading').style.display = 'inline';
  var query = new Parse.Query(iObject);
  // console.log(query);
  query.get(IObject.id, {
    success: function(object) {

      var flag1 = object.get('f1');
      var flag2 = object.get('f2');
      var flag31 = object.get('f31');
      var flag32 = object.get('f32');
      var flag33 = object.get('f33');
      var flag41 = object.get('f41');
      var flag42 = object.get('f42');
      var flag43 = object.get('f43');
      var flag5 = object.get('f5');
      var flag6 = object.get('f6');
      if (flag1 && flag2 && flag31 && flag32 && flag33 && flag41 && flag42 && flag43 && flag5 && flag6) {
        var t21 = document.getElementById('p2-text1').value;
        var t22 = document.getElementById('p2-text2').value;
        var t61 = document.getElementById('p6-text1').value;
        var t71 = document.getElementById('p7-text1').value;
        IObject.save({
          t21: t21,
          t22: t22,
          t61: t61,
          t71: t71
        }).then(function(object) {
          document.getElementById('uploading').style.display = 'none';
          alert("save comment success");
          window.location = 'index.html?id=' + object.id;
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
