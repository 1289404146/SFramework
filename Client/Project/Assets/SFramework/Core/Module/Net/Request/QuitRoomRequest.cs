using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitRoomRequest : BaseRequest
{
    public QuitRoomRequest(RequestCode requestCode, ActionCode actionCode,Action<string> action)
    {
        requestCode = RequestCode.Room;
        actionCode = ActionCode.QuitRoom;
        Action = action;
    }
}
