using FairyGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PackageName
{
    public const string Hotfix = "Hotfix";
    public const string Runtime = "Runtime";
}
public class FUIPackageManager : BaseMono, IManager
{

    public const string FUI_PACKAGE_DIR = "Assets/Resources/FUI/";
    public void Initilize()
    {
        AddPackage(PackageName.Hotfix);
        AddPackage(PackageName.Runtime);
    }
    //记录包是否Add的字典
    private Dictionary<string, bool> packageAddDict = new Dictionary<string, bool>();

    /// <summary>
    /// 将一个UI包add进来
    /// </summary>
    /// <param name="packageName">UI包名</param>
    public void AddPackage(string packageName)
    {
        if (!CheckPackageHaveAdd(packageName))
        {
            UIPackage.AddPackage(FUI_PACKAGE_DIR + packageName);
        }
    }

    /// <summary>
    /// 检查UI包是否已经包进来
    /// </summary>
    /// <param name="packageName">UI包名</param>
    public bool CheckPackageHaveAdd(string packageName)
    {
        return packageAddDict.ContainsKey(packageName);
    }

    /// <summary>
    /// 清理没有用到的UI包
    /// </summary>
    public void ClearNotUsePackage()
    {
        //*****************************
    }
    public void RemovePackage(string packageName)
    {
        if (CheckPackageHaveAdd(packageName))
        {
            UIPackage.RemovePackage(FUI_PACKAGE_DIR + packageName);
        }
    }

    public void DeInitilize()
    {
        RemovePackage(PackageName.Hotfix);
        RemovePackage(PackageName.Runtime);
    }
}
