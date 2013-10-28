function CheckEvent(evt) {
    evt = window.event || evt;
    var objNode = evt.srcElement || evt.target;
    if (objNode.tagName == "INPUT" && objNode.type == "checkbox") {
        var objParentDiv = objNode.id.replace("CheckBox", "Nodes");
        if (objNode.checked == true) {
            setChildCheckState(objParentDiv, true);

            setParentCheckeState(objNode, true);
        }
        else {
            setChildCheckState(objParentDiv, false);

            if (!HasOtherChecked(objNode)) {
                setParentCheckeState(objNode, false);
            }
        }
    }
}

//判断是否有并行的其他节点被选中
function HasOtherChecked(objNode) {
    var objParentDiv = WebForm_GetParentByTagName(objNode, "div");

    var chks = objParentDiv.getElementsByTagName("INPUT");
    for (var i = 0; i < chks.length; i++) {
        if (chks[i].checked && chks[i].id != objNode.id) {
            return true;
        }
    }
    return false;
}

//设置父节点
function setParentCheckeState(objNode, chkstate) {
    try {
        var objParentDiv = WebForm_GetParentByTagName(objNode, "div");

        if (objParentDiv == null || objParentDiv == "undefined ") {
            return;
        }
        else {
            var objParentChkId = objParentDiv.id.replace("Nodes", "CheckBox");
            var objParentCheckBox = document.getElementById(objParentChkId);

            if (objParentCheckBox) {
                objParentCheckBox.checked = chkstate;
                setParentCheckeState(objParentDiv, chkstate);
            }
        }
    }
    catch (e) { }
}

//设置子节点
function setChildCheckState(nodeid, chkstate) {
    var node = document.getElementById(nodeid);

    if (node) {
        var chks = node.getElementsByTagName("INPUT");
        for (var i = 0; i < chks.length; i++) {
            chks[i].checked = chkstate;
        }
    }
} 
