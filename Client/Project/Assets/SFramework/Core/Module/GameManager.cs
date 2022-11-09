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
                Debug.Log("��Ϸ��ʼ��");
                break;
            case GameState.start:
                Debug.Log("��Ϸ��ʼ");
                break;
            case GameState.gameing:
                Debug.Log("��ʼ��");
                break;
            case GameState.end:
                Debug.Log("��Ϸ����");
                break;
            case GameState.DeInit:
                Debug.Log("��Ϸ����");
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
