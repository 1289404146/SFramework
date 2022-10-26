
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class ABHelper
{
    [MenuItem("Assets/SetSelectABName",false,0)]
    public static void CopyName()
    {
        UnityEngine.Object gameObject = Selection.activeObject;
        string name= gameObject.name;
        AssetImporter assetImporter = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(gameObject));
        assetImporter.assetBundleName = gameObject.name.ToLower()+".unity3d";
        AssetDatabase.Refresh();
    }

    [MenuItem("Assets/SetAllSelectABName", false, 0)]
    public static void CopyAllName()
    {
        UnityEngine.Object[] gameObject = Selection.objects;
        for (int i = 0; i < gameObject.Length; i++)
        {
            AssetImporter assetImporter = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(gameObject[i]));
            assetImporter.assetBundleName = gameObject[i].name.ToLower() + ".unity3d";
        }
        AssetDatabase.Refresh();
    }

    [MenuItem("GameObject/CopyPath", false, 0)]
    public static void CopyAllNamePath()
    {
       UnityEngine.Object[] objects = Selection.objects;
        if (objects.Length < 1)
            return;
        GameObject go = objects[0] as GameObject;
        if (!go)
            return;
        string path = go.name;
        Transform parent = go.transform.parent;
        while (parent)
        {
            path = string.Format("{0}/{1}", parent.name, path);
            parent = parent.parent;
        }
        Debug.Log(path);
        CopyString(path);
    }

    private static void CopyString(string path)
    {
        TextEditor te = new TextEditor();
        te.text = path;
        te.SelectAll();
        te.Copy();
    }
}
