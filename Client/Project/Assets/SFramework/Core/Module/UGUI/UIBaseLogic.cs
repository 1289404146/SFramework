using UnityEngine;

public abstract class UIBaseLogic :BaseMono
{
    //�㼶�ֶΣ����ݲ㼶���ø��ڵ�
    public UILayer uiLayer;
    //UI�����ֶ�
    public string uiType;
    public virtual void OnInit()
    {
        
    }
    public virtual void DeInit()
    {

    }

}
