using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ListRoomRequest : BaseRequest
{
    public ListRoomRequest(RequestCode requestCode, ActionCode actionCode,Action<string> action)
    {
        this. requestCode = RequestCode.Room;
       this. actionCode = ActionCode.ListRoom;
        this.Action = action;
    }
}
