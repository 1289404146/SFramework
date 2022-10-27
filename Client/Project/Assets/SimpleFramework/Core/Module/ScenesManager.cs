using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    Init=0,
    Empty,
    Game1,
    Game2,
    Game3
}

public class ScenesManager : BaseMono,IManager
{
    public void Initilize()
    {
        Debug.Log("SceneManager------Initilize");
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }
    public void DeInitilize()
    {
        Debug.Log("SceneManager------DdInitilize");
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }
    /// <summary>
    /// º‡Ã˝≥°æ∞ «∑Ò«–ªª
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="arg1"></param>
    private void SceneManager_sceneLoaded(Scene scene, UnityEngine.SceneManagement.LoadSceneMode arg1)
    {
        SceneType index = (SceneType)scene.buildIndex;
        switch (index)
        {
            case SceneType.Empty:
                Debug.Log("Emptyº”‘ÿ¡À");
                Main.mainObj.AddComponent<Empty>().Initilize();
                break;
            case SceneType.Game1:
                break;
            case SceneType.Game2:
                break;
            case SceneType.Game3:
                break;
            default:
                break;
        }
    }
    public void LoadScene(SceneType scenType)
    {
       UnityEngine.SceneManagement.SceneManager.LoadScene((int)scenType);
    }


}
