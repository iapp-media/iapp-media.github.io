 // Google Map
var myCenter;
 myCenter = document.getElementById("ContentPlaceHolder1_L_place").innerHTML;

 // console.log(getValue("loc"));
 if (getValue("loc")) {
     myCenter = getValue("loc");
 }
 console.log(myCenter);
 var map = $('#map');
 map.tinyMap({
     'zoom': 16,
     'center': myCenter,
     'marker': [{
         // Custom Identity string (Optional)
         'id': myCenter,
         // Marker place location
         'addr': myCenter,
         // Or address string. e.g. `1600 Pennsylvania Ave NW, Washington, DC 20500`
         // Or Object {lat: 'lat', lng: 'lng'}
         // Or latlng string 'lat, lng'
         // 'title': 'Display on Mouseover', // (Optional)
         // 'text': 'Display in infoWindow', // (Optional)
         // 'icon': 'http://domain/icon.png', // (Optional)
         // You could define own properties by yourself.
         // 'hello': 'yes',
         // Binding Click event
         // 'event': function () {
         //     console.log(this.text); // Get marker's text property.
         //     console.log(event.latLng.lat()); // Get markers' position.
         //     // Access own property
         //     //console.log(this.hello);
         // }
         /* More events
         'event': {
             'click': function (event) {...},
             'mouseover': function (event) {...}
         }
         */
         /* or Run Once
         'event': {
             'click': {
                 'func': function () {...}
                 'once': true / false
             },
             'mouseover': {
                 ...
             }
         }
         */
     }],
     // 'autoLocation': function(loc) {
     //     console.log(loc);
     //     if ('coords' in loc) {
     //         // var des = taipei101;
     //         var from = [loc.coords.latitude, loc.coords.longitude];
     //         map.tinyMap('modify', {
     //             'direction': [{
     //                 'from': from,
     //                 'to': myCenter
     //             }]
     //         });
     //     }
     // }
 });

 // 抓中文參數
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
     value = decodeURI(value);
     value.replace(/\+/g, " ");
     return value;
 };
