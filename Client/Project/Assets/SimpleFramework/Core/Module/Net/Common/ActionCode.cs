using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 请求的时候发送，请求码和请求事件，返回的接受返回事件和返回错误码
/// </summary>
public enum ActionCode
{
    None,
    Login,
    Register,
    ListRoom,
    CreateRoom,
    JoinRoom,
    UpdateRoom,
    QuitRoom,
    StartGame,
    ShowTimer,
    StartPlay,
    Move,
    Shoot,
    Attack,
    GameOver,
    UpdateResult,
    QuitBattle
}
