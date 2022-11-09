using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{

    private Text username;
    private Text totalCount;
    private Text winCount;
    private Button joinButton;

    private int id;

    // Use this for initialization
    void Awake()
    {
        username = transform.Find("UserName").GetComponent<Text>();
        totalCount = transform.Find("TotalCount").GetComponent<Text>();
        winCount = transform.Find("WinCount").GetComponent<Text>();
        joinButton = transform.Find("JoinButton").GetComponent<Button>();

    }
    public void SetRoomInfo(int id, string username, int totalCount, int winCount)
    {
        SetRoomInfo(id, username, totalCount.ToString(), winCount.ToString());
    }
    public void SetRoomInfo(int id, string username, string totalCount, string winCount )
    {
        this.id = id;
        this.username.text = username;
        this.totalCount.text = "总场数\n" + totalCount;
        this.winCount.text = "胜利\n" + winCount;
        if (joinButton != null)
        {
            joinButton.onClick.AddListener(()=> { OnJoinClick(id); });
        }
    }

    private void OnJoinClick(int id)
    {
        Main.ClientManager.SendRequest(RequestCode.Room,ActionCode.JoinRoom,id.ToString());
    }

    public void DestroySelf()
    {
        GameObject.Destroy(this.gameObject);
    }
}
