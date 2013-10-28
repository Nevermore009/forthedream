using System;
using System.Web;
using System.Collections.Generic;
using System.Threading;

/// <summary>
///AsyncResult 的摘要说明
/// </summary>

public class AsyncResult : IAsyncResult
{
    private bool isComplete = false;
    private HttpContext context;
    public HttpContext Context
    {
        get { return context; }
    }
    private AsyncCallback callback;
    private object asyncState;

    public List<Message> Messages { set; get; }

    public AsyncResult(HttpContext context, AsyncCallback callback, object asyncState)
    {
        this.context = context;
        this.callback = callback;
        this.asyncState = asyncState;
        Messages = new List<Message>();
    }

    /// <summary>
    /// 完成异步处理，结束请求
    /// </summary>
    public void SetCompleted()
    {
        if (callback != null)
            callback(this);             //会触发处理程序中的EndProcessRequest函数，结束请求
        this.isComplete = true;
    }

    #region IAsyncResult成员

    public object AsyncState { get { return asyncState; } }

    public WaitHandle AsyncWaitHandle { get { throw new InvalidOperationException("ASP.NET Should never use this property"); } }

    public bool CompletedSynchronously { get { return false; } }

    public bool IsCompleted { get { return isComplete; } }

    #endregion
}
