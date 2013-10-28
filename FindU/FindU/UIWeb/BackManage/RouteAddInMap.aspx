<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RouteAddInMap.aspx.cs" Inherits="Admin_RouteAddInMap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>地图查看</title>
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <script src="../js/MapHelper.js" type="text/javascript"></script>
    <script src="../js/http.js" type="text/javascript"></script>
    <script type="text/javascript">

        var map;
        var polyline;
        var markerArray = [];
        var infowindow;                         //标记弹出框
        var currentEditMarker;
        var currentDragMarker;                  //当前拖动marker
        var startimage = "../images/start.gif";
        var endimage = "../images/end.gif";
        var wayimage = "../images/icon.gif";
        var travelimage = "../images/travel.gif";
        var noimage = "D:/";


        function initialize() {
            var center = new google.maps.LatLng(29.046552, 111.692853);
            map = GetMap(document.getElementById("map"), center, 12);
            showPatrol();
        }

        function getMarker(position, title, image, map) {     //创建标记,map:地图;title:标记文字;position:标记位置;image:标记图片
            return new google.maps.Marker({
                map: map,
                title: title,
                icon: image,
                position: position
            });
        }

        function CreateXml(str) {    //将字符串转化为xml文档对象
            if (document.all) {
                var xmlDom = new ActiveXObject("Microsoft.XMLDOM");
                xmlDom.loadXML(str);
                return xmlDom;
            }
            else
                return new DOMParser().parseFromString(str, "text/xml")
        }

        function showPatrol() {
            var datatext = '<%=PatrolXmlText %>';
            var doc = CreateXml(datatext);
            var patrols = doc.getElementsByTagName("patrol");
            if (patrols.length > 0) {
                var patrolinfos = patrols[0].getElementsByTagName("patrolinfo");
                if (patrolinfos.length <= 0)
                    return;
                polyline = getPolyline(markerArray, 1.0, 5, "green");
                polyline.setEditable(true);
                google.maps.event.addListener(polyline, 'mousemove', function (PolyMouseEvent) {

                });
                google.maps.event.addListener(polyline, 'mousedown', function (PolyMouseEvent) {
                    if (PolyMouseEvent.vertex >= 0) {
                        var marray = polyline.getPath()
                        for (var k = 0; k < markerArray.length; k++) {
                            if (markerArray[k].getPosition() == marray.getAt(PolyMouseEvent.vertex)) {
                                currentDragMarker = markerArray[k];
                            }
                        }
                    }
                });
                google.maps.event.addListener(polyline, 'mouseout', function (PolyMouseEvent) {
                    if (PolyMouseEvent.vertex >= 0) {
                        if (currentDragMarker) {
                            for (var k = 0; k < markerArray.length; k++) {
                                if (markerArray[k] == currentDragMarker) {
                                    markerArray[k].setPosition(polyline.getPath().getAt(PolyMouseEvent.vertex));
                                    currentDragMarker = null;
                                    break;
                                }
                            }
                        }
                    }
                });
                google.maps.event.addListener(polyline, 'mouseover', function (PolyMouseEvent) {
                });
                google.maps.event.addListener(polyline, 'mouseup', function (PolyMouseEvent) {

                });
                polyline.setMap(map);
                for (var j = 0; j < patrolinfos.length; j++) {
                    var image = "";
                    if (j == 0)
                        image = startimage;
                    else if (j == patrolinfos.length - 1)
                        image = endimage;
                    else
                        image = wayimage;
                    var latlng = new google.maps.LatLng(patrolinfos[j].getAttribute("lat"), patrolinfos[j].getAttribute("lon"));
                    var marker = getMarker(latlng, "", image, map);
                    (function (m) {
                        google.maps.event.addListener(m, 'click', function () {
                            if (!infowindow) {
                                infowindow = new google.maps.InfoWindow();
                            }
                            currentEditMarker = this;
                            var titlearray = this.getTitle().split("|");
                            var title = titlearray[0] || "";
                            var remark = titlearray[1] || "";
                            var html = "<div style='font-size: 20px;'><center>名称:<input type='text' value='" + title + "' id='txttitle' style='width: 150px' /><br /> 备注:<input type='text' value='" + remark + "'  id='txtremark' style='width: 150px' height='200px' /><br /> <input type='button' id='btnsubmit' value='保存' onclick='saveTitle(txttitle=getElementById(\"txttitle\").value,txtremark=getElementById(\"txtremark\").value)' style='width: 80px;height:27px' /></center></div>";
                            infowindow.setContent(html);
                            infowindow.open(map, m);
                        });
                    })(marker);
                    (function (m) {
                        google.maps.event.addListener(m, 'rightclick', function () {
                            if (confirm("确定要删除吗?")) {
                                deleteMarker(this);
                                return false;
                            }
                        });
                    })(marker);
                    if (j == patrolinfos.length - 1) {
                        (function (m) {
                            google.maps.event.addListener(m, 'dblclick', function () {
                                if (!infowindow) {
                                    infowindow = new google.maps.InfoWindow();
                                }
                                var html = "<div style='font-size: 20px; width: 150px height:130px'> 线路名: <input type='text' id='txtroute' width='100px' /><br /> 备注: <input type='text' id='txtdescription' width='100px' /><br /> <input type='button' id='btnsave' value='保存' width='50px' onclick='var route= document.getElementById(\"txtroute\").value;var remark=document.getElementById(\"txtdescription\").value;if(route.length<=0){alert(\"线路名不能为空!\");return;} saveRoute(route,remark);' /> <div>";
                                infowindow.setContent(html);
                                infowindow.open(map, m);
                            });
                        })(marker);
                    }
                    markerArray.push(marker);
                    addPointToPolyLine(polyline, latlng);
                }
            }
        }

        function saveRoute(title, remark) {
            if (window.ActiveXObject) {
                var doc = new ActiveXObject("Microsoft.XMLDOM");
                doc.async = "false";
            }
            //ff
            else if (document.implementation && document.implementation.createDocument) {
                doc = document.implementation.createDocument("", "", null);
            }
            var Root = doc.createElement("routeDescription");
            doc.appendChild(Root);
            Root.setAttribute("routename", title);
            Root.setAttribute("routeRemark", remark);
            for (var i = 0; i < polyline.getPath().getLength(); i++) {
                var Node = doc.createElement("stationDescription");
                Node.setAttribute("lat", polyline.getPath().getAt(i).lat());
                Node.setAttribute("lon", polyline.getPath().getAt(i).lng());
                var marker = findMarker(polyline.getPath().getAt(i));
                if (marker) {
                    var titlearray = marker.getTitle().split("|");
                    var title = titlearray[0] || "";
                    var remark = titlearray[1] || "";
                    Node.setAttribute("stationname", title);
                    Node.setAttribute("stationremark", remark);
                }
                Root.appendChild(Node);
            }
            sendHttpRequest("Saverouteinf.ashx", function () {
                alert("保存成功！");
                if (confirm("要关闭当前页吗?")) {
                    window.opener = null;
                    window.open('', '_self');
                    window.close();
                }
            }, function () { alert("保存失败！"); }, "post", doc);
        }

        function findMarker(position) {
            for (var i = 0; i < markerArray.length; i++) {
                if (markerArray[i].getPosition() == position)
                    return markerArray[i];
            }
        }

        function saveTitle(title, remark) {
            for (var i = 0; i < markerArray.length; i++) {
                if (markerArray[i] == currentEditMarker) {
                    markerArray[i].setTitle(title + "|" + remark);
                    alert("保存成功");
                    if (infowindow) {
                        infowindow.close();
                    }
                }
            }
        }
        function deleteMarker(marker) {
            for (var i = 0; i < markerArray.length; i++) {
                if (markerArray[i] == marker) {
                    markerArray[i].setMap(null);
                    markerArray.splice(i, 1);
                    var marray = polyline.getPath();
                    for (var m = 0; m < marray.getLength(); m++) {
                        if (marray.getAt(m) == marker.getPosition()) {
                            marray.removeAt(m);
                            break;
                        }
                    }
                    break;
                }
            }
        }
    </script>
</head>
<body onload="initialize()">
    <div id="map" style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%;
        background-image: url(../images/loading.jpg); background-position: center;">
    </div>
</body>
</html>
