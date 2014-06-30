function getResourceList(sort, nsort, spec, provinceid, yieldly, pageindex, success, failed) {
    $.ajax({
        type: "POST",
        url: "../Market/Index",
        data: { sortid: sort, nsortid: nsort, spec: spec, provinceid: provinceid, yieldly: yieldly, pageIndex: pageindex },
        success: success,
        error: failed
    });
}