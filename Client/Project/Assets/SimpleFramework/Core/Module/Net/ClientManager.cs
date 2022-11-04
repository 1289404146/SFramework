using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ClientManager : BaseMono,IManager
{
    private const string IP = "127.0.0.1";
    private const int PORT = 6688;

    private Socket clientSocket;
    private Message msg = new Message();

    public void Initilize()
    {
        Debug.Log("NetworkManager------Initilize");
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(IP, PORT);
            StartReceive();
            Debug.Log("登录成功，开始接受消息");
        }
        catch (Exception e)
        {
            Debug.LogWarning("无法连接到服务器端，请检查您的网络！！" + e);
        }
    }
    private void StartReceive()
    {
        clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.RemainSize, SocketFlags.None, ReceiveCallback, null);
    }
    private void ReceiveCallback(IAsyncResult ar)
    {
        try
        {
            if (clientSocket == null || clientSocket.Connected == false) return;
            int count = clientSocket.EndReceive(ar);

            msg.ReadMessage(count, OnProcessDataCallback);

            StartReceive();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    public void Update()
    {
        if (msgs.Count>0)
        {
            Msg msg= msgs.Dequeue();
            Main.RequestManager.HandleReponse(msg.code, msg.data);
        }
    }
    private void OnProcessDataCallback(ActionCode actionCode, string data)
    {
        msgs.Enqueue(new Msg() { code = actionCode, data = data });
    }
    public void SendRequest(RequestCode requestCode, ActionCode actionCode, string data)
    {
        byte[] bytes = Message.PackData(requestCode, actionCode, data);
        clientSocket.Send(bytes);
    }
    public void DeInitilize()
    {
        try
        {
            clientSocket.Close();
        }
        catch (Exception e)
        {
            Debug.LogWarning("无法关闭跟服务器端的连接！！" + e);
        }
        Debug.Log("NetworkManager------DeInitilize");
    }
    public Queue<Msg> msgs = new Queue<Msg>();
    public class Msg
    {
        public ActionCode code;
        public string data;
    }
}

