using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using UnityEngine;

public class TestHttp : MonoBehaviour
{
    private WebClient wc;
    private string url = "http://localhost:8079";
    private Thread thread;

    // Start is called before the first frame update
    void Start()
    {
        CreateWebClient();
        thread = new Thread(SendHttpMsg);
        Debug.Log("按K键发送消息");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ////异步
            //Action ac = SendHttpMsg;
            //ac.BeginInvoke(null, null);

            //同步
            SendHttpMsg();

            //线程
            //thread.Start();
        }
    }

    void CreateWebClient()
    {
        wc = new WebClient();
    }

    /// <summary>
    /// 向服务器发送消息
    /// </summary>
    void SendHttpMsg()
    {
        Debug.Log($"请求服务地址:{url}，时间：{DateTime.Now.ToString()}");
        //模拟一个json数据发送到服务端
        var data = new Data(1, "张三");
        var jsonModel = JsonConvert.SerializeObject(data);
        //发送到服务端并获得返回值
        byte[] returnInfo;
        try
        {
            returnInfo = wc.UploadData(url, Encoding.UTF8.GetBytes(jsonModel));
        }
        catch (Exception e)
        {
            Debug.LogError("url可能不对，或者远程服务器关闭，或者连接失败");
            Debug.LogError(e);
            return;
        }
        //把服务端返回的信息转成字符串
        var str = Encoding.UTF8.GetString(returnInfo);
        Debug.Log($"服务端返回信息：{str},时间：{DateTime.Now.ToString()}");
    }
}

class Data
{
    public Data(int id, string name)
    {
        this.ID = id;
        this.Name = name;
    }
    public int ID { get; set; }

    public string Name { get; set; }
}