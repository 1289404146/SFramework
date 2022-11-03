//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;

//public class CreateRoomRequest :BaseRequest {

//    public CreateRoomRequest(RequestCode requestCode, ActionCode actionCode, Action<string> action)
//    {
//        requestCode = RequestCode.Game;
//        actionCode = ActionCode.CreateRoom;
//        Action = OnsResponse;
//    }

//    //public override void SendRequest()
//    //{
//    //    base.SendRequest("r");
//    //}
//    public void OnsResponse(string data)
//    {
//        //string[] strs = data.Split(',');
//        //ReturnCode returnCode = (ReturnCode)int.Parse(strs[0]);
//        //RoleType roleType = (RoleType)int.Parse(strs[1]);
//        //facade.SetCurrentRoleType(roleType);
//        //if (returnCode == ReturnCode.Success)
//        //{
//        //    roomPanel.SetLocalPlayerResSync();
//        //}
//    }
//}
