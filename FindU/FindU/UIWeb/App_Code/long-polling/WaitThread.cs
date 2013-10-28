using System.Collections.Generic;
using System.Threading;
using System;

/// <summary>
///WaitThread 的摘要说明
/// </summary>
public class WaitThread
{
    public List<WaitRequest> Requests { set; get; }

    private object state = new object();

    public WaitThread()
    {
        Requests = new List<WaitRequest>();
        Thread th = new Thread(new ThreadStart(WaitRequest_WaitCallback));
        th.IsBackground = false;
        th.Start();
    }

    public void AddRequest(WaitRequest request)
    {
        if (request != null)
            lock (this.state)
            {
                this.Requests.Add(request);
            }
    }

    public void RemoveRequest(WaitRequest request)
    {
        if (request != null)
            lock (this.state)
            {
                this.Requests.Remove(request);
            }
    }

    public List<string> GetRequestList()
    {
        List<string> list = new List<string>();
        lock (this.state)
        {
            foreach(WaitRequest w in Requests)
            {
                list.Add(w.RequestID);
            }
        }
        return list;
    }

    public void FinishRequest(WaitRequest request)
    {
        request.SetCompleted();
    }

    public void WaitRequest_WaitCallback()
    {
        while (true)
        {
            if (Requests.Count == 0)
            {
                Thread.Sleep(100);
            }
            else
            {
                lock (this.state)
                {
                    for (int i = 0; i < Requests.Count; i++)
                    {
                        if (DateTime.Now.Subtract(Requests[i].AddTime).TotalMilliseconds > Requests[i].TimeOut)
                        {
                            Message msg = new Message { Source = "server", Destination = Requests[i].RequestID, Content = "again" };
                            LongpollingHandle.ConnManager.SendMessage(msg);
                        }
                        else if (Requests[i].Result.Messages.Count <= 0)
                        {
                            continue;
                        }
                        FinishRequest(Requests[i]);
                        RemoveRequest(Requests[i]);
                    }
                }
            }
            Thread.Sleep(100);
        }
    }
}
