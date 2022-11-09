using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    Init=0,
    start,
    gameing,
    end,
    DeInit
}
public class GameManager : BaseMono
{
    public UserData UserData;
    public GameState CurrentState;
    private void Awake()
    {
        CurrentState = GameState.Init;
        UpdateState(CurrentState);
    }
    public void SwitchGameState(GameState newState)
    {
        if (CurrentState == newState)
        {
            return;
        }
        else
        {
            CurrentState = newState;
        }
        UpdateState(CurrentState);
    }
    private void UpdateState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Init:
                Debug.Log("游戏初始化");
                break;
            case GameState.start:
                Debug.Log("游戏开始");
                break;
            case GameState.gameing:
                Debug.Log("开始中");
                break;
            case GameState.end:
                Debug.Log("游戏结束");
                break;
            case GameState.DeInit:
                Debug.Log("游戏销毁");
                break;
            default:
                break;
        }
    }
    private void OnDestroy()
    {
        CurrentState = GameState.DeInit;
    }
}
