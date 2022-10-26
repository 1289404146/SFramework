using UnityEngine;

public abstract class UIBaseLogic :BaseMono
{
    //层级字段，根据层级设置父节点
    public UILayer uiLayer;
    //UI类型字段
    public string uiType;


    //面板进入时调用
    public virtual void OnEnter()
    {
        //设置父节点
        transform.SetParent(Main.UIManager.dicLayer[uiLayer]);
    }

    //面板停止时调用（鼠标与面板的交互停止）
    public virtual void OnPause()
    {
    }

    //面板恢复使用时调用（鼠标与面板的交互恢复）
    public virtual void OnResume()
    {
    }

    //面板退出时调用
    public virtual void OnExit()
    {
    }
}
