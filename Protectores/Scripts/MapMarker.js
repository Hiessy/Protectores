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