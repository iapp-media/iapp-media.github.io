(function() {
  $(".join").click(function() {
    $('.register-mobile').slideToggle(300);
    return false;
  });
  $(".register-back").click(function() {
    $('.register-mobile').slideToggle(300);
    return false;
  });
  // $("#m-login").click(function() {
  //   $(".login-mobile").animate({
  //     height: 'toggle'
  //   }, 300);
  //   $(".theme").hide();
  // });
  //$(".login-back").click(function() {

    // hide();
  //});
  //$("#login").click(function() {
  //    $('#login-submit').click();
  //});
  //$("#register").click(function() {
  //  $('#register-submit').click();
  //});
})();

function validateEmail(sEmail) {
  var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
  if (filter.test(sEmail)) {
    return true;
  } else {
    return false;
  }
}

function checkLogin() {
  if ($('#email').val().length < 1) {
    $('#email').focus();
    return false;
  } else if ($('#password').val().length < 1) {
    $('#password').focus();
    return false;
  } else if (validateEmail($('#email').val())) {
      return true;
      //$('#BT_Login').click();
  }
  $('#email').focus();
  return false;
}

function checkRegister() {
  if ($('#name').val().length < 1) {
    $('#name').focus();
    return false;
  } else if ($('#register-email').val().length < 1) {
    $('#register-email').focus();
    return false;
  } else if ($('#register-password').val().length < 1) {
    $('#register-password').focus();
    return false;
  } else if (validateEmail($('#register-email').val())) {
    return true;
  }
  $('#register-email').focus();
  return false;
}
