using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Scene
{
    Init=0,
    Empty,
    Game1,
    Game2,
    Game3
}

public class SceneManager : BaseMono,IManager
{
    public void Initilize()
    {
        Debug.Log("SceneManager------Initilize");

    }
    public void DeInitilize()
    {
        Debug.Log("SceneManager------DdInitilize");

    }
    void Start()
    {
        Test test = new Test();
        test.Initilize();
        test.DeInitilize();
        test.VirtialInitilize();
        test.VirtialDeInitilize();
    }

}
public class Test : Manager
{
    public override void Initilize()
    {
        Debug.Log("Initilize");
    }
    public override void VirtialInitilize()
    {
        base.VirtialInitilize();
        Debug.Log("VirtialInitilize");

    }
    public override void VirtialDeInitilize()
    {
        base.VirtialDeInitilize();
        Debug.Log("VirtialDeInitilize");
    }
    public override void DeInitilize()
    {
        Debug.Log("DeInitilize");
    }
}