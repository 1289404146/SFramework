using System;
using UnityEngine;

/// <summary>
/// 时间工具类
/// </summary>
public static class TimerTools
{
    /// <summary>
    /// 获取当前的时间戳(秒)
    /// </summary>
    /// <returns></returns>
    public static long GetNowTime()
    {
        TimeSpan cha = (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)));
        long t = (long)cha.TotalSeconds;
        return t;
    }
    
    /// <summary>
    /// 获取两个时间戳时间间隔（单位秒）
    /// </summary>
    /// <param name="timestapMax">时间戳1(10位)</param>
    /// <param name="timestapMin">时间戳2(10位)</param>
    /// <returns></returns>
    public static int GetSecondInterval(long timestapMax, long timestapMin)
    {
        //Debug.Log("时间戳间隔:    " + timestapMax + "        " + timestapMin);
        int resultTime = (int)Mathf.Round((float)((timestapMax - timestapMin)));
        return resultTime;
    }
    
    /// <summary>
    /// 计时时间转 00:00格式
    /// </summary>
    /// <param name="time">转换时间</param>
    /// <param name="showHour">显示小时</param>
    /// <returns></returns>
    public static string TimerIntToString(int time, bool showHour = false)
    {
        if (showHour)
        {
            return (time / 3600 > 9 ? "" : "0") + time / 3600 + ":" + ((time % 3600) / 60 > 9 ? "" : "0") +
                   (time % 3600) / 60 + ":" + (time % 60 > 9 ? "" : "0") + time % 60;
        }
        else
        {
            return (time / 60 > 9 ? "" : "0") + time / 60 + ":" + (time % 60 > 9 ? "" : "0") + time % 60;
        }
    }


    /// <summary>
    /// 两个日期是否是同一天
    /// </summary>
    /// <param name="t1"></param>
    /// <param name="t2"></param>
    /// <returns></returns>
    public static bool IsOneDay(string DateTime1, string DateTime2)
    {
        DateTime t1 = Convert.ToDateTime(DateTime1);
        DateTime t2 = Convert.ToDateTime(DateTime2);
        Debug.Log(t1 + ".." + t2 + "---" + t1.Day + ".." + t2.Day);
        return (t1.Year == t2.Year && t1.Month == t2.Month && t1.Day == t2.Day);
    }


    #region 时间戳 和 DateTime 相互转换

    /// <summary>
    /// DateTime转换为Unix时间戳
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static long DateTimeToUnix(DateTime dateTime)
    {
        DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
        // 相差秒数
        long timeStamp = (long)(dateTime - startTime).TotalSeconds;
        Console.WriteLine();

        return timeStamp;
    }
    
    /// <summary>
    /// Unix时间戳转换为 DateTime
    /// </summary>
    /// <param name="unixTimeStamp"></param>
    /// <returns></returns>
    public static string UnixToDateTime(long unixTimeStamp)
    {
        //long unixTimeStamp = 1478162177;
        DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
        DateTime dt = startTime.AddSeconds(unixTimeStamp);
        Debug.Log(dt.ToString("yyyy/MM/dd HH:mm:ss:ffff"));
        return  dt.ToString("yyyy/MM/dd HH:mm:ss:ffff");
    }
    #endregion
   
}
