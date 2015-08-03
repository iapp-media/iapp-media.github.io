function getValue(varname) {
  var url = window.location.href;
  var qparts = url.split("?");
  if (qparts.length == 0) {
    return "";
  }
  var query = qparts[1];
  var vars = query.split("&");
  var value = "";
  for (i = 0; i < vars.length; i++) {
    var parts = vars[i].split("=");
    if (parts[0] == varname) {
      value = parts[1];
      break;
    }
  }
  value = unescape(value);
  value.replace(/\+/g, " ");
  return value;
}


function setCurrent(number, w, h) {
  document.getElementById('CurrentId').setAttribute('value', number);
  var me = 'mobileEditor.html?i=' + getValue('i') + '&c=' + number + '&w=' + w + '&h=' + h;
  console.log(me);
  $('#editFrame').attr('src', me);
  $(".pages").hide();
  $('.imageEditor').show();
}
function preview() {
  // body...
}

function send () {
  // body...
}

$(function() {
  $('.cancel').click(function() {
    $('.imageEditor').hide();
    $(".pages").show();
  });
});
