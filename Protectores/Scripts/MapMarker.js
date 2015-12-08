var locations = [
     ['Alem 342', -34.6036817, -58.370339, 4],
     ['Rivadavia 345', -34.6079406, -58.3715494, 5],
     ['Valentin Gomez', -34.6046235, -58.4178874, 3],
     ['Viamonte 1500', -34.6007491, -58.3879922, 2],
     ['Esmeralda 138', -34.6065168, -58.3779686, 1]
];

function initMap(data) {
    var map = new google.maps.Map(document.getElementById('dvMap'), {
        zoom: 14,
        center: new google.maps.LatLng(-34.6110197, -58.3696347),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    var infowindow = new google.maps.InfoWindow();

    var marker, i;

    for (i = 0; i < data.length; i++) {
        marker = new google.maps.Marker({
            position: new google.maps.LatLng(data[i].Latitud, data[i].Longitud),
            map: map
        });

        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                infowindow.setContent('<div><strong>' + data[i].Usuario.Nombre + " " + data[i].Usuario.Apellido + '</strong><br>' +
                    data[i].StreetName + " " + data[i].AddressNumber + '<br>' + data[i].Telefono + '</div>');
                infowindow.open(map, marker);
            }
        })(marker, i));
    }
}
//var latitud=-34.6036817;
//var longitud = -58.370339;


//function initMap() {
//    var myLatLng = { lat: latitud, lng: longitud };

//    var map = new google.maps.Map(document.getElementById('dvMap'), {
//        zoom: 14,
//        center: myLatLng
//    });

//    var marker = new google.maps.Marker({
//        position: myLatLng,
//        map: map,

//    });
//}