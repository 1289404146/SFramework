using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginRequest : BaseRequest
{
    public  LoginRequest(RequestCode requestCode, ActionCode actionCode,Action<string> action)
    {
        requestCode = RequestCode.User;
        actionCode = ActionCode.Login;
        Action = action;
    }
}
