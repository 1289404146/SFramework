using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayRequest : BaseRequest
{

    private bool isStartPlaying = false;
    public StartPlayRequest(RequestCode requestCode, ActionCode actionCode, Action<string> action)
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.StartPlay;
        Action = action;
    }

}
