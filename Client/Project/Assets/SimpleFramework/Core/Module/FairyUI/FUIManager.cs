using DCET.Hotfix;
using FairyGUI;
using System.Collections.Generic;
public class FUIInfo
{
    private string _packName;
    private string _dialogName;

    public FUIInfo(string packName, string dialogName)
    {
        _packName = packName;
        _dialogName = dialogName;
    }

    public string GetFUIPackageName()
    {
        return _packName;
    }

    public string GetFUIName()
    {
        return _dialogName;
    }
}
/// <summary>
/// 管理所有顶层UI, 顶层UI都是GRoot的孩子
/// </summary>
public class FUIManager : BaseMono,IManager
{
    private Dictionary<string, BaseFUI> fuiBaseDict = new Dictionary<string, BaseFUI>();
    private Dictionary<string, FUIInfo> fuiInfoDict=new Dictionary<string, FUIInfo>();
    public void Initilize()
    {
        InitFUIConfig();
    }
    /// <summary>
    /// 打开界面
    /// </summary>
    public void OpenFUI(string fuiTppe)
    {
        FUIInfo dialogInfo = GetFUIInfo(fuiTppe);
        Main.FUIPackageManager.AddPackage(dialogInfo.GetFUIPackageName());
        GComponent view = UIPackage.CreateObject(dialogInfo.GetFUIPackageName(), dialogInfo.GetFUIName()) as GComponent;
        view.SetSize(GRoot.inst.width, GRoot.inst.height);
        GRoot.inst.AddChild(view);
        fuiBaseDict[fuiTppe] = GetFUIComponent(fuiTppe);
        fuiBaseDict[fuiTppe].SetDialogView(view);
        fuiBaseDict[fuiTppe].OnBeforeCreate();
        fuiBaseDict[fuiTppe].AddListener();
        fuiBaseDict[fuiTppe].OnCreate();
        fuiBaseDict[fuiTppe].OnRefresh();
    }
    /// <summary>
    /// 关闭界面
    /// </summary>
    public void CloseFUI(string fuiTyoe)
    {
        if (fuiBaseDict.ContainsKey(fuiTyoe))
        {
            fuiBaseDict[fuiTyoe].RemoveListener();
            fuiBaseDict[fuiTyoe].OnHide();
            fuiBaseDict[fuiTyoe].OnDestory();
            fuiBaseDict[fuiTyoe].GetView().Dispose();
            fuiBaseDict.Remove(fuiTyoe);
        }
    }
    private void InitFUIConfig()
    {
        fuiInfoDict = new Dictionary<string, FUIInfo>();
        fuiInfoDict[FUIType.UILogin] = new FUIInfo("Hotfix", "Login");
        fuiInfoDict[FUIType.UILobby] = new FUIInfo("Hotfix", "Lobby");
    }

    public FUIInfo GetFUIInfo(string fuiTppe)
    {
        return fuiInfoDict[fuiTppe];
    }

    public BaseFUI GetFUIComponent(string fuiTppe)
    {
        switch (fuiTppe)
        {
            case FUIType.UILobby:
                return new FUILobbyComponent() ;
            case FUIType.UILogin:
                return new FUILoginComponent();
            default:
                return null;
        }
    }

    public void DeInitilize()
    {
    }
}

