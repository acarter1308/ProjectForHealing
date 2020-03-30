 geocoder = new google.maps.Geocoder();

window.getCoordinates = function (address, callback) {
    var coordinates;
    geocoder.geocode({ address: address }, function (results, status) {
     coordinates = results[0].geometry.location;
    callback(coordinates);

})
  }