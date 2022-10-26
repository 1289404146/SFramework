using UnityEngine;

public abstract class UIBaseLogic :BaseMono
{
    //�㼶�ֶΣ����ݲ㼶���ø��ڵ�
    public UILayer uiLayer;
    //UI�����ֶ�
    public string uiType;


    //������ʱ����
    public virtual void OnEnter()
    {
        //���ø��ڵ�
        transform.SetParent(Main.UIManager.dicLayer[uiLayer]);
    }

    //���ֹͣʱ���ã���������Ľ���ֹͣ��
    public virtual void OnPause()
    {
    }

    //���ָ�ʹ��ʱ���ã���������Ľ����ָ���
    public virtual void OnResume()
    {
    }

    //����˳�ʱ����
    public virtual void OnExit()
    {
    }
}
