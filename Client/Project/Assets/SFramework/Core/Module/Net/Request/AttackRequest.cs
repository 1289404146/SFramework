using System;
using System.Collections.Generic;
using UnityEngine;


public class AttackRequest : BaseRequest
{
    public AttackRequest(RequestCode requestCode, ActionCode actionCode, Action<string> action)
    {
       this.requestCode = RequestCode.Game;
       this.actionCode = ActionCode.Attack;
       this.Action = action;
    }
}

