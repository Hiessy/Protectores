function GeoSucces() {

    navigator.geolocation.getCurrentPosition(success, error, options);

    function success(position) {
        $('#LatitudId').val(position.coords.latitude);
        $('#LongitudId').val(position.coords.longitude);
    }

    function error() {
        console.log('error');
    }

    function options(position) {
    }
    setTimeout(function () {
        $('#CoordBtnId').click();
    }, 1500);
}

function Buscar() {
    var address = $('#pac-input').val();
    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'address': address }, function (results, status) {

        if (status == google.maps.GeocoderStatus.OK) {
            var lat = results[0].geometry.location.lat();
            var lng = results[0].geometry.location.lng();
        }

        if (address != "") {
            $('#LatitudId').val(lat);
            $('#LongitudId').val(lng);
        } else {
            $('#LatitudId').val('-34.6036844');
            $('#LongitudId').val('-58.3815591');
        }
        $('#CoordBtnId').click();
    });
}