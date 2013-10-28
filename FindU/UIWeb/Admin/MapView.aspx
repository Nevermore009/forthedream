<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapView.aspx.cs" Inherits="Admin_MapView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>地图查看</title>
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <script src="../js/MapHelper.js" type="text/javascript"></script>
    <script src="../js/http.js" type="text/javascript"></script>
    <script type="text/javascript">
        var map;  //地图对象
        var ltlng = [];   //坐标点对象
        var inc = 0;                      //用于动态画路线
        var line = [];                    //用于在两点间添加连线,line[0]为起点,line[1]为终点,调用addPath()即可添加连线
        var infowindow;                   //点击弹出窗口
        var startimage = "../images/start.gif";
        var endimage = "../images/end.gif";
        var wayimage = "../images/icon.gif";
        var travelimage = "../images/travel.png";
        var noimage = "D:/";

        function Init() {
            ChangeMapSize();
            InitMap();
            InitRouteData();
            InitTravelData();
            InitKeyPoint();
        }
        function ChangeMapSize() {      //地图DIV大小适应窗口  
            document.getElementById("map").style.height = document.documentElement.clientHeight + "px";
        }
        function InitMap() {      //初始化地图
            var center = new google.maps.LatLng(29.046552, 111.692853);
            map = GetMap(document.getElementById("map"), center, 20);
        }
        function OperateXml(route, remark) {
            //ie
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
            Root.setAttribute("routename", route);
            Root.setAttribute("routeRemark", remark);
            for (var i = 0; i < ltlng[0].length; i++) {
                var Node = doc.createElement("stationDescription");
                Node.setAttribute("lat", ltlng[0][i].lat());
                Node.setAttribute("lon", ltlng[0][i].lng());
                Node.setAttribute("stationname", ltlng[3][i]);
                Node.setAttribute("stationremark", ltlng[4][i]);
                Root.appendChild(Node);
            }
            sendHttpRequest("Saverouteinf.ashx", function () { alert("保存成功！"); }, function () { alert("保存失败！"); }, "post", doc);
        }
        function SetDbClickEvent(map, marker) {           //注册地图双击事件
            google.maps.event.addListener(marker, "dblclick", function (event) {
                //若是从PatrolPlanView中过来的则不需要弹出框
                var flags = '<%=flags %>';
                if (flags == "True")
                    return;
                routeinfowindow = new google.maps.InfoWindow();
                routeinfowindow.setContent("<div style='font-size:20px;width:150px height:130px'>  <center><table><tr><td>线路名:</td><td><input type='text' id='txtroute'  Width='100px' /></td></tr><tr><td>备注:</td> <td><input type='text' id='txtdexcription'   Width='100px' /></td></tr> <tr>  <td></td><td> <input type='button' id='btnsave'  value='保存' Width='50px' onclick='var route= document.getElementById(\"txtroute\").value;  var remark=document.getElementById(\"txtdexcription\").value;if(route.length<=0){alert(\"线路名不能为空!\");return;} OperateXml(route,remark);  ' /></td></tr></table></center><div> ");
                routeinfowindow.open(map, marker);
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

        function InitKeyPoint() {
            var lat = '<%=Lat %>';
            var lon = '<%=Lon %>';
            if (lat != '' && lon != '') {
                var point = new google.maps.LatLng(lat, lon);
                var m = new google.maps.Marker({
                    title: "该点的位置",
                    icon: wayimage,
                    position: point
                });
                m.setMap(map);
                map.setCenter(point);
                map.setZoom(18);
                SetClick(map, m, inc);
                // SetDbClickEvent(map, m);
            }
        }

        function InitRouteData() {   //初始化参考线路数据
            var RouteXmlText = '<%=RouteXmlText%>';
            if (RouteXmlText == '')
                return;
            var doc = CreateXml(RouteXmlText);
            var routes = doc.getElementsByTagName("route");
            ltlng = [];
            var temp = [];               //一条线路的信息,它包括4个部分,分别对应索引,0线路特征(0:线路名称;1:线路说明);1:坐标点信息;2:各坐标站点名称;3:坐标点备注;4:站点id
            var routeinformation = [];
            var latandlon = [];            //线路的坐标信息
            var stationname = [];        //各坐标点名称
            var description = [];        //各坐标点备注
            var ids = [];                //各站点标识
            for (var i = 0; i < routes.length; i++) {
                temp = [];
                routeinformation = [];
                var routeinfos = routes[i].getElementsByTagName("routeinfo");
                if (routeinfos.length <= 0)
                    continue;
                routeinformation.push(routes[i].getAttribute("routename"));
                routeinformation.push(routes[i].getAttribute("description"));
                temp.push(routeinformation);
                latandlon = [];
                description = [];
                for (var j = 0; j < routeinfos.length; j++) {
                    latandlon.push(new google.maps.LatLng(routeinfos[j].getAttribute("lat"), routeinfos[j].getAttribute("lon")));
                    stationname.push(routeinfos[j].getAttribute("title"));
                    description.push(routeinfos[j].getAttribute("description"));
                    ids.push(routeinfos[j].getAttribute("id"));
                    tempinfo = [];
                }
                temp.push(latandlon);
                temp.push(stationname);
                temp.push(description);
                temp.push(ids);
                ltlng.push(temp);
            }
            InitMap();
            DrawRoute();
        }

        function getMarker(map, title, position, image) {     //创建标记,map:地图;title:标记文字;position:标记位置;image:标记图片
            return new google.maps.Marker({
                map: map,
                title: title,
                icon: image,
                position: position
            });
        }
        function DrawRoute() {       //描绘参考线路
            for (var j = 0; j < ltlng.length; j++) {
                for (var i = 0; i < ltlng[j][1].length; i++) {
                    if (i == 0) {
                        var title = ltlng[j][0][0] + " " + ltlng[j][2][i];
                        marker = getMarker(map, title, ltlng[j][1][i], startimage);
                    }
                    else if (i == ltlng[j][3].length - 1) {
                        marker = getMarker(map, ltlng[j][2][i], ltlng[j][1][i], endimage);
                    }
                    else {
                        if (ltlng[j][2][i] == '') {
                            marker = getMarker(map, ltlng[j][2][i], ltlng[j][1][i], noimage);
                        }
                        else {
                            marker = getMarker(map, ltlng[j][2][i], ltlng[j][1][i], wayimage);
                        }
                    }
                    var src = "title.aspx?id=" + ltlng[j][4][i] + "&title=" + ltlng[j][2][i] + "&description=" + ltlng[j][3][i];
                    SetClickEvent(map, marker, src, 200, 150);
                }
            }
            for (var k = 0; k < ltlng.length; k++) {
                addPath(map, ltlng[k][1], "red", 1.0, 8);
            }
            map.setCenter(ltlng[ltlng.length - 1][1][0]);
            map.setZoom(12);
        }

        function SetClickEvent(map, marker, src, width, height) {    //添加标记单击事件
            google.maps.event.addListener(marker, 'click', function () {
                if (!infowindow) {
                    infowindow = new google.maps.InfoWindow();
                }
                if (width == null)
                    width = 200;
                if (height == null)
                    height = 200;
                infowindow.setContent("<iframe id='showtitle' frameborder='0' src='" + src + "' border='none' width='" + width + "px' height='" + height + "px'></iframe>");
                infowindow.open(map, marker);
            });
        }
        function SetClick(map, marker, inc) {    //描绘行进路线时的单击事件
            google.maps.event.addListener(marker, 'click', function () {
                if (!infowindow) {
                    infowindow = new google.maps.InfoWindow();
                }
                //若是从PatrolPlanView中过来的则不需要弹出框
                var flags = '<%=flags %>';
                if (flags == "True") { 
                     return;
                }
           
                infowindow.setContent("<div  style='font-size:20px;width:150px height:130px'>  <center><table><tr><td>站点名:</td><td><input type='text' id='txttitle' Disabled='disabled' Width='100px' /></td></tr><tr><td>备注:</td> <td><input type='text' id='txtremark'  Disabled='disabled' Width='100px' /></td></tr> <tr>  <td></td><td> <input type='button' id='btnedit'  value='编辑' Width='50px' onclick='document.getElementById(\"txttitle\").disabled=false;document.getElementById(\"txtremark\").disabled=false; document.getElementById(\"btnsubmit\").disabled=false;document.getElementById(\"btnedit\").disabled=true;'/> <input type='button' id='btnsubmit'  value='修改' Disabled='disabled' onclick='document.getElementById(\"txttitle\").disabled=true;document.getElementById(\"txtremark\").disabled=true; document.getElementById(\"btnedit\").disabled=false; document.getElementById(\"btnsubmit\").disabled=true;txttitle=getElementById(\"txttitle\").value;txtremark=getElementById(\"txtremark\").value;ltlng[3][" + inc + "]=document.getElementById(\"txttitle\").value;ltlng[4][" + inc + "]=document.getElementById(\"txtremark\").value;' Width='50px' /></td></tr></table></center><div> ");
                infowindow.open(map, marker);
            });
        }
        function InitTravelData()      //初始化行径轨迹数据
        {
            ltlng = [];   //数据说明:0(坐标点信息），1（坐标点说明信息），2计划名称
            inc = 0;
            var TravelXmlText = '<%=TravelXmlText%>';
            if (TravelXmlText == '')
                return;
            var doc = CreateXml(TravelXmlText);
            var lng = doc.getElementsByTagName("patrolinfo");
            var title = [];
            var titleinfo = [];
            for (var i = 0; i < lng.length; i++) {
                if (ltlng.length <= 0) {
                    var temp = [];  //坐标点信息
                    temp.push(new google.maps.LatLng(lng[i].getAttribute("lat"), lng[i].getAttribute("lon")));
                    ltlng.push(temp);
                }
                else {
                    ltlng[0].push(new google.maps.LatLng(lng[i].getAttribute("lat"), lng[i].getAttribute("lon")));
                }
                titleinfo = [];  //坐标点说明信息0:到达时间，1：巡线员工，2:是否发送基站，3停留时间,4备注
                titleinfo.push(lng[i].getAttribute("locatetime"));
                titleinfo.push(lng[i].getAttribute("staffname"));
                titleinfo.push(lng[i].getAttribute("isauto"));
                titleinfo.push(lng[i].getAttribute("standingtime"));
                titleinfo.push(lng[i].getAttribute("remark"));
                title.push(titleinfo);
            }
            ltlng.push(title);
            var root = doc.getElementsByTagName("patrol");
            if (ltlng.length <= 2) {
                var basic = [];  //巡线基本信息 索引0:计划名称,1:线路名称,
                basic.push(root[0].getAttribute("planname"));
                basic.push(root[0].getAttribute("routename"));
                ltlng.push(basic);
            }
            else {
                ltlng[2].push(root[0].getAttribute("planname"));
                ltlng[2].push(root[0].getAttribute("routename"));
            }
            ltlng[3] = [];//基站名
            ltlng[4] = [];//基站备注

            DrawTravel();
        }

        function DrawTravel() {    //描绘行径路线
              if (ltlng[0].length <= 0) {
                return;
            }
            else if (inc == 0) {
                map.setZoom(15);
                    var title = ltlng[1][inc][0] + "\n巡检员:" + ltlng[1][inc][1] + "\n计划名称：" + ltlng[2][0] + "\n线路名称：" + ltlng[2][1] + "\n停留时间：" + ltlng[1][inc][3] / 60 + "分钟";
                    marker = getMarker(map, title, ltlng[0][inc], startimage);
                    SetClick(map, marker, inc);
                    //若页面是从PatrolPlanView进来则点击行进路线弹出备注框
                    var flags = '<%=flags %>';
                    if (flags == "True") {
                        var src = "PatrolRemark.aspx?locatetime=" + ltlng[1][inc][0] + "&remark=" + ltlng[1][inc][4];
                        SetClickEvent(map, marker, src, 220, 170);
                    }
            }
            else {
                line[0] = ltlng[0][inc - 1];
                line[1] = ltlng[0][inc];
                addPath(map, line, "green", 1.0, 5);
                if (inc == ltlng[0].length - 1) {
                        var title = ltlng[1][inc][0] + "\n巡检员:" + ltlng[1][inc][1] + "\n计划名称：" + ltlng[2][0] + "\n线路名称：" + ltlng[2][1] + "\n停留时间：" + ltlng[1][inc][3] / 60 + "分钟";
                    marker = getMarker(map, title, ltlng[0][inc], endimage);
                    SetClick(map, marker, inc);
                    map.setCenter(ltlng[0][inc]);
                    SetClick(map, marker, inc);
                    SetDbClickEvent(map, marker);
                    var flags = '<%=flags %>';
                    if (flags == "True") {
                        var src = "remark.aspx?locatetime=" + ltlng[1][inc][0] + "&remark=" + ltlng[1][inc][4];
                        SetClickEvent(map, marker, src, 220, 170);
                    }
                    inc++;
                    map.setZoom(15);
                    return;
                }
                else {
                    var title = ltlng[1][inc][0] + "\n巡检员:" + ltlng[1][inc][1] + "\n计划名称：" + ltlng[2][0] + "\n线路名称：" + ltlng[2][1] + "\n停留时间：" + ltlng[1][inc][3] / 60 + "分钟";          
                        //当页面是从RoutePlanView.aspx进来且该点事按了基站报告且停留时间大于0
                        var flags = '<%=flags %>';
                        if (flags == "True" && ltlng[1][inc][2] == "0" && ltlng[1][inc][3] > 0) {

                            marker = getMarker(map, title, ltlng[0][inc], wayimage);
                        }
                        else if (ltlng[1][inc][2] == "0" &&flags != "True") {
                            marker = getMarker(map, title, ltlng[0][inc], wayimage);
                        }
                        else {
                            marker = getMarker(map, title, ltlng[0][inc], noimage);
                        }
                        SetClick(map, marker, inc);
                        var flags = '<%=flags %>';
                        if (flags == "True") {
                            var src = "remark.aspx?locatetime=" + ltlng[1][inc][0] + "&remark=" + ltlng[1][inc][4];
                            SetClickEvent(map, marker, src, 220, 170);
                        }
                }
            }
            map.setCenter(ltlng[0][inc]);
            inc++;
            window.setTimeout('DrawTravel()', 1000);
        }
     
    </script>
</head>
<body style="margin: 0px 0px" onload="Init()" onresize="ChangeMapSize()">
    <div id="map" style="background-image: url(../images/loading.jpg); background-position: center;">
    </div>
</body>
</html>
