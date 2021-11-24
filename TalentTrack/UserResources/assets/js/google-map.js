var stationList = [
  {"latlng":[35.681382,139.766084],name:"Tokyo Station",pin: "assets/img/map-pin.png"},
  {"latlng":[35.630152,139.74044],name:"Shinagawa Station",pin: "assets/img/map-pin.png"},
  {"latlng":[35.507456,139.617585],name:"Shin-Yokohama Station",pin: "assets/img/map-pin.png"},
  {"latlng":[35.25642,139.154904],name:"Odawara Station",pin: "assets/img/map-pin.png"},
  {"latlng":[35.103217,139.07776],name:"Atami Station",pin: "assets/img/map-pin.png"},
  {"latlng":[35.127152,138.910627],name:"Mishima Station",pin: "assets/img/map-pin.png"},
  {"latlng":[35.142015,138.663382],name:"Shin-Fuji Station",pin: "assets/img/map-pin.png"},
  {"latlng":[34.97171,138.38884],name:"Shizuoka Station",pin: "assets/img/map-pin.png"},
  {"latlng":[34.769758,138.014928],name:"Kakegawa Station",pin: "assets/img/map-pin.png"},
  {"latlng":[34.703741,137.734442],name:"Hamamatsu Station",pin: "assets/img/map-pin.png"},
  {"latlng":[34.762811,137.381651],name:"Toyohashi Station",pin: "assets/img/map-pin.png"},
  {"latlng":[34.96897,137.060662],name:"Mikawa-Anjyo Station",pin: "assets/img/map-pin.png"},
  {"latlng":[35.170694,136.881637],name:"Nagoya Station",pin: "assets/img/map-pin.png"},
  {"latlng":[35.315705,136.685593],name:"Gifu-Hashima Station",pin: "assets/img/map-pin.png"},
  {"latlng":[35.314188,136.290488],name:"Yonehara Station",pin: "assets/img/map-pin.png"},
  {"latlng":[34.985458,135.757755],name:"Kyoto Station",pin: "assets/img/map-pin.png"},
  {"latlng":[34.73348,135.500109],name:"Shin-Osaka Station",pin: "assets/img/map-pin.png"}
];
var infoWnd, mapCanvas;
function initialize() {
  //Creates a map object.
  var mapDiv = document.getElementById("map_canvas");
  mapCanvas = new google.maps.Map(mapDiv);
  mapCanvas.setMapTypeId(google.maps.MapTypeId.ROADMAP);
  
  //Creates a infowindow object.
  infoWnd = new google.maps.InfoWindow();
  
  //Mapping markers on the map
  var bounds = new google.maps.LatLngBounds();
  var station, i, latlng;
  for (i in stationList) {
    //Creates a marker
    station = stationList[i];
    latlng = new google.maps.LatLng(station.latlng[0], station.latlng[1]);
    bounds.extend(latlng);
    var marker = createMarker(
      mapCanvas, latlng, station.name,station.pin
    );
    
  }
  //Fits the map bounds
  mapCanvas.fitBounds(bounds);
}
function createMarker(map, latlng, title,pin) {
  //Creates a marker
  
    var image = {
        url: pin,
        size: new google.maps.Size(60, 68),
        origin: new google.maps.Point(0, 0),
        anchor: new google.maps.Point(0, 68)
    };
  var marker = new google.maps.Marker({
		position : latlng,
		map : map,
		icon : image,
		title : title
  });
  
  //The infoWindow is opened when the sidebar button is clicked
  google.maps.event.addListener(marker, "click", function(){
    infoWnd.setContent("<strong>" + title + "</title>");
    infoWnd.open(map, marker);
  });
  return marker;
}
google.maps.event.addDomListener(window, "load", initialize);