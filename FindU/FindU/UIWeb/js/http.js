function createHttpRequest() {                   //返回httpRequest对象
    if (window.ActiveXobject) {
        return (new ActiveXObject("Microsoft.XMLHTTP"));
    }
    else if (window.XMLHttpRequest) {
        return (new XMLHttpRequest());
    }
}

function sendHttpRequest(url, successFunction, failedFunction, method, content) {        //向指定url发送http请求,请求响应函数responseFunction
    var xmlhttp = createHttpRequest();
    if (!xmlhttp) {
        alert("该页面不兼容当前浏览器,建议使用IE浏览器浏览.");
        return;
    }
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4) {
            if (xmlhttp.status == 200)
            { if (successFunction) successFunction(xmlhttp); }
            else { if (failedFunction) failedFunction(); }
        }
    };
    if (method == 'post') {
        xmlhttp.open("post", url, true);
        xmlhttp.send(content);
    }
    else {
        xmlhttp.open("get", url, true);
        xmlhttp.send(null);
    }
}