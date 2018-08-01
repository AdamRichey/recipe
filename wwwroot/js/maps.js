var map;
function initMap() {
var myLatLng = {lat: 41.8781, lng: -87.6298}
    map = new google.maps.Map(document.getElementById('map'), {
        center: myLatLng,
        zoom: 8
    });
var marker = new google.maps.Marker({
    position: myLatLng,
    map: map,
    title: 'Hello World!'
  });
}