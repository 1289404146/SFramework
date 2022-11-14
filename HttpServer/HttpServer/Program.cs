﻿using Fleck;
using System.Net;
using System.Text;

static class Program
{
    /// <summary>
    /// 应用程序的主入口点。
    /// </summary>
    static void Main()
    {
        FleckLog.Level = LogLevel.Debug;
        var allSockets = new List<IWebSocketConnection>();
        var server = new WebSocketServer("ws://192.168.0.107:8088");
        server.Start(socket =>
        {
            socket.OnOpen = () =>
            {
                Console.WriteLine(DateTime.Now + "  hello2,Open");
                Console.WriteLine("Open!");
                allSockets.Add(socket);
            };
            socket.OnClose = () =>
            {
                Console.WriteLine(DateTime.Now + "  hello2,Close");
                Console.WriteLine("Close!");
                allSockets.Remove(socket);
            };
            socket.OnMessage = message =>
            {
                Console.WriteLine(DateTime.Now + "  hello2,Close,Echo");
                Console.WriteLine(message);
                allSockets.ToList().ForEach(s => s.Send("Echo: " + message));
            };
        });

        var input = Console.ReadLine();

        while (input != "exit")
        {
            foreach (var socket in allSockets.ToList())
            {
                socket.Send(input);
            }
            input = Console.ReadLine();
        }
        //HttpServer httpServer = new HttpServer();

        //httpServer.AddPrefixes("/test", (value) => {
        //    System.Console.WriteLine("test" + value);
        //});

        //httpServer.AddPrefixes("/vac", (value) => {
        //    System.Console.WriteLine("vac" + value);

        //});
        //httpServer.Start(8080);
    }
}


//internal class Program
//{
//    static HttpListener httpobj;
//    public static void Main(string[] args)
//    {
//        //提供一个简单的、可通过编程方式控制的 HTTP 协议侦听器。此类不能被继承。
//        httpobj = new HttpListener();
//        //定义url及端口号，通常设置为配置文件
//        //httpobj.Prefixes.Add("http://+:8089/");
//        httpobj.Prefixes.Add("http://localhost:8079/");


//        //启动监听器
//        httpobj.Start();
//        //异步监听客户端请求，当客户端的网络请求到来时会自动执行Result委托
//        //该委托没有返回值，有一个IAsyncResult接口的参数，可通过该参数获取context对象
//        httpobj.BeginGetContext(Result, null);
//        Console.WriteLine($"服务端初始化完毕，正在等待客户端请求,时间：{DateTime.Now.ToString()}\r\n");
//        Console.ReadKey();
//    }

//    private static void Result(IAsyncResult ar)
//    {
//        //当接收到请求后程序流会走到这里

//        //继续异步监听
//        httpobj.BeginGetContext(Result, null);
//        var guid = Guid.NewGuid().ToString();
//        Console.ForegroundColor = ConsoleColor.White;
//        Console.WriteLine($"接到新的请求:{guid},时间：{DateTime.Now.ToString()}");
//        //获得context对象
//        var context = httpobj.EndGetContext(ar);
//        var request = context.Request;
//        var response = context.Response;
//        ////如果是js的ajax请求，还可以设置跨域的ip地址与参数
//        //context.Response.AppendHeader("Access-Control-Allow-Origin", "*");//后台跨域请求，通常设置为配置文件
//        //context.Response.AppendHeader("Access-Control-Allow-Headers", "ID,PW");//后台跨域参数设置，通常设置为配置文件
//        //context.Response.AppendHeader("Access-Control-Allow-Method", "post");//后台跨域请求设置，通常设置为配置文件
//        context.Response.ContentType = "text/plain;charset=UTF-8";//告诉客户端返回的ContentType类型为纯文本格式，编码为UTF-8
//        context.Response.AddHeader("Content-type", "text/plain");//添加响应头信息
//        context.Response.ContentEncoding = Encoding.UTF8;
//        string returnObj = null;//定义返回客户端的信息
//        if (request.HttpMethod == "POST" && request.InputStream != null)
//        {
//            //处理客户端发送的请求并返回处理信息
//            returnObj = HandleRequest(request, response);
//        }
//        else
//        {
//            returnObj = $"不是post请求或者传过来的数据为空";
//        }
//        var returnByteArr = Encoding.UTF8.GetBytes(returnObj);//设置客户端返回信息的编码
//        try
//        {
//            using (var stream = response.OutputStream)
//            {
//                //把处理信息返回到客户端
//                stream.Write(returnByteArr, 0, returnByteArr.Length);
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine($"网络蹦了：{ex.ToString()}");
//        }
//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine($"请求处理完成：{guid},时间：{DateTime.Now.ToString()}\r\n");
//    }

//    private static string HandleRequest(HttpListenerRequest request, HttpListenerResponse response)
//    {
//        string data = null;
//        try
//        {
//            var byteList = new List<byte>();
//            var byteArr = new byte[2048];
//            int readLen = 0;
//            int len = 0;
//            //接收客户端传过来的数据并转成字符串类型
//            do
//            {
//                readLen = request.InputStream.Read(byteArr, 0, byteArr.Length);
//                len += readLen;
//                byteList.AddRange(byteArr);
//            } while (readLen != 0);
//            data = Encoding.UTF8.GetString(byteList.ToArray(), 0, len);

//            //获取得到数据data可以进行其他操作
//        }
//        catch (Exception ex)
//        {
//            response.StatusDescription = "404";
//            response.StatusCode = 404;
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine($"在接收数据时发生错误:{ex.ToString()}");
//            return $"在接收数据时发生错误:{ex.ToString()}";//把服务端错误信息直接返回可能会导致信息不安全，此处仅供参考
//        }
//        response.StatusDescription = "200";//获取或设置返回给客户端的 HTTP 状态代码的文本说明。
//        response.StatusCode = 200;// 获取或设置返回给客户端的 HTTP 状态代码。
//        Console.ForegroundColor = ConsoleColor.Green;
//        Console.WriteLine($"接收数据完成:{data.Trim()},时间：{DateTime.Now.ToString()}");
//        return $"接收数据完成";
//    }
//}
