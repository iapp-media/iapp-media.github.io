'use strict';
//Parse.initialize("QjdehMNJpHm3oPhLP5sB4W6RFU4nsWnXJGXaw5nO", "t733V304NxKk6xmdZKXLopqNOc2NKVnLLLWQioEj");
Parse.initialize("LD5YXs0MuB68HbSzl6QW0RMXKfHlYRNgGx1zi7y8", "lJrNywD6Nwg385fbD2iZXYMu28qMneb75UkYVVJB");
// ***
// ---給protoal(index)的check_user---
// ***

// ---判斷是否有user登入---
(function() {
  // FB.api('/me?fields=picture', function(response) {
  //   var userPicture = response.picture.data.url;
  // });
  // window.location = userPicture;
  // var currentUser = Parse.User.current();
  // if(currentUser) {
  //   $('.circle-login').attr("src", userPicture);
  // } else {}

})

checkUserIndex();

function checkUserIndex() {
	var currentUser = Parse.User.current();
	if(currentUser) {
		$('#m-login').hide();
		$('#user-login').show();
		$('.circle-login').show();
		// $('.circle-login').attr("src", "img/default.jpg");
	}
}

function checkUserMaker() {
	var currentUser = Parse.User.current();
	if(!currentUser) {
		alert("請先登入！");
		window.location = 'login/m-login/m-login.html';
		return null;
	}
}