using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UpdateRoomRequest : BaseRequest
{
    public UpdateRoomRequest(RequestCode requestCode, ActionCode actionCode,Action<string> action)
    {
        requestCode = RequestCode.Room;
        actionCode = ActionCode.UpdateRoom;
        Action = action;
    }
}
