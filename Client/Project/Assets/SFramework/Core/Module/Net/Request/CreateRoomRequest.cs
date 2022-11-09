using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreateRoomRequest : BaseRequest
{

    public CreateRoomRequest(RequestCode requestCode, ActionCode actionCode, Action<string> action)
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.CreateRoom;
        Action = action;
    }



}
