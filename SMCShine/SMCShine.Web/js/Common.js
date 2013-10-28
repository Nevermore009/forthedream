
function PrintHtml(url) {//debugger;
    var count = 0;
    var iframePrint = null;
    var win = window;
    do {
        iframePrint = win.document.getElementById("printFrame");
        win = win.parent;
        count++;
    }
    while (count < 5 && iframePrint == null);
    if (iframePrint != null) {
        iframePrint.src = url;
        return true;
    }
    else {
        return false;
    }
}