using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
 
public class BuildAssetBundle: EditorWindow
{
    [MenuItem("Tools/打AB包")]
    public static void BuildAllAssetBundles()//进行打包
    {
        string dir = Application.streamingAssetsPath;
        //判断该目录是否存在
        if (Directory.Exists(dir) == false)
        {
            Directory.CreateDirectory(dir);
        }
        //参数一为打包到哪个路径，参数二压缩选项  参数三 平台的目标
        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
        AssetDatabase.Refresh();
        Debug.Log("AB打包完成");
    }
}

