
var PrintActiveX;
function ActiveXPrint() {//debugger;
    //判断是否是IE浏览器
    var ua = navigator.userAgent.toLowerCase();
    if (!window.ActiveXObject) {
        window.print();
        return;
    }
    PrintActiveX = document.getElementById("objPrintActiveX");
    try {
        var comActiveX = new ActiveXObject("QWPrint.QWPrinter");
    }
    catch (e) {
        parent.Dialog.confirm("未安装打印插件，请先安装...",
            function() {
                window.parent.open("../Download/WebPrintActiveX.exe");
            },
            function() {

            }
        );
        return;
    }
    var copies = 1;
    PrintActiveX.paddingTop = 10;
    PrintActiveX.paddingRight = 10;
    PrintActiveX.paddingBottom = 10;
    PrintActiveX.paddingLeft = 10;
    timeOut = 2;
    PrintActiveX.header = "";
    PrintActiveX.footer = "";
    PrintActiveX.orientation = 1;
    rePrint();
    var s = 1000 * timeOut; //打印等待的时间间隔
    for (i = 0; i < copies - 1; i++) {
        setTimeout("rePrint()", s);
    }
}

var rePrint = function() {
    PrintActiveX.Print(false);
}