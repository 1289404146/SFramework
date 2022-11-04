using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Diagnostics;

public class GenerateProtol : EditorWindow
{
    [MenuItem("Tools/生成Protol")]
    public static void GenerateUI()
    {
        try
        {
            //bat文件路径
            string path = @"E:\Demo\SimpleFM\protoc-21.9-win64\bin\Generate.bat";
            Process pro = new Process();
            FileInfo file = new FileInfo(path);
            pro.StartInfo.WorkingDirectory = file.Directory.FullName;
            pro.StartInfo.FileName = path;
            pro.StartInfo.CreateNoWindow = false;
            pro.Start();
            pro.WaitForExit();
            //MessageBox.Show("bat文件执行成功！");
            UnityEngine.Debug.Log("Seccess");
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.Log("执行失败 错误原因:" + ex.Message);
        }
    }
}
