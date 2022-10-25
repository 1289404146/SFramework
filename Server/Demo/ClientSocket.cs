using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test04
{
    class ClientSocket
    {
        //记录当前通讯的客户端的编号和网络
        private static int CLIENT_BEGIN_ID = 1;
        public int clientID;
        public Socket socket;

        public ClientSocket(Socket socket)
        {
            this.clientID = CLIENT_BEGIN_ID;
            this.socket = socket;
            //每有一个客户端连入，编号就++
            ++CLIENT_BEGIN_ID;
        }

        /// <summary>
        /// 是否是连接状态
        /// </summary>
        public bool Connected => this.socket.Connected;

        //关闭与客户端的连接
        public void Close()
        {
            //如果客户端的网络连接不是空，就将它变为空
            if (socket != null)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                socket = null;
            }
        }

        //与客户端发送消息
        public void Send(string info)
        {
            //如果不为空就可以进行与客户端的消息发送
            if (socket != null)
            {
                try
                {
                    socket.Send(Encoding.UTF8.GetBytes(info));
                }
                catch (Exception e)
                {
                    Console.WriteLine("发送消息出错" + e.Message);
                    Close();
                }
            }
        }

        //接收客户端的发来的消息
        public void Receive()
        {
            //如果网络为空就进行返回
            if (socket == null)
                return;
            try
            {
                //如果传入的数据大于0
                if (socket.Available > 0)
                {
                    byte[] result = new byte[1024];
                    int receiveNum = socket.Receive(result);
                    //开启线程池一直监听客户端发来的消息
                    ThreadPool.QueueUserWorkItem(MsgHandle, Encoding.UTF8.GetString(result, 0, receiveNum));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("收发消息出错" + e.Message);
                Close();
            }
        }

        private void MsgHandle(object obj)
        {
            string str = obj as string;
            Console.WriteLine("收到客户端{0}发来的消息：{1}", this.socket.RemoteEndPoint, str);
        }
    }
}