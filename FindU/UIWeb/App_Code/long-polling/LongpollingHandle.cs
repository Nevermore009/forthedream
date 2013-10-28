using System;
using System.Web;
using System.Web.SessionState;

/// <summary>
///
/// </summary>
public class LongpollingHandle : IHttpAsyncHandler
{
     static LongpollingHandle()
    {
        connManager = new ConnectionManager();
    }

    private static ConnectionManager connManager;

    public static ConnectionManager ConnManager
    {
        get { return connManager; }
    }

    #region IHttpAsyncHandler Members

    public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
    {
        return connManager.BeginSubscribe(context, cb, extraData);
    }

    public void EndProcessRequest(IAsyncResult result)
    {
        connManager.EndSubscribe(result);
    }

    #endregion

    #region IHttpHandler Members

    public bool IsReusable
    {
        get { return true; }
    }

    public void ProcessRequest(HttpContext context)
    {
        throw new NotImplementedException();
    }

    #endregion
}
