// JScript 文件

//领导班子添加
$(function(){
    $("#Leader").click(function () {
        $("#addFrame").attr("src", "AddLeader.aspx");
        $("#addSourcePanel").fadeIn().attr("sid",showDialog("addSourcePanel",true,true));
    });
});
//领导班子修改
function mdy(id)
{
    $("#addFrame").attr("src", "AddLeader.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid",showDialog("addSourcePanel",true,true));
}

//企业荣誉添加
$(function () {
    $("#Honor").click(function () {
        $("#addFrame").attr("src", "AddHonor.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function Honor(id) {
    $("#addFrame").attr("src", "AddHonor.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//董事长风采添加
$(function () {
    $("#Chairman").click(function () {
        $("#addFrame").attr("src", "AddChairman.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});
//董事长风采修改
function Chairman(id) {
    $("#addFrame").attr("src", "AddChairman.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//经理人风采添加
$(function () {
    $("#Manage").click(function () {
        $("#addFrame").attr("src", "AddManage.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

//经理人风采修改
function Manage(id) {
    $("#addFrame").attr("src", "AddManage.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//公司动态添加
$(function () {
    $("#Enterprise").click(function () {
        $("#addFrame").attr("src", "AddEnterprise.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function Enterprise(id) {
    $("#addFrame").attr("src", "AddEnterprise.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//钢厂动态
$(function () {
    $("#SteelDynamic").click(function () {
        $("#addFrame").attr("src", "AddSteelDynamic.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function SteelDynamic(id) {
    $("#addFrame").attr("src", "AddSteelDynamic.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//架管行情
$(function () {
    $("#Jg").click(function () {
        $("#addFrame").attr("src", "AddJgPrice.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function Jg(id) {
    $("#addFrame").attr("src", "AddJgPrice.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//螺旋管价格行情

$(function () {
    $("#SpiralTube").click(function () {
        $("#addFrame").attr("src", "AddSpiralTube.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function SpiralTube(id) {
    $("#addFrame").attr("src", "AddSpiralTube.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}
//国内钢市中心
$(function () {
    $("#steelCenter").click(function () {
        $("#addFrame").attr("src", "AddsteelCenter.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function steelCenter(id) {
    $("#addFrame").attr("src", "AddsteelCenter.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//钢材资讯
$(function () {
    $("#SteelInfo").click(function () {
        $("#addFrame").attr("src", "AddSteelInfo.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function SteelInfo(id) {
    $("#addFrame").attr("src", "AddSteelInfo.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//管材
$(function () {
    $("#Pipe").click(function () {
        $("#addFrame").attr("src", "AddPipe.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function Pipe(id) {
    $("#addFrame").attr("src", "AddPipe.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//城市
$(function () {
    $("#City").click(function () {
        $("#addFrame").attr("src", "AddCity.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function City(id) {
    $("#addFrame").attr("src", "AddCity.aspx?cityid=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//地区
$(function () {
    $("#Area").click(function () {
        $("#addFrame").attr("src", "AddArea.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function Area(id) {
    $("#addFrame").attr("src", "AddArea.aspx?areaid=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//旅游类型
$(function () {
    $("#TravelType").click(function () {
        $("#addFrame").attr("src", "AddTravelType.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function TravelType(id) {
    $("#addFrame").attr("src", "AddTravelType.aspx?traveltypeid=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}


//型材
$(function () {
    $("#Profile").click(function () {
        $("#addFrame").attr("src", "AddProfile.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function Profile(id) {
    $("#addFrame").attr("src", "AddProfile.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//型材
$(function () {
    $("#Plank").click(function () {
        $("#addFrame").attr("src", "AddPlank.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function Plank(id) {
    $("#addFrame").attr("src", "AddPlank.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//管材配件
$(function () {
    $("#PipeFittings").click(function () {
        $("#addFrame").attr("src", "AddPipeFittings.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function PipeFittings(id) {
    $("#addFrame").attr("src", "AddPipeFittings.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//管架扣件
$(function () {
    $("#Fasteners").click(function () {
        $("#addFrame").attr("src", "AddFasteners.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function Fasteners(id) {
    $("#addFrame").attr("src", "AddFasteners.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}
//内贸
$(function () {
    $("#subsidiary").click(function () {
        $("#addFrame").attr("src", "AddSsdsubsidiary.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function subsidiary(id) {
    $("#addFrame").attr("src", "AddSsdsubsidiary.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//培训
$(function () {
    $("#Training").click(function () {
        $("#addFrame").attr("src", "AddTraining.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function Training(id) {
    $("#addFrame").attr("src", "AddTraining.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//外贸部门
$(function () {
    $("#Foreign").click(function () {
        $("#addFrame").attr("src", "AddForeign.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function Foreign(id) {
    $("#addFrame").attr("src", "AddForeign.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//招聘信息
$(function () {
    $("#Recruitment").click(function () {
        $("#addFrame").attr("src", "AddRecruitment.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function Recruitment(id) {
    $("#addFrame").attr("src", "AddRecruitment.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//友情链接
$(function () {
    $("#Link").click(function () {
        $("#addFrame").attr("src", "AddLink.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function Link(id) {
    $("#addFrame").attr("src", "AddLink.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//友情链接
$(function () {
    $("#Price").click(function () {
        $("#addFrame").attr("src", "AddPrice.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function Price(id) {
    $("#addFrame").attr("src", "AddPrice.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}

//友情链接
$(function () {
    $("#Logistics").click(function () {
        $("#addFrame").attr("src", "AddLogistics.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function Logistics(id) {
    $("#addFrame").attr("src", "AddLogistics.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}


//友情链接
$(function () {
    $("#growth").click(function () {
        $("#addFrame").attr("src", "AddGrowth.aspx");
        $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
    });
});

function growth(id) {
    $("#addFrame").attr("src", "AddGrowth.aspx?mdy=" + id);
    $("#addSourcePanel").fadeIn().attr("sid", showDialog("addSourcePanel", true, true));
}




