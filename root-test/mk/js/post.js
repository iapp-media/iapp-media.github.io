Parse.initialize("QjdehMNJpHm3oPhLP5sB4W6RFU4nsWnXJGXaw5nO", "t733V304NxKk6xmdZKXLopqNOc2NKVnLLLWQioEj");
objectId = getValue("id");

var IObject = Parse.Object.extend("i");
var query = new Parse.Query(IObject);
query.equalTo("objectId",objectId);
query.find({
	success: function(results) {
		for (var i = 0; i < results.length; i++) { 
			var object = results[i];
			// console.log(document.getElementById('p2-text1').value);
			document.getElementById('p2-text1').innerText = object.get('t21');
			document.getElementById('p2-text2').innerText = object.get('t22');
			document.getElementById('p6-text1').innerText = object.get('t61');
			document.getElementById('p7-text1').innerText = object.get('t71');

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
				document.getElementById('p6').className=document.getElementById('p6').className.replace(/(?:^|\s)changestyle(?!\S)/g , '')
				// document.getElementById("p6").src=object.get('pic6').url();
				document.getElementById('p6').style.backgroundImage = 'url('+object.get('pic6').url()+')';

			}
		}
	},
	error: function(error) {
	}
});

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
function make(){
	window.location = 'maker.html';
}