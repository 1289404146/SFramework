using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

public class ServerManager : EditorWindow
{
    [MenuItem("Tools/打开服务器")]
    public static void GenerateUI()
    {
        try
        {
            string path = @"G:\github\SFramework\Server\Server\bin\Debug\net6.0\Server.exe";

            ProcessHelper.Run(path, null);
            UnityEngine.Debug.Log("Seccess");
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.Log("执行失败 错误原因:" + ex.Message);
        }
    }
}