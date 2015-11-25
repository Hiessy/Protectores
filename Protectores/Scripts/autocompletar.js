function initMap() {
    var input = document.getElementById('pac-input');
    var autocomplete = new google.maps.places.Autocomplete(input);
    autocomplete.addListener('place_changed', function () {
        infowindow.close();
        var place = autocomplete.getPlace();
        var address = '';
        if (place.address_components) {
            address = [
(place.address_components[0] && place.address_components[0].short_name || ''),
(place.address_components[1] && place.address_components[1].short_name || ''),
(place.address_components[2] && place.address_components[2].short_name || '')
            ].join(' ');
        }
        infowindow.setContent('<div><strong>' + place.name + '</strong><br>' + address);
    });
}