using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
class Game : BaseMono, IScene
{
    public void Initilize()
    {
        Debug.Log("Game_____Initilize");
        Debug.Log("初始化游戏");
        Main.UIManager.OpenPanel<UIGameStartLogic>(UIType.UIGameStart);
    }
    public void DeInitilize()
    {
        Debug.Log("Game_____DeInitilize");
        Main.UIManager.ClosePanel<UIGameStartLogic>(UIType.UIGameStart);
    }
}
