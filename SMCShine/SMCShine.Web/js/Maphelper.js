
function GetMap(mapdiv, latlng, zoomsize) {            //在给定的mapdiv中创建一个map,并以latlng为中心,初始缩放程度为zoomsize,并返回该map对象
    var controloptions = {            //地图模式样式控制
        style: google.maps.MapTypeControlStyle.DROPDOWN_MENU,
        poistion: google.maps.ControlPosition.TOP_RIGHT,
        mapTypeIds: [google.maps.MapTypeId.ROADMAP,
                     google.maps.MapTypeId.TERRAIN,
                     google.maps.MapTypeId.HYBRID,
                     google.maps.MapTypeId.SATELLITE]
    }
    var myOptions =
             {
                 zoom: zoomsize,    //初始缩放程度
                 center: latlng,
                 mapTypeId: google.maps.MapTypeId.ROADMAP,
                 mapTypeControl: true,
                 mapTypeControlOptions: controloptions
             };
    return new google.maps.Map(mapdiv, myOptions);
}


function FindLocaiton(map, address) {            //解析地址,在地图上找到并标记
    geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            map.setCenter(results[0].geometry.location);
            var marker = new google.maps.Marker({
                map: map,
                position: results[0].geometry.location
            });
            if (results[0].formatted_address) {
                region = results[0].formatted_address + '<br />';
            }
            var infowindow = new google.maps.InfoWindow({
                content: '<div style =width:400px; height:400px;>Location info:<br/>Country Name:<br/>' + region + '<br/>LatLng:<br/>' + results[0].geometry.location + '</div>'
            });
            google.maps.event.addListener(marker, 'click', function () {
                infowindow.open(map, marker);
            });
        }
        else {
            alert("Google Map can't find the location!Are you sure the address is correct?");
        }
    });
}



function GetDistance(start, end) {       //地图上两个点google.map.Latlng的实际直线距离
    var EARTH_RADIUS = 6378.137;      //地球半径,单位KM
    function rad(d) {
        return d * Math.PI / 180.0;
    }
    var radLat1 = rad(start.lat());
    var radLat2 = rad(end.lat());
    var a = radLat1 - radLat2;
    var b = rad(start.lng()) - rad(end.lng());
    var s = 2 * Math.asin(Math.sqrt(Math.pow(Math.sin(a / 2), 2) + Math.cos(radLat1) * Math.cos(radLat2) * Math.pow(Math.sin(b / 2), 2)));
    s = s * EARTH_RADIUS;
    s = Math.round(s * 10000) / 10000;
    return s;
}


function getCurrentPostion(successfuntion, failedfuntion) {    //定位当前位置,成功执行successfuntion, 否则执行failedfuntion
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(successfuntion, failedfuntion);
    }
    else {
        failedfuntion();
        return;
    }
}



function addPath(map, coordinates, color, opacity, weight) {    //描述路线,map:地图;coordinates:路线中的点集;color:线条颜色;opacity:线条透明度;weight:线条粗细
    var path = new google.maps.Polyline({
        path: coordinates,          //路径点集
        strokeColor: color,     //线条颜色
        strokeOpacity: opacity,         //透明度
        strokeWeight: weight             //线条宽度
    });
    path.setMap(map);
}



function getAddress(location, showFunction) {          //获取指定google.maps.Latlng的地址解析,并用调用showFunction函数显示(showFunction函数必须包含一个用于传入解析后地址的参数)
    var geocoder = new google.maps.Geocoder();
    if (geocoder) {
        geocoder.geocode({ 'location': location }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                showFunction(results[0].formatted_address);
            }
            else {
                showFunction("未知的区域!");
            }
        });
    }
}

//添加marker到数组markersArray
function addMarker(location, markersArray, map) {
    marker = new google.maps.Marker({
        position: location,
        map: map
    });
    markersArray.push(marker);
}

// 将指定数组中全部marker从地图先移出
function clearMarkers(markersArray) {
    if (markersArray) {
        for (var i = 0; i < markersArray.length; i++) {
            markersArray[i].setMap(null);
        }
    }
}

//从地图移除指定数组中全部marker，并从数组中将其删除
function deleteMarkers(markersArray) {
    if (markersArray) {
        for (var i = 0; i < markersArray.length; i++) {
            markersArray[i].setMap(null);
        }
        markersArray.length = 0;
    }
}

//在地图上显示指定数组中全部marker,并以seconds间隔先后出现
function showMarkers(markersArray, map, seconds) {
    if (markersArray) {
        if (seconds) {
            for (var i = 0; i < markersArray.length; i++) {
                window.setTimeout(showSingleMarker, i * seconds, markersArray[i], map);
            }
        }
        else {
            for (var i = 0; i < markersArray.length; i++) {
                markersArray[i].setMap(map);
            }
        }
    }
}

//显示指定数组中marker的终点和起点
function showEndPoint(markersArray, map) {
    for (var i = 0; i < markersArray.length; i++) {
        if (i == 0 || i == markersArray.length - 1) {
            markersArray[i].setAnimation(google.maps.Animation.DROP);
            markersArray[i].setMap(map);
        }
        else
            markersArray[i].setMap(null);
    }
}

//在指定地图上显示指定marker
function showSingleMarker(marker, map, animation) {
    marker.setAnimation(animation);
    marker.setMap(map);
}

function clearSingleMarker(marker) {
    marker.setMap(null);
}

//使用指定marker数组产生一条polyline
function getPolyline(markersArray, opacity, weight, color, zindex) {
    var tmp = [];
    if (markersArray) {
        for (var i = 0; i < markersArray.length; i++) {
            tmp.push(markersArray[i].getPosition());
        }
    }
    var line = new google.maps.Polyline({
        path: tmp,
        strokeColor: color,
        strokeOpacity: opacity,
        strokeWeight: weight,
        zIndex: zindex
    });
    return line;
}

//向指定poltline添加点
function addPointToPolyLine(polyline, latLng) {
    if (polyline) {
        var path = polyline.getPath();
        path.push(latLng);
    }
}

//在指定map中显示polyline
function showPolyline(polyline, map) {
    polyline.setMap(map);
}

//清除polyline在地图中的显示
function clearPolyline(polyline) {
    polyline.setMap(null);
}

//重载定时函数，使其可以带参数
var _st = window.setTimeout;
window.setTimeout = function (fRef, mDelay) {
    if (typeof fRef == 'function') {
        var argu1 = Array.prototype.slice.call(arguments, 2);
        var f = function () {
            fRef.apply(null, argu1);
        };
        return _st(f, mDelay);
    }
    return _st(fRef, mDelay);
}