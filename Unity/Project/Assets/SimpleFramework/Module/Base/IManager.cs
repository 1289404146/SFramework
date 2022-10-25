using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Manager
{
    public  abstract void Initilize();
    public abstract void DeInitilize();
    public virtual void VirtialInitilize()
    {
        Debug.Log("baseVirtialInitilize");
    }
    public virtual void VirtialDeInitilize()
    {
        Debug.Log("baseVirtialDeInitilize");
    }
}
 interface IManager
{
     void Initilize();
     void DeInitilize();
}
