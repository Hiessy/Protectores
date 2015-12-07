function initialize() {
    var input = document.getElementById('pac-input');
    var autocomplete = new google.maps.places.Autocomplete(input);
﻿}
   window.onload = initialize;
   // google.maps.event.addListener(autocomplete, 'place_changed', function () {
     //   var place = autocomplete.getPlace();
       // document.getElementById('city2').value = place.name;
        //document.getElementById('cityLat').value = place.geometry.location.lat();
        //document.getElementById('cityLng').value = place.geometry.location.lng();
        //$("<p>" + place.geometry.location.lat() + "</p>").appendTo('#lat');
        //$("<p>" + place.geometry.location.lng() + "</p>").appendTo('#lon');
        //$.ajax({
          //  url: '/Location/GetResult',
        //    type: 'POST',
         //   dataType: 'json',
          //  data: { data: "{lat: " + place.geometry.location.lat() + ", lon : " + place.geometry.location.lng() + "}" },
        //    success: function () {
          //      console.log('exito');
        //    },
        //    error: function () {
         //       console.log('fracaso');
          //  }
    //    });
        //alert("This function is working!");
        //alert(place.name);
        // alert(place.address_components[0].long_name);

//    });
//}
//google.maps.event.addDomListener(window, 'load', initialize);
