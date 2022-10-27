using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
class Game : BaseMono, IScene
{
    public void DeInitilize()
    {
        Debug.Log("Game_____DeInitilize");
    }

    public void Initilize()
    {
        Debug.Log("Game_____Initilize");
    }
}
