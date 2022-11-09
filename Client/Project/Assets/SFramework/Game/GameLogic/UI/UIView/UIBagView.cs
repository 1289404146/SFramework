using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class UIBagView : UIBaseView
{
    public GridLayoutGroup gridLayoutGroup;
    public GameObject content;
    public GameObject pre;
    public ToggleGroup toggleGroup;
    public Button backButton;




    public override void Init(Transform transform)
    {
        backButton = transform.Find("BackButton").GetComponent<Button>();
        pre = transform.Find("Toggle").gameObject;
        content = transform.Find("ScrollView/Viewport/Content").gameObject;
        toggleGroup = content.GetComponent<ToggleGroup>();
        gridLayoutGroup = transform.Find("ScrollView/Viewport/Content").GetComponent<GridLayoutGroup>();
        for (int i = 0; i < 100; i++)
        {
            GameObject game = GameObject.Instantiate(pre, content.transform);
            game.GetComponent<Toggle>().group = toggleGroup;
            game.SetActive(true);
            game.name = "Toggle" + i;
            game.GetComponent<Toggle>().interactable = true;
        }
    }
}
