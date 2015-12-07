    function GeoSucces() {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (p) {
                $("<p>" + p.coords.latitude + "</p>").appendTo('#lat');
                $("<p>" + p.coords.longitude + "</p>").appendTo('#lon');

                $.ajax({
                    url: '/Location/GetResult',
                    type: 'POST',
                    dataType: 'json',
                    data: {data: "{lat:" + p.coords.latitude + ", lon:" +  p.coords.longitude + "}"},
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
   
	
