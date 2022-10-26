using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class NetworkManager : BaseMono,IManager
{
    //客户端的Socket
    private Socket socket;

    //用于发送消息的队列 公共的容器（线程） 主线程往里面放 发送线程从里面取
    private Queue<string> sendMsgQueue = new Queue<string>();
    //用于接受消息的对象 公共容器（线程） 子线程往里面放 主线程从里面取
    private Queue<string> receiveQueue = new Queue<string>();

    //用于收消息的容器
    private byte[] receiveBytes = new byte[1024];
    //返回收到的字节数
    private int receiveNum;

    //是否连接
    private bool isConnected = false;
    private void Awake()
    {
       Connect("127.0.0.1", 8080);
    }

    private void Update()
    {
        //如果线程里面有消息，就进行输出
        if (receiveQueue.Count > 0)
        {
            print(receiveQueue.Dequeue());
        }
    }
    public void Connect(string ip, int port)
    {
        //如果是连接状态 直接返回
        if (isConnected)
            return;

        if (socket == null)
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //连接服务器
        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ip), port);

        try
        {
            socket.Connect(ipPoint);
            isConnected = true;

            //开启发送线程
            ThreadPool.QueueUserWorkItem(SendMsg);
            //开启接受线程
            ThreadPool.QueueUserWorkItem(ReceiveMsg);
        }
        catch (SocketException e)
        {
            if (e.ErrorCode == 10061)
                print("服务器拒绝连接");
            else
                print("连接失败" + e.ErrorCode + e.Message);
        }
    }

    //发送消息
    public void Send(string info)
    {
        sendMsgQueue.Enqueue(info);
    }

    private void SendMsg(object obj)
    {
        while (isConnected)
        {
            if (sendMsgQueue.Count > 0)
            {
                socket.Send(Encoding.UTF8.GetBytes(sendMsgQueue.Dequeue()));
            }
        }
    }

    //不停的接受消息
    private void ReceiveMsg(object obj)
    {
        while (isConnected)
        {
            if (socket.Available > 0)
            {
                receiveNum = socket.Receive(receiveBytes);
                //收到消息 解析消息为字符串 并放入公共容器
                receiveQueue.Enqueue(Encoding.UTF8.GetString(receiveBytes, 0, receiveNum));
            }
        }
    }

    public void Close()
    {
        //if (socket != null)
        //{
        //    socket.Shutdown(SocketShutdown.Both);
        //    socket.Close();

        //    isConnected = false;
        //}
    }
    private void OnDestroy()
    {
        Close();
    }

    public void Initilize()
    {
        Debug.Log("NetworkManager------Initilize");
    }

    public void DeInitilize()
    {
        Debug.Log("NetworkManager------DeInitilize");
    }
}

