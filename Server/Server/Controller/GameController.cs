﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[ControllerAttribute(RequestCode.Game)]
class GameController : BaseController
{
    public GameController()
    {
        requestCode = RequestCode.Game;
    }
    public string StartGame(string data, Client client, Server server)
    {
        if (client.IsHouseOwner())
        {
            Room room = client.Room;
            room.BroadcastMessage(client, ActionCode.StartGame, ((int)ReturnCode.Success).ToString());
            room.StartTimer();
            return ((int)ReturnCode.Success).ToString();
        }
        else
        {
            return ((int)ReturnCode.Fail).ToString();
        }
    }

    public string Move(string data, Client client, Server server)
    {
        Room room = client.Room;
        if (room != null)
            room.BroadcastMessage(client, ActionCode.Move, data);
        return null;
    }
    public string Shoot(string data, Client client, Server server)
    {
        Room room = client.Room;
        if (room != null)
            room.BroadcastMessage(client, ActionCode.Shoot, data);
        return null;
    }
    public string Attack(string data, Client client, Server server)
    {
        int damage = int.Parse(data);
        Room room = client.Room;
        if (room == null) return null;
        room.TakeDamage(damage, client);
        return data;
    }
    public string QuitBattle(string data, Client client, Server server)
    {
        Room room = client.Room;

        if (room != null)
        {
            room.BroadcastMessage(null, ActionCode.QuitBattle, "r");
            room.Close();
        }
        return null;
    }
}
