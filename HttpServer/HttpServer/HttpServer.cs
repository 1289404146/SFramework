//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//class HttpServer
//{
//    private HttpListener listener = new HttpListener();
//    private Dictionary<string, Action<string>> actionDict = new Dictionary<string, Action<string>>();
//    private MyData mydata;

//    public void AddPrefixes(string url, Action<string> action)
//    {
//        actionDict.Add(url, action);
//    }

//    //开始监听
//    public void Start(int port)
//    {
//        if (!HttpListener.IsSupported)
//        {
//            Console.WriteLine("无法在当前系统上运行服务(Windows XP SP2 or Server 2003)。" + DateTime.Now.ToString());
//            return;
//        }

//        if (actionDict.Count <= 0)
//        {
//            System.Console.WriteLine("没有监听端口");
//        }

//        foreach (var item in actionDict)
//        {
//            var url = string.Format("http://127.0.0.1:{0}{1}", port, item.Key + "/");
//            System.Console.WriteLine(url);
//            listener.Prefixes.Add(url);  //监听的是以item.Key + "/"+XXX接口

//        }

//        listener.Start();
//        listener.BeginGetContext(Result, null);
//        mydata = new MyData();


//        System.Console.WriteLine("开始监听");
//        System.Console.Read();
//    }


//    private void Result(IAsyncResult asy)
//    {
//        listener.BeginGetContext(Result, null);
//        var context = listener.EndGetContext(asy);
//        var req = context.Request;
//        var rsp = context.Response;

//        // 
//        rsp.StatusCode = 200;
//        rsp.ContentType = "text/plain;charset=UTF-8";//告诉客户端返回的ContentType类型为纯文本格式，编码为UTF-8
//        rsp.AddHeader("Content-type", "text/plain");//添加响应头信息
//        rsp.ContentEncoding = Encoding.UTF8;
//        //对接口所传数据处理
//        HandleHttpMethod(context);
//        //对接口处理
//        HandlerReq(req.RawUrl);
//        try
//        {
//            using (var stream = rsp.OutputStream)
//            {
//                ///获取数据，要返回给接口的
//                string data = mydata.GetMyData();
//                byte[] dataByte = Encoding.UTF8.GetBytes(data);
//                stream.Write(dataByte, 0, data.Length);
//            }
//        }
//        catch (Exception e)
//        {
//            rsp.Close();
//            System.Console.WriteLine(e);

//        }
//        rsp.Close();

//    }

//    /// <summary>
//    /// 对客户端来的url处理
//    /// </summary>
//    /// <param name="url"></param>
//    private void HandlerReq(string url)
//    {
//        try
//        {
//            System.Console.WriteLine("url : " + url);

//            foreach (var item in actionDict.Keys)
//            {
//                System.Console.WriteLine(item);
//            }

//            string subUrl = url.Substring(1);
//            int urlIndex = subUrl.IndexOf("/");
//            subUrl = url.Substring(0, urlIndex + 1);
//            Console.WriteLine(subUrl);
//            var action = actionDict[subUrl];
//            action(url);
//        }
//        catch (Exception e)
//        {
//            System.Console.WriteLine(e);
//        }
//    }
//    //处理接口所传数据 Post和Get
//    private void HandleHttpMethod(HttpListenerContext context)
//    {
//        if (context.Request.ContentType != "text/plain")
//        {
//            Console.WriteLine("参数格式错误");
//            return;
//        }
//        switch (context.Request.HttpMethod)
//        {
//            case "POST":

//                string contextLength = context.Request.Headers.GetValues("Content-Length")[0];

//                using (Stream stream = context.Request.InputStream)
//                {
//                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
//                    string content = reader.ReadToEnd();
//                    System.Console.WriteLine(content);
//                    int length = content.Length;
//                    ///解析  接口所传数据
//                }
//                break;
//            case "GET":
//                var data = context.Request.QueryString;
//                break;
//        }
//    }

//}
