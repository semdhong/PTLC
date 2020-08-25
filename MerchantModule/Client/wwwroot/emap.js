
function AutoCompleteAddressOrigin() {
    var originInput = document.getElementById('origin-input');
  

    var originAutocomplete = new google.maps.places.Autocomplete(originInput);
    originAutocomplete.addListener('place_changed', function () {
        var place = originAutocomplete.getPlace();
        var long = document.getElementById('originlong');
        long.value = place.geometry.location.lng();

        var lat = document.getElementById('originlat');
        lat.value = place.geometry.location.lat();

        var name = document.getElementById('originname');
        name.value = place.name;
        var address = document.getElementById('originaddress');
        address.value= place.formatted_address;
 
        long.dispatchEvent(new Event('change')); 
        lat.dispatchEvent(new Event('change')); 
        name.dispatchEvent(new Event('change'));
        address.dispatchEvent(new Event('change')); 
        
    });
}

function AutoCompleteAddressDest() {
  
    var destinationInput = document.getElementById('destination-input');

    var destinationAutocomplete =
        new google.maps.places.Autocomplete(destinationInput);
    destinationAutocomplete.addListener('place_changed', function () {
        var place = destinationAutocomplete.getPlace();
        var long = document.getElementById('destlong');
        long.value = place.geometry.location.lng();

        var lat = document.getElementById('destlat');
        lat.value = place.geometry.location.lat();

        var name = document.getElementById('destname');
        name.value = place.name;
        var address = document.getElementById('destaddress');
        address.value = place.formatted_address;

        long.dispatchEvent(new Event('change'));
        lat.dispatchEvent(new Event('change'));
        name.dispatchEvent(new Event('change'));
        address.dispatchEvent(new Event('change')); 
       
    });
}
function initMap() {
    var map = new google.maps.Map(document.getElementById('map'), {
        mapTypeControl: true,
        center: { lat: 10.3157, lng: 123.8854 },
        zoom: 15,
    });
    document.getElementById("selectcarbar").style.visibility = "hidden";

    const geocoder = new google.maps.Geocoder();
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var geolocation = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };

            map.setCenter(geolocation);
            geocoder.geocode(
                {
                    location: geolocation
                },
                (results, status) => {
                    if (status === "OK") {
                        if (results[0]) {
                            map.setZoom(15);
                            marker = new google.maps.Marker({
                                position: geolocation,
                                map: map
                            });

                            marker.setMap(map);

                            document.getElementById('origin-input').value = results[0];
                            new AutocompleteDirectionsHandler(map);
                        } else {
                            window.alert("No results found");
                        }
                    } else {
                        window.alert("Geocoder failed due to: " + status);
                    }
                }
            );
        });
    }
   
}

function computeTotalDistance(result) {
    let total = 0;
    const myroute = result.routes[0];

    for (let i = 0; i < myroute.legs.length; i++) {
        total += myroute.legs[i].distance.value;
    }
    total = total / 1000;
    document.getElementById("total").value = total;
    if (total !== null)
        document.getElementById("selectcarbar").style.visibility = "visible";
}


function AutocompleteDirectionsHandler(map) {
    this.map = map;
    this.originPlaceId = null;
    this.destinationPlaceId = null;
    this.travelMode = 'DRIVING';
    this.directionsService = new google.maps.DirectionsService;
    this.directionsRenderer = new google.maps.DirectionsRenderer({
        draggable: true,
        map,
        //panel: document.getElementById("right-panel")
    });

    this.directionsRenderer.setMap(map);
    this.directionsRenderer.addListener("directions_changed", () => {
        computeTotalDistance(this.directionsRenderer.getDirections());
    });
    var originInput = document.getElementById('origin-input');
    var destinationInput = document.getElementById('destination-input');
    //var modeSelector = document.getElementById('mode-selector');

    var originAutocomplete = new google.maps.places.Autocomplete(originInput);
    // Specify just the place data fields that you need.
    originAutocomplete.setFields(['place_id']);

    var destinationAutocomplete =
        new google.maps.places.Autocomplete(destinationInput);
    // Specify just the place data fields that you need.
    destinationAutocomplete.setFields(['place_id']);

    //this.setupClickListener('changemode-walking', 'WALKING');
    //this.setupClickListener('changemode-transit', 'TRANSIT');
    //this.setupClickListener('changemode-driving', 'DRIVING');

    this.setupPlaceChangedListener(originAutocomplete, 'ORIG');
    this.setupPlaceChangedListener(destinationAutocomplete, 'DEST');

    //this.map.controls[google.maps.ControlPosition.TOP_LEFT].push(originInput);
    //this.map.controls[google.maps.ControlPosition.TOP_LEFT].push(
    //    destinationInput);
    //this.map.controls[google.maps.ControlPosition.TOP_LEFT].push(modeSelector);

}

// Sets a listener on a radio button to change the filter type on Places
// Autocomplete.
//AutocompleteDirectionsHandler.prototype.setupClickListener = function (
//    id, mode) {
//    var radioButton = document.getElementById(id);
//    var me = this;

//    radioButton.addEventListener('click', function () {
//        me.travelMode = mode;
//        me.route();
//    });
//};

AutocompleteDirectionsHandler.prototype.setupPlaceChangedListener = function (
    autocomplete, mode) {
    var me = this;
    autocomplete.bindTo('bounds', this.map);
   
    autocomplete.addListener('place_changed', function () {
        var place = autocomplete.getPlace();
      
        if (!place.place_id) {
            window.alert('Please select an option from the dropdown list.');
            return;
        }
        if (mode === 'ORIG') {
            console.log(place.place_id);
            me.originPlaceId = place.place_id;
            document.getElementById('origin-input').innerHTML = place.name;
        } else {
            me.destinationPlaceId = place.place_id;
            document.getElementById('destination-input').innerHTML = place.name;
        }
        me.route();
    });
};

AutocompleteDirectionsHandler.prototype.route = function () {
    if (!this.originPlaceId || !this.destinationPlaceId) {
        return;
    }
    var me = this;

    this.directionsService.route(
        {
            origin: { 'placeId': this.originPlaceId },
            destination: { 'placeId': this.destinationPlaceId },
            travelMode: this.travelMode
        },
        function (response, status) {
            if (status === 'OK') {
                me.directionsRenderer.setDirections(response);
            } else {
                window.alert('Directions request failed due to ' + status);
            }
        });
};