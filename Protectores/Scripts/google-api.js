 function autoDetectLocation() {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (p) {
              
                var LatLng = new google.maps.LatLng('-34.6079406', '-58.3715494');
                var mapOptions = {
                    center: LatLng,
                    zoom: 13,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };
                var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
                var marker = new google.maps.Marker({
                    position: LatLng,
                    map: map,
                   
                });
                google.maps.event.addListener(marker, "click", function (e) {
                    var infoWindow = new google.maps.InfoWindow();
                    infoWindow.setContent(marker.title);
                    infoWindow.open(map, marker);
                });
            });
        } else {
            alert('Geo Location feature is not supported in this browser.');
        }
       
    }
    window.onload = autoDetectLocation;
    
    function GeoSucces() {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (p) {
                $("<p>" + p.coords.latitude + "</p>").appendTo('#lat');
                $("<p>" + p.coords.longitude + "</p>").appendTo('#lon');

                $.ajax({
                    url: '/Location/GetResult',
                    type: 'POST',
                    dataType: 'json',
                    data: {data: "{lat: " + p.coords.latitude + ", lon : " +  p.coords.longitude + "}"},
                    success: function () {
                        console.log('exito');
                    },
                    error: function () {
                        console.log('fracaso');
                    }
                });
            });
        }
    }
    window.onload = GeoSucces;
	
