using System;
using System.Net.Sockets;

public abstract class AMHandler<Message> : IMHandler where Message : class
{
    public Type GetMessageType()
    {
        return typeof(Message);
    }

    public void Handle(ClientManager socket, object msg)
    {
        Message message = msg as Message;
        if (message == null)
        {
            Log.Error($"消息类型转换错误: {msg.GetType().Name} to {typeof(Message).Name}");
        }
        try
        {
            this.Run(socket, message);
        }
        catch (Exception e)
        {
            Log.Error(e);
        }
    }
    protected abstract void Run(ClientManager socket,Message message);
}
