using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveRequest : BaseRequest
{
    public MoveRequest(RequestCode requestCode, ActionCode actionCode, Action<string> action)
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.Move;
        Action = action;
    }
}
