// function previewImage(fileInput, imgcanvas, width, height) {
//   //read uploading file
//   var reader = new FileReader();
//   var file = document.getElementById(fileInput).files[0];
//   // console.log(n);
//   reader.readAsDataURL(file);
//   reader.onload = function(oFREvent) {
//     // console.log(n);
//     document.getElementById(imgcanvas).src = oFREvent.target.result;
//     var output_format = "jpg";
//     document.getElementById(imgcanvas).src = jic.compress(document.getElementById(imgcanvas), width, height, output_format).src;
//     document.getElementById(imgcanvas).className = document.getElementById(imgcanvas).className.replace(/(?:^|\s)changestyle(?!\S)/g, '');
//     document.getElementById(imgcanvas + 'b').style.backgroundImage = 'url(' + document.getElementById(imgcanvas).src + ')';
//     document.getElementById(imgcanvas + 'b').className = document.getElementById(imgcanvas + 'b').className.replace(/(?:^|\s)changestyle(?!\S)/g, '');
//   };
// }
// Parse.initialize("QjdehMNJpHm3oPhLP5sB4W6RFU4nsWnXJGXaw5nO", "t733V304NxKk6xmdZKXLopqNOc2NKVnLLLWQioEj");

function preview() {
  document.getElementById('uploading').style.display = 'inline';
  // var flag1 = false;
  // var flag2 = false;
  // var flag31 = false;
  // var flag32 = false;
  // var flag33 = false;
  // var flag41 = false;
  // var flag42 = false;
  // var flag43 = false;
  // var flag5 = false;
  // var flag6 = false;

  // var imageBase64F1 = get64Stream('#file-input1', 'p1').replace(/^data:image\/(png|jpeg);base64,/, "");
  // var imageBase64F2 = get64Stream('#file-input2', 'p2').replace(/^data:image\/(png|jpeg);base64,/, "");
  // var imageBase64F31 = get64Stream('#file-input3-1', 'p3-1').replace(/^data:image\/(png|jpeg);base64,/, "");
  // var imageBase64F32 = get64Stream('#file-input3-2', 'p3-2').replace(/^data:image\/(png|jpeg);base64,/, "");
  // var imageBase64F33 = get64Stream('#file-input3-3', 'p3-3').replace(/^data:image\/(png|jpeg);base64,/, "");
  // var imageBase64F41 = get64Stream('#file-input4-1', 'p4-1').replace(/^data:image\/(png|jpeg);base64,/, "");
  // var imageBase64F42 = get64Stream('#file-input4-2', 'p4-2').replace(/^data:image\/(png|jpeg);base64,/, "");
  // var imageBase64F43 = get64Stream('#file-input4-3', 'p4-3').replace(/^data:image\/(png|jpeg);base64,/, "");
  // var imageBase64F5 = get64Stream('#file-input5', 'p5').replace(/^data:image\/(png|jpeg);base64,/, "");
  // var imageBase64F6 = get64Stream('#file-input6', 'p6').replace(/^data:image\/(png|jpeg);base64,/, "");

  // if (imageBase64F1.length > 0) {
  //   var parseFile1 = new Parse.File("p01.jpg", {
  //     base64: imageBase64F1
  //   }); //ParseFile 部分
  //   flag1 = true; //紀錄是否有圖
  // }
  // if (imageBase64F2.length > 0) {
  //   var parseFile2 = new Parse.File("p02.jpg", {
  //     base64: imageBase64F2
  //   });
  //   flag2 = true;
  // }
  // if (imageBase64F31.length > 0) {
  //   var parseFile31 = new Parse.File("p03-1.jpg", {
  //     base64: imageBase64F31
  //   });
  //   flag31 = true;
  // }
  // if (imageBase64F32.length > 0) {
  //   var parseFile32 = new Parse.File("p03-2.jpg", {
  //     base64: imageBase64F32
  //   });
  //   flag32 = true;
  // }
  // if (imageBase64F33.length > 0) {
  //   var parseFile33 = new Parse.File("p03-3.jpg", {
  //     base64: imageBase64F33
  //   });
  //   flag33 = true;
  // }
  // if (imageBase64F41.length > 0) {
  //   var parseFile41 = new Parse.File("p04-1.jpg", {
  //     base64: imageBase64F41
  //   });
  //   flag41 = true;
  // }
  // if (imageBase64F42.length > 0) {
  //   var parseFile42 = new Parse.File("p04-2.jpg", {
  //     base64: imageBase64F42
  //   });
  //   flag42 = true;
  // }
  // if (imageBase64F43.length > 0) {
  //   var parseFile43 = new Parse.File("p04-3.jpg", {
  //     base64: imageBase64F43
  //   });
  //   flag43 = true;
  // }
  // if (imageBase64F5.length > 0) {
  //   var parseFile5 = new Parse.File("p05.jpg", {
  //     base64: imageBase64F5
  //   });
  //   flag5 = true;
  // }
  // if (imageBase64F6.length > 0) {
  //   var parseFile6 = new Parse.File("p06.jpg", {
  //     base64: imageBase64F6
  //   });
  //   flag6 = true;
  // }

  var t21 = document.getElementById('p2-text1').value;
  var t22 = document.getElementById('p2-text2').value;
  var t61 = document.getElementById('p6-text1').value;
  var t71 = document.getElementById('p7-text1').value;

  //Parse 上傳部分
  var iObject = Parse.Object.extend("i");
  var IObject = new iObject();
  // IObject.set("pic1", parseFile1);
  // IObject.set("pic2", parseFile2);
  // IObject.set("pic31", parseFile31);
  // IObject.set("pic32", parseFile32);
  // IObject.set("pic33", parseFile33);
  // IObject.set("pic41", parseFile41);
  // IObject.set("pic42", parseFile42);
  // IObject.set("pic43", parseFile43);
  // IObject.set("pic5", parseFile5);
  // IObject.set("pic6", parseFile6);
  IObject.save({
    // title: "123",
    // f1: flag1,
    // f2: flag2,
    // f31: flag31,
    // f32: flag32,
    // f33: flag33,
    // f41: flag41,
    // f42: flag42,
    // f43: flag43,
    // f5: flag5,
    // f6: flag6,
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
  var flag1 = false;
  var flag2 = false;
  var flag31 = false;
  var flag32 = false;
  var flag33 = false;
  var flag41 = false;
  var flag42 = false;
  var flag43 = false;
  var flag5 = false;
  var flag6 = false;


  var imageBase64F1 = get64Stream('#file-input1', 'p1').replace(/^data:image\/(png|jpeg);base64,/, "");
  var imageBase64F2 = get64Stream('#file-input2', 'p2').replace(/^data:image\/(png|jpeg);base64,/, "");
  var imageBase64F31 = get64Stream('#file-input3-1', 'p3-1').replace(/^data:image\/(png|jpeg);base64,/, "");
  var imageBase64F32 = get64Stream('#file-input3-2', 'p3-2').replace(/^data:image\/(png|jpeg);base64,/, "");
  var imageBase64F33 = get64Stream('#file-input3-3', 'p3-3').replace(/^data:image\/(png|jpeg);base64,/, "");
  var imageBase64F41 = get64Stream('#file-input4-1', 'p4-1').replace(/^data:image\/(png|jpeg);base64,/, "");
  var imageBase64F42 = get64Stream('#file-input4-2', 'p4-2').replace(/^data:image\/(png|jpeg);base64,/, "");
  var imageBase64F43 = get64Stream('#file-input4-3', 'p4-3').replace(/^data:image\/(png|jpeg);base64,/, "");
  var imageBase64F5 = get64Stream('#file-input5', 'p5').replace(/^data:image\/(png|jpeg);base64,/, "");
  var imageBase64F6 = get64Stream('#file-input6', 'p6').replace(/^data:image\/(png|jpeg);base64,/, "");

  if (imageBase64F1.length > 0) {
    var parseFile1 = new Parse.File("p01.jpg", {
      base64: imageBase64F1
    }); //Parse 部分
    flag1 = true;
  }
  if (imageBase64F2.length > 0) {
    var parseFile2 = new Parse.File("p02.jpg", {
      base64: imageBase64F2
    });
    flag2 = true;
  }
  if (imageBase64F31.length > 0) {
    var parseFile31 = new Parse.File("p03-1.jpg", {
      base64: imageBase64F31
    });
    flag31 = true;
  }
  if (imageBase64F32.length > 0) {
    var parseFile32 = new Parse.File("p03-2.jpg", {
      base64: imageBase64F32
    });
    flag32 = true;
  }
  if (imageBase64F33.length > 0) {
    var parseFile33 = new Parse.File("p03-3.jpg", {
      base64: imageBase64F33
    });
    flag33 = true;
  }
  if (imageBase64F41.length > 0) {
    var parseFile41 = new Parse.File("p04-1.jpg", {
      base64: imageBase64F41
    });
    flag41 = true;
  }
  if (imageBase64F42.length > 0) {
    var parseFile42 = new Parse.File("p04-2.jpg", {
      base64: imageBase64F42
    });
    flag42 = true;
  }
  if (imageBase64F43.length > 0) {
    var parseFile43 = new Parse.File("p04-3.jpg", {
      base64: imageBase64F43
    });
    flag43 = true;
  }
  if (imageBase64F5.length > 0) {
    var parseFile5 = new Parse.File("p05.jpg", {
      base64: imageBase64F5
    });
    flag5 = true;
  }
  if (imageBase64F6.length > 0) {
    var parseFile6 = new Parse.File("p06.jpg", {
      base64: imageBase64F6
    });
    flag6 = true;
  }

  var t21 = document.getElementById('p2-text1').value;
  var t22 = document.getElementById('p2-text2').value;
  var t61 = document.getElementById('p6-text1').value;
  var t71 = document.getElementById('p7-text1').value;

  //check whether replace all
  if (!(flag1 && flag2 && flag31 && flag32 && flag33 && flag41 && flag42 && flag43 && flag5 && flag6)) {
    document.getElementById('uploading').style.display = 'none';
    alert("圖片尚未全部更換");
  } else {
    var iObject = Parse.Object.extend("i");
    var IObject = new iObject();
    IObject.set("pic1", parseFile1);
    IObject.set("pic2", parseFile2);
    IObject.set("pic31", parseFile31);
    IObject.set("pic32", parseFile32);
    IObject.set("pic33", parseFile33);
    IObject.set("pic41", parseFile41);
    IObject.set("pic42", parseFile42);
    IObject.set("pic43", parseFile43);
    IObject.set("pic5", parseFile5);
    IObject.set("pic6", parseFile6);
    IObject.save({
      title: "123",
      t21: t21,
      t22: t22,
      t61: t61,
      t71: t71,
      f1: flag1,
      f2: flag2,
      f31: flag31,
      f32: flag32,
      f33: flag33,
      f41: flag41,
      f42: flag42,
      f43: flag43,
      f5: flag5,
      f6: flag6
    }).then(function(object) {
      document.getElementById('uploading').style.display = 'none';
      alert("save comment success");
      window.location = 'index.html?id=' + object.id;
    });
  }
}

// function getValue(varname) {
//   var url = window.location.href;
//   var qparts = url.split("?");
//   if (qparts.length == 0) {
//     return "";
//   }
//   var query = qparts[1];
//   var vars = query.split("&amp;");
//   var value = "";
//   for (i = 0; i < vars.length; i++) {
//     var parts = vars[i].split("=");
//     if (parts[0] == varname) {
//       value = parts[1];
//       break;
//     }
//   }
//   value = unescape(value);
//   value.replace(/\+/g, " ");
//   return value;
// }

// function get64Stream(fileInput, imgcanvas) {
//   var fileUploadControl = $(fileInput)[0];
//   if (fileUploadControl.files.length > 0) {
//     return document.getElementById(imgcanvas).src;
//   } else {
//     return "";
//   }
// }
