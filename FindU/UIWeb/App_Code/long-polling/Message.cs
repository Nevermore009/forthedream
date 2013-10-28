using System;
/// <summary>
///Message 的摘要说明
/// </summary>
public class Message
{
    private static long id = 0;
    public Message()
    {
        ID = (id++).ToString();
    }

    /// <summary>
    /// 消息ID
    /// </summary>
    public string ID { set; get; }

    /// <summary>
    /// 接收方
    /// </summary>
    public string Destination { set; get; }

    /// <summary>
    /// 发送方
    /// </summary>
    public string Source { set; get; }

    /// <summary>
    /// 内容
    /// </summary>
    public string Content { set; get; }

    /// <summary>
    /// 内容的类型
    /// </summary>
    public string ContentType { set; get; }

}
