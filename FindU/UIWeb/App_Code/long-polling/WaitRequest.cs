using System;
using System.Web;
using System.Runtime.Remoting.Messaging;

/// <summary>
///WaitRequest 的摘要说明
/// </summary>
public class WaitRequest
{
    public string RequestID { set; get; }

    private DateTime addTime = DateTime.Now;
    public DateTime AddTime { get { return addTime; } }

    private int timeOut = 3000;
    public int TimeOut
    {
        get { return timeOut; }
        set { timeOut = value; }
    }

    private AsyncResult result;
    public AsyncResult Result { get { return result; } }

    public WaitRequest()
    {
    }
    public WaitRequest(HttpContext context, AsyncCallback callback, object asyncState)
    {
        RequestID = context.Request["IMEI"];
        result = new AsyncResult(context, callback, asyncState);
    }

    public void SetCompleted()
    {
        result.SetCompleted();
    }
}
