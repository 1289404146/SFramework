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
        Debug.Log("��K��������Ϣ");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ////�첽
            //Action ac = SendHttpMsg;
            //ac.BeginInvoke(null, null);

            //ͬ��
            SendHttpMsg();

            //�߳�
            //thread.Start();
        }
    }

    void CreateWebClient()
    {
        wc = new WebClient();
    }

    /// <summary>
    /// �������������Ϣ
    /// </summary>
    void SendHttpMsg()
    {
        Debug.Log($"��������ַ:{url}��ʱ�䣺{DateTime.Now.ToString()}");
        //ģ��һ��json���ݷ��͵������
        var data = new Data(1, "����");
        var jsonModel = JsonConvert.SerializeObject(data);
        //���͵�����˲���÷���ֵ
        byte[] returnInfo;
        try
        {
            returnInfo = wc.UploadData(url, Encoding.UTF8.GetBytes(jsonModel));
        }
        catch (Exception e)
        {
            Debug.LogError("url���ܲ��ԣ�����Զ�̷������رգ���������ʧ��");
            Debug.LogError(e);
            return;
        }
        //�ѷ���˷��ص���Ϣת���ַ���
        var str = Encoding.UTF8.GetString(returnInfo);
        Debug.Log($"����˷�����Ϣ��{str},ʱ�䣺{DateTime.Now.ToString()}");
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