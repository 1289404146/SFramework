using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RequestManager : BaseMono, IManager
{
    private Dictionary<ActionCode, BaseRequest> requestDict ;

    public void Initilize()
    {
        requestDict = new Dictionary<ActionCode, BaseRequest>();
        requestDict.Clear();
    }
    public void DeInitilize()
    {
        requestDict.Clear();
        requestDict = null;
    }

    public void AddRequest(ActionCode actionCode, BaseRequest request)
    {
        if (requestDict.ContainsKey(actionCode))
        {
            return;
        }
        requestDict.Add(actionCode, request);
    }
    public void RemoveRequest(ActionCode actionCode)
    {
        if (requestDict.ContainsKey(actionCode))
        {
            requestDict.Remove(actionCode);
        }
    }
    public void HandleReponse(ActionCode actionCode, string data)
    {
        BaseRequest request = requestDict.TryGet<ActionCode, BaseRequest>(actionCode);
        if (request == null)
        {
            Debug.LogWarning("无法得到ActionCode[" + actionCode + "]对应的Request类"); return;
        }
        request.OnResponse(data);
    }
    public void HandleProtalReponse(ActionCode actionCode, byte[] data)
    {
        BaseRequest request = requestDict.TryGet<ActionCode, BaseRequest>(actionCode);
        if (request == null)
        {
            Debug.LogWarning("无法得到ActionCode[" + actionCode + "]对应的Request类"); return;
        }
        request.OnResponseProtal(data);
    }

}
