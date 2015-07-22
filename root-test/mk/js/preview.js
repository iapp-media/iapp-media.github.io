function previewImage(n) {
	//read uploading file
	var reader = new FileReader();
	var file = document.getElementById('file-input'+n).files[0];
	// console.log(n);
	reader.readAsDataURL(file);
	reader.onload = function (oFREvent) {
		// console.log(n);
		document.getElementById('p'+n).src=oFREvent.target.result;
		document.getElementById('p'+n).style.backgroundImage = 'url('+oFREvent.target.result+')';//change backgroundImage
		document.getElementById('p'+n).className=document.getElementById('p'+n).className.replace(/(?:^|\s)changestyle(?!\S)/g , '')
		//remove class 'changestyle'
	};
}
Parse.initialize("QjdehMNJpHm3oPhLP5sB4W6RFU4nsWnXJGXaw5nO", "t733V304NxKk6xmdZKXLopqNOc2NKVnLLLWQioEj");
objectId = getValue("id");

var IObject = Parse.Object.extend("i");
var query = new Parse.Query(IObject);
query.equalTo("objectId",objectId);
query.find({
	success: function(results) {
		for (var i = 0; i < results.length; i++) { 
			var object = results[i];
			document.getElementById('p2-text1').value = object.get('t21');
			document.getElementById('p2-text2').value = object.get('t22');
			document.getElementById('p6-text1').value = object.get('t61');
			document.getElementById('p7-text1').value = object.get('t71');

			if(object.get('f1')){
				// document.getElementById("p1").src=object.get('pic1').url();
				document.getElementById('p1').style.backgroundImage = 'url('+object.get('pic1').url()+')';
				document.getElementById('p1').className=document.getElementById('p1').className.replace(/(?:^|\s)changestyle(?!\S)/g , '')

				//change backgroundImage
			}
			if(object.get('f2')){
				// document.getElementById("p2").src=object.get('pic2').url();
				document.getElementById('p2').style.backgroundImage = 'url('+object.get('pic2').url()+')';
				document.getElementById('p2').className=document.getElementById('p2').className.replace(/(?:^|\s)changestyle(?!\S)/g , '')

			}
			if(object.get('f31')){
				document.getElementById("p3-1").src=object.get('pic31').url();
				document.getElementById('p3-1').className=document.getElementById('p3-1').className.replace(/(?:^|\s)changestyle(?!\S)/g , '')

			}
			if(object.get('f32')){
				document.getElementById("p3-2").src=object.get('pic32').url();
				document.getElementById('p3-2').className=document.getElementById('p3-2').className.replace(/(?:^|\s)changestyle(?!\S)/g , '')

			}
			if(object.get('f33')){
				document.getElementById("p3-3").src=object.get('pic33').url();
				document.getElementById('p3-3').className=document.getElementById('p3-3').className.replace(/(?:^|\s)changestyle(?!\S)/g , '')

			}
			if(object.get('f41')){
				document.getElementById("p4-1").src=object.get('pic41').url();
				document.getElementById('p4-1').className=document.getElementById('p4-1').className.replace(/(?:^|\s)changestyle(?!\S)/g , '')

			}
			// document.getElementById('p4-1').className=document.getElementById('p4-1').className.replace(/(?:^|\s)changestyle(?!\S)/g , '')
			if(object.get('f42')){
				document.getElementById("p4-2").src=object.get('pic42').url();
				document.getElementById('p4-2').className=document.getElementById('p4-2').className.replace(/(?:^|\s)changestyle(?!\S)/g , '')

			}
			if(object.get('f43')){
				document.getElementById("p4-3").src=object.get('pic43').url();
				document.getElementById('p4-3').className=document.getElementById('p4-3').className.replace(/(?:^|\s)changestyle(?!\S)/g , '')
			}
			if(object.get('f5')){
				document.getElementById('p5').style.backgroundImage = 'url('+object.get('pic5').url()+')';
				document.getElementById('p5').className=document.getElementById('p5').className.replace(/(?:^|\s)changestyle(?!\S)/g , '')

			}
			if(object.get('f6')){
				// console.log(object.get('f6'));
				document.getElementById('p6').className=document.getElementById('p6').className.replace(/(?:^|\s)changestyle(?!\S)/g , '')

				// document.getElementById("p6").src=object.get('pic6').url();
				document.getElementById('p6').style.backgroundImage = 'url('+object.get('pic6').url()+')';

			}
		}
	},
	error: function(error) {
	}
});




function preview(){
	
	var fileUploadControl1 = $('#file-input1')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p01.jpg";
		var parseFile1 = new Parse.File(name1, file1);
		var flag1 = true;
	}
	var fileUploadControl1 = $('#file-input2')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p02.jpg";
		var parseFile2 = new Parse.File(name1, file1);
		var flag2 = true;
	}
	var fileUploadControl1 = $('#file-input3-1')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p03-1.jpg";
		var parseFile31 = new Parse.File(name1, file1);
		var flag31 = true;
	}
	var fileUploadControl1 = $('#file-input3-2')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p03-2.jpg";
		var parseFile32 = new Parse.File(name1, file1);
		var flag32 = true;
	}
	var fileUploadControl1 = $('#file-input3-3')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p03-3.jpg";
		var parseFile33 = new Parse.File(name1, file1);
		var flag33 = true;
	}
	var fileUploadControl1 = $('#file-input4-1')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p04-1.jpg";
		var parseFile41 = new Parse.File(name1, file1);
		var flag41 = true;
	}
	var fileUploadControl1 = $('#file-input4-2')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p04-2.jpg";
		var parseFile42 = new Parse.File(name1, file1);
		var flag42 = true;
	}
	var fileUploadControl1 = $('#file-input4-3')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p04-3.jpg";
		var parseFile43 = new Parse.File(name1, file1);
		var flag43 = true;
	}
	var fileUploadControl1 = $('#file-input5')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p05.jpg";
		var parseFile5 = new Parse.File(name1, file1);
		var flag5 = true;
	}
	var fileUploadControl1 = $('#file-input6')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p06.jpg";
		var parseFile6 = new Parse.File(name1, file1);
		var flag6 = true;
	}
	var t21=document.getElementById('p2-text1').value;
	var t22=document.getElementById('p2-text2').value;
	var t61=document.getElementById('p6-text1').value;
	var t71=document.getElementById('p7-text1').value;
	var iObject = Parse.Object.extend("i");
	var query = new Parse.Query(iObject);
	query.get(objectId, {
		success: function(IObject) {
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
				title:"123",
				t21:t21,
				t22:t22,
				t61:t61,
				t71:t71,
				f1:flag1,
				f2:flag2,
				f31:flag31,
				f32:flag32,
				f33:flag33,
				f41:flag41,
				f42:flag42,
				f43:flag43,
				f5:flag5,
				f6:flag6
			}).then(function(object) {
				alert("save comment success");
				window.location = 'preview.html?id='+object.id ;
			});

		},
		error: function(object, error) {
			// var IObject= new iObject();
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
			// IObject.save({
			// 	title:"123",
			// 	t21:t21,
			// 	t22:t22,
			// 	t61:t61,
			// 	t71:t71,
			// 	f1:flag1,
			// 	f2:flag2,
			// 	f31:flag31,
			// 	f32:flag32,
			// 	f33:flag33,
			// 	f41:flag41,
			// 	f42:flag42,
			// 	f43:flag43,
			// 	f5:flag5,
			// 	f6:flag6
			// }).then(function(object) {
			// 	alert("save comment success");
			// 	window.location = 'preview.html?id='+object.id ;
			// });
		}
	});
}

function send(){
	
	var fileUploadControl1 = $('#file-input1')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p01.jpg";
		var parseFile1 = new Parse.File(name1, file1);
		var flag1 = true;
	}
	var fileUploadControl1 = $('#file-input2')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p02.jpg";
		var parseFile2 = new Parse.File(name1, file1);
		var flag2 = true;
	}
	var fileUploadControl1 = $('#file-input3-1')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p03-1.jpg";
		var parseFile31 = new Parse.File(name1, file1);
		var flag31 = true;
	}
	var fileUploadControl1 = $('#file-input3-2')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p03-2.jpg";
		var parseFile32 = new Parse.File(name1, file1);
		var flag32 = true;
	}
	var fileUploadControl1 = $('#file-input3-3')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p03-3.jpg";
		var parseFile33 = new Parse.File(name1, file1);
		var flag33 = true;
	}
	var fileUploadControl1 = $('#file-input4-1')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p04-1.jpg";
		var parseFile41 = new Parse.File(name1, file1);
		var flag41 = true;
	}
	var fileUploadControl1 = $('#file-input4-2')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p04-2.jpg";
		var parseFile42 = new Parse.File(name1, file1);
		var flag42 = true;
	}
	var fileUploadControl1 = $('#file-input4-3')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p04-3.jpg";
		var parseFile43 = new Parse.File(name1, file1);
		var flag43 = true;
	}
	var fileUploadControl1 = $('#file-input5')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p05.jpg";
		var parseFile5 = new Parse.File(name1, file1);
		var flag5 = true;
	}
	var fileUploadControl1 = $('#file-input6')[0];
	if (fileUploadControl1.files.length > 0) {
		var file1 = fileUploadControl1.files[0];
		var name1 = "p06.jpg";
		var parseFile6 = new Parse.File(name1, file1);
		var flag6 = true;
	}



	var t21=document.getElementById('p2-text1').value;
	var t22=document.getElementById('p2-text2').value;
	var t61=document.getElementById('p6-text1').value;
	var t71=document.getElementById('p7-text1').value;

	var iObject = Parse.Object.extend("i");
	var query = new Parse.Query(iObject);
	query.get(objectId, {
		success: function(IObject) {
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
				title:"123",
				t21:t21,
				t22:t22,
				t61:t61,
				t71:t71,
				f1:flag1,
				f2:flag2,
				f31:flag31,
				f32:flag32,
				f33:flag33,
				f41:flag41,
				f42:flag42,
				f43:flag43,
				f5:flag5,
				f6:flag6
			}).then(function(object) {
				alert("save comment success");
				window.location = 'index.html?id='+object.id ;
			});

		},
		error: function(object, error) {
			
		}
	});
}

function getValue(varname)
{
	var url = window.location.href;
	var qparts = url.split("?");
	if (qparts.length == 0){return "";}
	var query = qparts[1];
	var vars = query.split("&amp;");
	var value = "";
	for (i=0; i<vars.length; i++)
	{
		var parts = vars[i].split("=");
		if (parts[0] == varname)
		{
			value = parts[1];
			break;
		}
	}
	value = unescape(value);
	value.replace(/\+/g," ");
	return value;
}
