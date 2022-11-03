using System;
using System.Collections.Generic;
using UnityEngine;


public class AttackRequest : BaseRequest
{
    public AttackRequest(RequestCode requestCode, ActionCode actionCode, Action<string> action)
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.Attack;
        Action = action;
    }
}

