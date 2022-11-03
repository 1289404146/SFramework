//using System;
//using System.Collections.Generic;
//using UnityEngine;
//public class GameOverRequest:BaseRequest
//{

//    public GameOverRequest(RequestCode requestCode, ActionCode actionCode, Action<string> action)
//    {
//        requestCode = RequestCode.Game;
//        actionCode = ActionCode.GameOver;
//        Action = OnRsesponse;
//    }
//    private bool isGameOver = false;
//    private ReturnCode returnCode;

//    //private void Update()
//    //{
//    //    if (isGameOver)
//    //    {
//    //        gamePanel.OnGameOverResponse(returnCode);
//    //        isGameOver = false;
//    //    }
//    //}
//    public void OnRsesponse(string data)
//    {
//        returnCode = (ReturnCode)int.Parse(data) ;
//        isGameOver = true;
//    }
//}
