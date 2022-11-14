//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//class MyData
//{

//    /// <summary>
//    /// 获取数据
//    /// </summary>
//    /// <returns></returns>
//    public string GetMyData()
//    {
//        return "cesh";
//    }

//    private static string data;
//    /// <summary>
//    /// 获取数据
//    /// </summary>
//    /// <returns></returns>

//    public string GetMydData()
//    {
//        new Task(() =>
//        {
//            Invoke();
//        }).Start();
//        Console.WriteLine("我是主线程");

//        if (data == null) return null;
//        return data;
//    }

//    public static async Task<string> Invoke()
//    {
//        var result = GetPostLoad();
//        data = await result;  //等待返回
//        Console.WriteLine(data);  //输出返回
//        return data;
//    }

//    public static async Task<string> GetPostLoad()
//    {
//        HttpWebRequest request = WebRequest.Create("http:/*****************") as HttpWebRequest;
//        request.Method = "POST";
//        request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";     //这里一定不要忘记了 我排查了好久 发现这里没有写这一句  弄的怀疑人生了 后来通过抓包对比 才发现这个差距  粗心了
//        string data = "userId=123&agentId=456&companyId=789&versionTime=165665430918";
//        byte[] buf = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(data);
//        request.ContentLength = buf.Length;
//        Stream newStream = request.GetRequestStream();
//        newStream.Write(buf, 0, buf.Length);
//        newStream.Close();
//        HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;
//        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
//        string result = reader.ReadToEnd();
//        return result;
//    }

//}
