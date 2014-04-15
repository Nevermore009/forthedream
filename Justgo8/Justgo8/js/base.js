
//收藏
function WindowFavorites(sURL, sTitle) {
    if (sURL == "" || sURL == undefined) {
        sURL = window.location.href;
    }
    if (sTitle == "" || sTitle == undefined) {
        sTitle = document.title;
    }

    try {
        window.external.addFavorite(sURL, sTitle);
    }
    catch (e) {
        try {
            window.sidebar.addPanel(sTitle, sURL, "");
        }
        catch (e) {
            alert("加入收藏失败，请使用Ctrl+D进行添加");
        }
    }
}
function CheckPhoneNum(phoneNum) {
    var partten = /(^(\d{3,4}\-)?\d{7,8}(\-\d{3,4})?$)|(^(13|14|15|18)\d{9}$)/;
    if (!partten.test(phoneNum)) {
        return false;
    }
    return true;
}
function CheckEmail(email) {
    var myReg = /(^\s*)\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*(\s*$)/;
    if (!myReg.test(email)) {
        return false;
    }
    return true;
}
function OnTextBoxClick(obj, msg) {
    if ($(obj).val() == msg) {
        $(obj).val("");
    }
}
function OnTextBoxBlur(obj, msg) {
    if ($(obj).val() == "") {
        $(obj).val(msg);
    }
}
function GetTextBoxVal(obj, msg) {
    if ($(obj).val() != msg) {
        return $(obj).val();
    }
    return "";
}


