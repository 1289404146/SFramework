using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class UIMessageLogic : UIBaseLogic
{
    public UIMessageView uiView;
    public Queue<string> qStr;
    public UIMessageLogic()
    {
        uiType = UIType.UIMessage;
        uiLayer = UILayer.Top;
    }

    private void Awake()
    {
        qStr = new Queue<string>();
        uiView = new UIMessageView();
        uiView.Init(transform);
    }
    private IEnumerator DestroyMessage()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

    public void SetText(string str)
    {
        uiView.text.text = str;
        Debug.LogError(str);
        gameObject.SetActive(true);
        StartCoroutine(DestroyMessage());
    }
}
