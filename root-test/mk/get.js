
Parse.initialize("QjdehMNJpHm3oPhLP5sB4W6RFU4nsWnXJGXaw5nO", "t733V304NxKk6xmdZKXLopqNOc2NKVnLLLWQioEj");
objectId = getValue("id")

var IObject = Parse.Object.extend("i");
var query = new Parse.Query(IObject);
query.equalTo("objectId",objectId);
query.find({
	success: function(results) {
		for (var i = 0; i < results.length; i++) { 
			var object = results[i];
			var picObj0=document.getElementById("pic-select0");
			picObj0.src=object.get('pic1').url();
			var picObj1=document.getElementById("pic-select1");
			picObj1.src=object.get('pic2').url();
			var picObj2=document.getElementById("pic-select2");
			picObj2.src=object.get('pic31').url();
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
