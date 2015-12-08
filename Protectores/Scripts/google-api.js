function GeoSucces() {
    if (navigator.geolocation) {
        var pos;
        navigator.geolocation.getCurrentPosition(function (position) {
            pos = {lat: position.coords.latitude,lng: position.coords.longitude}
        }, function() {}, {timeout:5000});

        if (pos != null){
            $('#LatitudId').val(pos['lat']);
            $('#LongitudId').val(pos['lng']);
        } else {
            $('#LatitudId').val('-34.6036844');
            $('#LongitudId').val('-58.3815591');
            $('#TelefonoId').val('test');
        }

     $('#CoordBtnId').click();

        // Hardcodeamos dos valores por restricciones de google-api

    }
}





   
	
