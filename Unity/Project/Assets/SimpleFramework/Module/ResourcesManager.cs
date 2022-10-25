using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBase,IManager
{
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public T Load<T>(string name) where T :Object
    {
        T go = Resources.Load<T>(name);
        return go;
    }

    public void Initilize()
    {
        Debug.Log("ResourcesManager------Initilize");
    }

    public void DeInitilize()
    {
        Debug.Log("ResourcesManager------DeInitilize");
    }
}
