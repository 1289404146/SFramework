using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBase,IManager
{
    public Config ConfigContent;

    public void DeInitilize()
    {
        Debug.Log("ConfigManager------DeInitilize");

    }

    public void Initilize()
    {
        Debug.Log("ConfigManager------Initilize");

    }

    private void Awake()
    {
        ConfigContent = new Config("Player");
    }
    private void OnDestroy()
    {
        ConfigContent = null;
    }
}
public class Config
{
    public Dictionary<int, List<string>> players = new Dictionary<int,List<string>>();
    public Config(string name)
    {
        players.Clear();
        TextAsset ta1 = Resources.Load<TextAsset>("Config/"+name);
        string text1 = ta1.text;
        Debug.Log(text1);
        string[] lines1 = text1.Split('\n');
        foreach (string line in lines1)
        {
            if (line == null)
            {
                continue;
            }
            string[] keyAndValue = line.Split('=');
            string[] strs = new string[keyAndValue.Length - 1];
            Array.Copy(keyAndValue, 1, strs, 0, keyAndValue.Length - 1);
            players.Add(int.Parse(keyAndValue[0]), new List<string>(strs));
        }
    }

}
public class Player
{
    public string name;
    public int age;
}
