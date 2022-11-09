using System;
using System.Collections.Generic;
using UnityEngine;


public class TestRequest : BaseRequest
{
    public TestRequest(RequestCode requestCode, ActionCode actionCode, Action<byte[]> action)
    {
        this.requestCode = RequestCode.Test;
        this.actionCode = ActionCode.TestFun;
        this.ActionProtal = action;
    }
}

