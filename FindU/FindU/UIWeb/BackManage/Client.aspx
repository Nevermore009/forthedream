<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Client.aspx.cs" Inherits="Client" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>

    <script src="../js/http.js" type="text/javascript"></script>

    <script type="text/javascript">
        function connect() {
            var imei = document.getElementById("IMEI").value;
            var x = Math.floor(Math.random(100) * 100);
            sendHttpRequest("test.findu?IMEI=" + imei + "&id=" + x, connectSuccess, connectFailed, "get");
            document.getElementById("message").innerHTML += "do connecting" + "<br />";
        }
        function connectSuccess(xmlhttp) {
            var imei = document.getElementById("IMEI").value;
            var content = xmlhttp.responseText;
            if (content != "again") {
                xmlhttp = null;  //将其销毁，防止浏览器重复使用
                document.getElementById("message").innerHTML += content + "<br />";
            }
            window.setTimeout("connect()", 0);  //在IE中如果直接调用connect(),会出现内存溢出
        }
        function connectFailed() {
            document.getElementById("message").innerHTML += "connectFailed<br />";
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        IMEI:<input id="IMEI" />
        <input type="button" id="btnconnect" value="connect" onclick="connect()" /><br />
        content:<div id="message" style="width: 400px; height: 200px; border: solid 1px gray">
        </div>
        <br />
    </div>
    </form>
</body>
</html>
