<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Justgo8._2009.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%--<script type="text/javascript">
            var redirect_uri = "http://www.justgo8.com/2009/index.aspx";
            var access_token;
            var refresh_token;
            var refresh_interval;
            var videoList;
            var commentList;
            var userList;
            var userIndex = 0;
            var commentIndex = 0;
            var comment_interval;
            var getVideo_interval;
            var comment_time = 60000;
            var getVideo_time = 1800000;
            var code = '<%=back_code %>';
            var client_id = '<%=back_client_id %>';
            var client_secret = '<%=back_client_secret %>';
            var appname = '<%=back_appname %>';
            function Init() {
                document.title = appname;
                videoList = new Array();
                userList = new Array();
                userList.push("伍声2009");
                commentList = new Array();
                commentList.push("奈死奈死奈死");
                commentList.push("V587");
                commentList.push("顶一下");
                commentList.push("哈哈,终于更新了");
                commentList.push("奈思");
                commentList.push("太牛B");
                commentList.push("baqi");
                commentList.push("支持");
                commentList.push("永远爱你");
                commentList.push("中个奖");
                commentList.push("是时候中个奖了");
                commentList.push("先顶后看");
                commentList.push("先占个地");
                commentList.push("持续关注");
                commentList.push("哈哈哈哈");
                commentList.push("叼");
                commentList.push("很犀利");
                commentList.push("是时候留个言了");
                commentList.push("我又来了");
                commentList.push("中奖来咯");
                commentList.push("生活不能没有dota");
                commentList.push("我从不打dota");
                commentList.push("记我们终将逝去的dota");
                commentList.push("怀念大学生活");
                commentList.push("怀念当年");
                commentList.push("再搞一把");
                commentList.push("决战到天亮");
                commentList.push("好");
                commentList.push("很好");
                commentList.push("非常好");
                commentList.push("yes");
                commentList.push("哎呀,不错哦");
                commentList.push("哎喲,不错哦");
                commentList.push("留B");
                commentList.push("赞");
                commentList.push("叼爆天了");
                commentList.push("威5");
                commentList.push("霸气");
                commentList.push("上档次");
                commentList.push("低调");
                commentList.push("奢华");
                commentList.push("众人一起赞");
                commentList.push("我给一个赞");
                commentList.push("好的");
                commentList.push("永远支持");
                commentList.push("再一次支持");
                commentList.push("这");
                commentList.push("我来占个地");
                commentList.push("中个把子奖看看");
                commentList.push("来吧");
                commentList.push("支持支持支持");
                commentList.push("吊");
                commentList.push("来长点的");
                commentList.push("来部更长的");
                commentList.push("顶下再说");
                commentList.push("我还是觉得少了点");
                commentList.push("来个奖吧");
                commentList.push("不错");
                commentList.push("哦哈哈,中奖了");
                commentList.push("哈哈,高清的");
                commentList.push("哈哈,超清的");
                commentList.push("大神去哪儿");
                commentList.push("我来了，你懂的");
                commentList.push("xixi");
                commentList.push("过年了，打dota的小朋友又多了");
                commentList.push("这段时间打dota发现越来越多的人懂得dota的精髓了，都他妈一直推塔，不跟你打架，无限推，就是不打正面，几路带，甚至偷塔的都一些");
                $(document).ajaxError(function (event, request, settings) {
                    var error = eval('(' + request.responseText + ')');
                    if (error) {
                        $("#accesses").val($("#accesses").val() + "\r\nerror:" + error.error.code + " " + error.error.description);
                        if (error.error.code == "1008") {
                            clearInterval(comment_interval);
                            clearInterval(getVideo_interval);
                            getAccessToken(code);
                        }
                    }
                    else {
                        $("#accesses").val($("#accesses").val() + "\r\n" + "error:unknown error");
                    }
                    clearInterval(refresh_interval);
                });
                if (code && client_id && client_secret) {
                    getAccessToken(code);
                    return;
                }
                else {
                    $("#accesses").val("nothing will be done");
                }
            }
            function getAccessToken(c) {
                var data = {
                    "client_id": client_id,
                    "client_secret": client_secret,
                    "grant_type": "authorization_code",
                    "code": c,
                    "redirect_uri": redirect_uri
                };
                $.post("https://openapi.youku.com/v2/oauth2/token", data, function (responsedata) {
                    access_token = responsedata.access_token;
                    refresh_token = responsedata.refresh_token;
                    $("#accesses").val("initialAccess:" + responsedata.access_token);
                    // refresh_interval = window.setInterval(function () {refreshAccessToken(refresh_token); }, 5000);
                    mainWork();
                });
            }
            function refreshAccessToken(access) {
                var data = {
                    "client_id": client_id,
                    "client_secret": client_secret,
                    "grant_type": "refresh_token",
                    "refresh_token": access
                };
                $.post("https://openapi.youku.com/v2/oauth2/token", data, function (responsedata) {
                    access_token = responsedata.access_token;
                    refresh_token = responsedata.refresh_token;
                    $("#accesses").val($("#accesses").val() + "\r\n" + responsedata.access_token);

                });
            }
            function getLastestVideo(username) {
                var url = "https://openapi.youku.com/v2/videos/by_user.json?client_id=" + client_id + "&user_name=" + username + "&page=1&count=1";
                $.get(url, null, function (responsedata) {
                    var video = new Array();
                    video["videoid"] = responsedata.videos[0].id;
                    video["title"] = responsedata.videos[0].title;
                    videoList[username] = video;
                });
            }
            function getRandomComment() {
                if (commentList && commentList.length > 0) {
                    return commentList[Math.floor(Math.random() * commentList.length)];
                }
                else {
                    return "";
                }
            }
            function createComment(videoid, content) {
                var data = {
                    "client_id": client_id,
                    "access_token": access_token,
                    "video_id": videoid,
                    "content": content
                };
                $.post("https://openapi.youku.com/v2/comments/create.json", data, function (responsedata) {
                    userIndex++;
                    $("#accesses").val($("#accesses").val() + "\r\n成功:ID:" + responsedata.id + " 内容:" + content);
                });
            }
            function mainWork() {
                for (var p in userList) {
                    getLastestVideo(userList[p]);
                }
                //获取最新视频
                getVideo_interval = window.setInterval(function () {
                    for (var p in userList) {
                        getLastestVideo(userList[p]);
                    }
                }, getVideo_time);

                comment_interval = window.setInterval(function () {
                    if (commentIndex >= commentList.length)
                        commentIndex = 0;
                    var comment = commentList[commentIndex++]; //getRandomComment();                
                    if (!comment) {
                        return;
                    }
                    if (userIndex >= userList.length)
                        userIndex = 0;
                    var videoid = videoList[userList[userIndex]].videoid;
                    if (!videoid) {
                        return;
                    }
                    createComment(videoid, comment);
                }, comment_time);
            }
            $().ready(Init);
        </script>--%>
    </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="text-align: center">
            <textarea id="accesses" rows="30" cols="180"></textarea>
        </div>
    </div>
    </form>
</body>
</html>
