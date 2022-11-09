using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StartGameRequest : BaseRequest
{
    public  StartGameRequest(RequestCode requestCode, ActionCode actionCode,Action<string> action)
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.StartGame;
        Action = action;
    }

}
