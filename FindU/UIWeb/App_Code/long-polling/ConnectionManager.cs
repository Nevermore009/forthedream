using System;
using System.Web;
using System.Runtime.Remoting.Messaging;
using System.Collections.Generic;
using BLL;

/// <summary>
///StateManager 的摘要说明
/// </summary>
public class ConnectionManager
{
    public WaitThread waitThread { set; get; }

    public ConnectionManager()
    {
        waitThread = new WaitThread();
    }

    /// <summary>
    /// 开始异步请求
    /// </summary>
    /// <param name="context"></param>
    /// <param name="callback"></param>
    /// <param name="extraData"></param>
    /// <returns></returns>
    public IAsyncResult BeginSubscribe(HttpContext context, AsyncCallback callback, object extraData)
    {
        string requestID = context.Request["IMEI"];
        if (context.Request["code"] != null)
        {
            if ((new Terminal()).Exist(requestID))
            {
                context.Response.Write("bindsuccess");
            }
            else
                (new TerminalBind()).AddCode(context.Request["code"].ToString(), requestID);
        }
        else if (context.Request["finish"] != null && context.Request["finish"].ToString() == "1")
        {
            (new Plan()).Finish(requestID);
        }
        WaitRequest request = GetRequestByID(requestID) ?? (new WaitRequest(context, callback, extraData));
        waitThread.AddRequest(request);
        return request.Result;
    }

    /// <summary>
    /// 结束异步请求
    /// </summary>
    /// <param name="result"></param>
    public void EndSubscribe(IAsyncResult result)
    {
        AsyncResult asyncResult = result as AsyncResult;
        foreach (Message msg in asyncResult.Messages)
        {
            if (msg.ContentType == "xml")
                asyncResult.Context.Response.ContentType = "text/xml";
            else
                asyncResult.Context.Response.ContentType = "text/html";
            asyncResult.Context.Response.Write(msg.Content);

        }
    }

    public bool SendMessage(Message msg)
    {
        bool flag = false;
        foreach (WaitRequest request in waitThread.Requests)
        {
            if (request.RequestID == msg.Destination || msg.Destination == "*" || (msg.Destination == "#" && request.RequestID.StartsWith("bs")))
            {
                request.Result.Messages.Add(msg);
                flag = true;
            }
        }
        return flag;
    }

    public WaitRequest GetRequestByID(string requestID)
    {
        WaitRequest request = null;
        foreach (WaitRequest re in waitThread.Requests)
        {
            if (re.RequestID == requestID)
            {
                request = re;
                break;
            }
        }
        return request;
    }
}
