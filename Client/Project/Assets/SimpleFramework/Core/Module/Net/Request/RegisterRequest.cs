using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RegisterRequest : BaseRequest
{
    public RegisterRequest(RequestCode code, ActionCode actionCode,Action<string> OnResponse)
    {
        requestCode = RequestCode.User;
        actionCode = ActionCode.Register;
        this.Action = OnResponse;
    }
}
