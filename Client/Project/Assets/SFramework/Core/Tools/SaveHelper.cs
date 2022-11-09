using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SaveKey
{
    public const string Name = "Name";
    public const string Age = "Age";
    public const string Sex = "Sex";
    public const string Level = "Level";
}
public class SaveHelper
{
    /// <summary>
    /// 设置Int类型
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void SetInt(string key,int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// 设置Float类型
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// 设置String类型
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// 获取Int
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static int GetInt(string key)
    {
        if (!PlayerPrefs.HasKey(key))
        {
            return default(int);
        }
        return PlayerPrefs.GetInt(key);
    }
    /// <summary>
    /// 获取float
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static float GetFloat(string key)
    {
        if (!PlayerPrefs.HasKey(key))
        {
            return default(float);
        }
        return PlayerPrefs.GetFloat(key);
    }
    /// <summary>
    /// 获取String
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string GetString(string key)
    {
        if (!PlayerPrefs.HasKey(key))
        {
            return default(string);
        }
        return PlayerPrefs.GetString(key);
    }
}
