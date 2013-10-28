var map;
var routeMarkerManager = [];   //记录线路marker
var routePolylineManager = []; //记录线路连线
var routeIDManager = [];    //记录线路ID
var patrolMarkerManager = [];  //记录巡检marker
var patrolPolylineManager = [];  //记录巡检连线
var patrolIDManager = [];             //记录巡检计划ID，次序
var infowindow;                         //标记弹出框
var onlineMarkerManager = [];         //在线用户标记
var currentRoute = [];                    //table中显示的当前线路ID
var startimage = "../images/start.gif";
var endimage = "../images/end.gif";
var wayimage = "../images/icon.gif";
var travelimage = "../images/travel.gif";
var onlineimage = "../images/333.gif";
var notimportantimage = "../images/notimportant.gif";
var noimage = "D:/";
var patroltimer;         //动态显示巡检轨迹所用interval，用于清理
var currentPatrolID;     //当前显示的巡检轨迹ID
var currentPolyline = getPolyline([], 1.0, 5, "green", 1); //用于动态显示巡检轨迹


function initialize() {
    var center = new google.maps.LatLng(29.046552, 111.692853);
    map = GetMap(document.getElementById("map"), center, 12);
    currentPolyline.setMap(map);
}

function getMarker(position, title, image, map) {     //创建标记,map:地图;title:标记文字;position:标记位置;image:标记图片
    return new google.maps.Marker({
        map: map,
        title: title,
        icon: image,
        position: position
    });
}

function getRouteDataSuccess(xmlhttp) {
    var doc = xmlhttp.responseXML;           //有关该xml格式，请参见Admin/xml/RouteDataFormat.xml,如对格式进行修改，请同时修改该xml文件
    var routes = doc.getElementsByTagName("route");
    for (var i = 0; i < routes.length; i++) {
        //判断是否已存在该线路数据,已存在则跳过
        var routeid = routes[i].getAttribute("routeid");
        var exist = false;
        for (var k = 0; k < routeIDManager.length; k++) {
            if (routeIDManager[k] == routeid) {
                exist = true;
                break;
            }
        }
        if (exist)
            continue;

        var routeinfos = routes[i].getElementsByTagName("routeinfo");
        if (routeinfos.length <= 0)
            continue;

        //创建marker数组
        var markersArray = [];
        for (var j = 0; j < routeinfos.length; j++) {
            var image = "";
            if (j == 0)
                image = startimage;
            else if (j == routeinfos.length - 1)
                image = endimage;
            else if (!routeinfos[j].getAttribute("title"))
                image = notimportantimage;
            else
                image = wayimage;
            var latlng = new google.maps.LatLng(routeinfos[j].getAttribute("lat"), routeinfos[j].getAttribute("lon"));
            var title = routeinfos[j].getAttribute("title") + "\n" + routeinfos[j].getAttribute("description");
            var marker = getMarker(latlng, title, image);
            marker.setMap(map);
            markersArray.push(marker);
        }

        //创建marker间连线
        var line = getPolyline(markersArray, 1.0, 8, "red");

        routeMarkerManager.push(markersArray);
        routePolylineManager.push(line);
        routeIDManager.push(routeid);
    }
}
function getPatrolDataSuccess(xmlhttp) {
    var doc = xmlhttp.responseXML;           //有关该xml格式，请参见Admin/xml/PatrolDataFormat.xml,如对格式进行修改，请同时修改该xml文件
    var patrols = doc.getElementsByTagName("patrol");
    for (var i = 0; i < patrols.length; i++) {
        var patrolinfos = patrols[i].getElementsByTagName("patrolinfo");
        if (patrolinfos.length <= 0)
            continue;
        var markersArray = [];
        for (var j = 0; j < patrolinfos.length; j++) {
            var image = "";
            var photo = patrolinfos[j].getAttribute("photo");
            if (j == 0)
                image = startimage;
            else if (j == patrolinfos.length - 1)
                image = endimage;
            else if (photo) {
                var icon = {
                    origin: new google.maps.Point(0, 0),
                    scaledSize: new google.maps.Size(50, 50),        //缩略图
                    url: photo.replace("~", "..")
                };
                image = icon;
            }
            else
                image = wayimage;
            var latlng = new google.maps.LatLng(patrolinfos[j].getAttribute("lat"), patrolinfos[j].getAttribute("lon"));
            var title = patrolinfos[j].getAttribute("locatetime") + "\n巡检员:" + patrolinfos[j].getAttribute("staffname") + "\n中继段:" + patrols[i].getAttribute("routename") + "\n备注:" + patrolinfos[j].getAttribute("remark");
            var marker = getMarker(latlng, title, image);
            var src = "PatrolRemark.aspx?id=" + patrolinfos[j].getAttribute("id");
            (function (m, src) {
                new google.maps.event.addListener(m, "click", function (event) {
                    if (!infowindow) {
                        infowindow = new google.maps.InfoWindow();
                    }
                    infowindow.setContent("<iframe src='" + src + "' scrolling='no'  frameborder='0' width='260px' height='150px'></iframe>");
                    infowindow.open(map, m);
                });
            })(marker, src);
            if (photo) {
                (function (m, p) {
                    new google.maps.event.addListener(m, "click", function (event) {
                        if (!infowindow) {
                            infowindow = new google.maps.InfoWindow();
                        }
                        p = p.replace("~", "..");
                        infowindow.setContent("<img src='" + p + "' alt='图片' />");
                        infowindow.open(map, m);
                    });
                })(marker, photo);
            }
            markersArray.push(marker);
        }
        var line = getPolyline(markersArray, 1.0, 5, "green", 1);
        //var linetitle = patrols[i].getAttribute("title") + "<br />" + patrols[i].getAttribute("description");
        var planinfoid = patrols[i].getAttribute("planinfoid");
        patrolMarkerManager.push(markersArray);
        patrolPolylineManager.push(line);
        patrolIDManager.push(patrols[i].getAttribute("planinfoid"));
    }
}
function getDataFailed() {
    alert("无法连接到服务器,获取数据失败!");
}

function showRoute(routeid) {
    for (var i = 0; i < routeIDManager.length; i++) {
        if (routeIDManager[i] == routeid) {
            showEndPoint(routeMarkerManager[i], map);
            showPolyline(routePolylineManager[i], map);
            showRouteInfoInTable(routeMarkerManager[i]);
        }
        else {
            clearMarkers(routeMarkerManager[i]);
            clearPolyline(routePolylineManager[i]);
        }
    }
}

function showPatrolWithTime(planinfoid, interval) {
    if (!interval) {
        interval = 0;
    }
    for (var i = 0; i < patrolIDManager.length; i++) {
        if (patrolIDManager[i] == planinfoid) {
            var curtime;
            for (var k = 0; k < patrolMarkerManager[i].length; k++) {
                var time = patrolMarkerManager[i][k].getTitle().split("\n")[0];
                if (k > 0 && k < patrolMarkerManager[i].length - 1) {
                    if (difftime(curtime, time) >= interval) {
                        curtime = time;
                        showSingleMarker(patrolMarkerManager[i][k], map);
                    }
                    else {
                        clearSingleMarker(patrolMarkerManager[i][k]);
                    }
                }
                else {
                    if (k == 0) {
                        curtime = time;
                    }
                    showSingleMarker(patrolMarkerManager[i][k], map);
                }
            }
            showPolyline(patrolPolylineManager[i], map);
        }
        else {
            clearMarkers(patrolMarkerManager[i]);
            clearPolyline(patrolPolylineManager[i]);
        }
    }
}

//显示光缆线路信息，无数据则请求数据
function showRouteWithJudge(routeid) {
    var exist = false;
    for (var i = 0; i < routeIDManager.length; i++) {
        if (routeIDManager[i] == routeid) {
            exist = true;
            break;
        }
    }
    if (exist) {
        showRoute(routeid);
    }
    else {
        var url = "MapDataHandler.ashx?routeid=" + routeid;
        sendHttpRequest(url, function (xmlhttp) {
            getRouteDataSuccess(xmlhttp);
            showRoute(routeid);
        }, getDataFailed, "get");
    }
}

function showPatrol(planinfoid) {                //静态显示巡检轨迹，包括图标和轨迹
    for (var i = 0; i < patrolIDManager.length; i++) {
        if (patrolIDManager[i] == planinfoid) {
            showMarkers(patrolMarkerManager[i], map);
            showPolyline(patrolPolylineManager[i], map);
        }
        else {
            clearMarkers(patrolMarkerManager[i]);
            clearPolyline(patrolPolylineManager[i]);
            clearPolyline(currentPolyline);
        }
    }
}

function showPatrolWithoutMarker(planinfoid) {                //静态显示巡检轨迹，只显示起止图标
    for (var i = 0; i < patrolIDManager.length; i++) {
        if (patrolIDManager[i] == planinfoid) {
            currentPatrolID = patrolIDManager[i];
            showEndPoint(patrolMarkerManager[i], map);
            showPolyline(patrolPolylineManager[i], map);
        }
        else {
            clearMarkers(patrolMarkerManager[i]);
            clearPolyline(patrolPolylineManager[i]);
            clearPolyline(currentPolyline);
        }
    }
}

function showPatrolStepByStep(planinfoid) {                   //动态显示巡检轨迹，只显示起止图标
    for (var i = 0; i < patrolIDManager.length; i++) {
        clearMarkers(patrolMarkerManager[i]);
        clearPolyline(patrolPolylineManager[i]);
        if (patrolIDManager[i] == planinfoid) {
            currentPatrolID = patrolIDManager[i];
            window.patrolorder = 0;
            window.clearTimeout(patroltimer);
            currentPolyline.getPath().clear();
            currentPolyline.setMap(map);
            showPolylineInterval(patrolPolylineManager[i]);
        }
    }
}

function showPolylineInterval(polyline) {                     //动态显示轨迹
    if (!window.patrolorder && window.patrolorder != 0) {
        window.patrolorder = 0;
    }
    if (window.patrolorder == 0) {   //显示起点
        for (var i = 0; i < patrolIDManager.length; i++)
            if (currentPatrolID == patrolIDManager[i]) {
                showSingleMarker(patrolMarkerManager[i][0], map);
                break;
            }
    }
    var path = polyline.getPath();
    if (window.patrolorder < path.getLength()) {
        if (window.patrolorder == path.getLength() - 1) {
            for (var i = 0; i < patrolIDManager.length; i++)
                if (currentPatrolID == patrolIDManager[i]) {
                    showSingleMarker(patrolMarkerManager[i][path.getLength() - 1], map);
                    var cbshowphoto = document.getElementById("cbshowphoto");
                    showPhotoChanged(cbshowphoto);
                    break;
                }
        }
        addPointToPolyLine(currentPolyline, path.getAt(window.patrolorder));
        window.patrolorder++;
        patroltimer = window.setTimeout(showPolylineInterval, 10, polyline);
    }
    else {

    }
}

//显示巡检轨迹,如果无数据先请求数据
function showPatrolWithJudge(planinfoid) {
    var exist = false;
    for (var i = 0; i < patrolIDManager.length; i++) {
        if (patrolIDManager[i] == planinfoid) {
            exist = true;
            break;
        }
    }
    if (exist) {
        var dynamic = document.getElementById("cbshowdynamic");
        if (dynamic.checked) {
            showPatrolStepByStep(planinfoid);
        }
        else {
            showPatrolWithoutMarker(planinfoid);
        }
    }
    else {
        var url = "MapDataHandler.ashx?planinfoid=" + planinfoid;
        sendHttpRequest(url, function (xmlhttp) {
            getPatrolDataSuccess(xmlhttp);
            var dynamic = document.getElementById("cbshowdynamic");
            if (dynamic.checked) {
                showPatrolStepByStep(planinfoid);
            }
            else {
                showPatrolWithoutMarker(planinfoid);
            }
        }, getDataFailed, "get");
    }
}

function showCurrentPatrol() {
    currentPolyline.setMap(map);
    if (currentPatrolID) {
        showPatrolWithJudge(currentPatrolID);
    }
}

function showAllRoute() {
    if (!document.allDataGetted) {
        var url = "MapDataHandler.ashx?routeid=*";
        sendHttpRequest(url, function (xmlhttp) {
            getRouteDataSuccess(xmlhttp);
            document.allDataGetted = true;
            for (var i = 0; i < routePolylineManager.length; i++) {
                showPolyline(routePolylineManager[i], map);
            }
            clearRouteMarker();
        }, getDataFailed, "get");
        return;
    }
    else {
        for (var i = 0; i < routePolylineManager.length; i++) {
            showPolyline(routePolylineManager[i], map);
        }
    }
    clearRouteMarker();
}

function clearRouteMarker() {
    for (var i = 0; i < routeMarkerManager.length; i++) {
        clearMarkers(routeMarkerManager[i]);
    }
}
function clearPatrolMarker() {
    for (var i = 0; i < patrolMarkerManager.length; i++) {
        clearMarkers(patrolMarkerManager[i]);
    }
}
function clearRoutePolyline() {
    for (var i = 0; i < routePolylineManager.length; i++) {
        clearPolyline(routePolylineManager[i]);
    }
}
function clearPatrolPolyline() {
    for (var i = 0; i < patrolPolylineManager.length; i++) {
        clearPolyline(patrolPolylineManager[i]);
    }
}

function clearAllRoute() {
    clearRouteMarker();
    clearRoutePolyline();
}

function clearAllPatrol() {
    clearPatrolMarker();
    clearPatrolPolyline();
    clearPolyline(currentPolyline);
}

function addRouteInfoRow(title, lat, lon) {
    var table1 = $('#routeinfo');
    var row = $("<tr class='infotr' onclick='showSingleRouteInfo(this)' style='cursor:pointer' onmouseover='defaultcolor=this.style.backgroundColor;this.style.backgroundColor=\"#D9FFFF\"' onmouseout='this.style.backgroundColor=defaultcolor'></tr>");
    row.append($("<td>" + title + "</td>"));
    row.append($("<td>" + lat + "</td>"));
    row.append($("<td>" + lon + "</td>"));
    table1.append(row);
}

function showSingleRouteInfo(tr) {            //显示单个站点的位置
    var markertitle = $(tr).find("td").eq(0).text();    //获取这一行的第一列的值，即站点名
    var markerlat = $(tr).find("td").eq(1).text();
    var markerlon = $(tr).find("td").eq(2).text();
    for (var i = 0; i < routeMarkerManager.length; i++) {
        if (currentRoute != routeMarkerManager[i])
            continue;
        for (var j = 0; j < routeMarkerManager[i].length; j++) {
            if (routeMarkerManager[i][j].getPosition().lat().toFixed(5) == markerlat && routeMarkerManager[i][j].getPosition().lng().toFixed(5) == markerlon) {
                //如果找到，则显示该线路上该点的位置，其它除起终点外隐藏
                for (var m = 0; m < routeMarkerManager[i].length; m++) {
                    if (m > 0 && m < routeMarkerManager[i].length - 1) {
                        clearSingleMarker(routeMarkerManager[i][m]);
                    }
                    else {
                        showSingleMarker(routeMarkerManager[i][m], map);
                    }
                }
                showPolyline(routePolylineManager[i], map);
                showSingleMarker(routeMarkerManager[i][j], map, google.maps.Animation.BOUNCE);
                return;
            }
        }
    }
}

function showPhotoes(markerArray) {
    for (var i = 0; i < markerArray.length; i++) {
        if (markerArray[i].getIcon().url) {
            showSingleMarker(markerArray[i], map);
        }
    }
}

function removePhotoes(markerArray) {
    for (var i = 0; i < markerArray.length; i++) {
        if (markerArray[i].getIcon().url) {
            clearSingleMarker(markerArray[i], map);
        }
    }
}

function showRouteInfoInTable(markerArray) {
    removeRouteInfoRow();
    currentRoute = markerArray;
    for (var i = 0; i < markerArray.length; i++) {
        addRouteInfoRow(markerArray[i].getTitle(), markerArray[i].getPosition().lat().toFixed(5), markerArray[i].getPosition().lng().toFixed(5));
    }
}
function removeRouteInfoRow() {
    $("#routeinfo .infotr").each(function () { $(this).remove(); });
}
function changeRowColor(tableid, rowindex) {
    $(tableid).find("tr").each(function (key, val) {
        if (key > 0 && key == rowindex + 1) {
            $(this).addClass("selettedrow");
        }
        else
            $(this).removeClass("selettedrow");
    });
}

function showOnclineUser(lat, lon, name) {
    clearOnlineUser();
    var p = new google.maps.LatLng(lat, lon);
    var marker = getMarker(p, name + "的当前位置", onlineimage, map);
    onlineMarkerManager.push(marker);
}
function clearOnlineUser() {
    onlineMarkerManager.length = 0;
}


function difftime(start, end) {      //求两时间的秒数差
    var date1 = new Date(start);  //开始时间
    var date2 = new Date(end);    //结束时间
    if (!date1.getTime() || !date2.getTime()) {
        date1 = new Date(Date.parse(start.replace(/-/g, "/")));
        date2 = new Date(Date.parse(end.replace(/-/g, "/")));
    }
    var date3 = date2.getTime() - date1.getTime()  //时间差的毫秒数
    return date3 / 1000;
}

function showPhotoChanged(obj) {
    for (var i = 0; i < patrolIDManager.length; i++)
        if (currentPatrolID == patrolIDManager[i]) {
            if (obj.checked) {
                showPhotoes(patrolMarkerManager[i], map);
            }
            else {
                removePhotoes(patrolMarkerManager[i], map);
            }
            break;
        }
}

function showWayChanged(obj) {
    if (currentPatrolID) {
        if (obj.checked) {
            showPatrolStepByStep(currentPatrolID);
        }
        else {
            removePhotoes(patrolMarkerManager[i], map);
        }
    }
}