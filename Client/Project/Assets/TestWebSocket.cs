using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class TestWebSocket : MonoBehaviour
{
    private void Start()
    {
        WebSocket();
    }

    public async void WebSocket()
    {
        try
        {
            ClientWebSocket ws = new ClientWebSocket();
            CancellationToken ct = new CancellationToken();
            Uri url = new Uri("ws://127.0.0.1:8080/v1/test/");
            await ws.ConnectAsync(url, ct);
            await ws.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("hello")), WebSocketMessageType.Binary, true, ct); //��������
            while (true)
            {
                var result = new byte[1024];
                await ws.ReceiveAsync(new ArraySegment<byte>(result), new CancellationToken());//��������
                var str = Encoding.UTF8.GetString(result, 0, result.Length);
                Debug.Log(str);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
