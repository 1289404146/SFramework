using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleData
{
    private const string PREFIX_PREFAB = "Prefabs/";

    public RoleType RoleType { get; set; }
    public UserData userdata { get; set; }

    public GameObject RolePrefab { get; private set; }
    public GameObject ArrowPrefab { get; private set; }
    public Vector3 SpawnPosition { get; private set; }
    public GameObject ExplostionEffect { get; private set; }
    public RoleData()
    { }
    public RoleData(RoleType roleType, string rolePath  , Transform spawnPos)
    {
        this.RoleType = roleType;
        this.RolePrefab = Main.ResourcesManager.Load<GameObject>(PREFIX_PREFAB + rolePath);
        //this.ArrowPrefab = Main.ResourcesManager.Load<GameObject>(PREFIX_PREFAB + arrowPath);
        //this.ExplostionEffect =Main.ResourcesManager.Load<GameObject>(PREFIX_PREFAB + explosionPath);
        //ArrowPrefab.GetComponent<Arrow>().explosionEffect = ExplostionEffect;
        this.SpawnPosition = spawnPos.position;
    }
    public RoleData(RoleType roleType, string rolePath, string arrowPath, string explosionPath, Transform spawnPos)
    {
        this.RoleType = roleType;
        this.RolePrefab = Main.ResourcesManager.Load<GameObject>(PREFIX_PREFAB + rolePath);
        this.ArrowPrefab = Main.ResourcesManager.Load<GameObject>(PREFIX_PREFAB + arrowPath);
        this.ExplostionEffect = Main.ResourcesManager.Load<GameObject>(PREFIX_PREFAB + explosionPath);
        //ArrowPrefab.GetComponent<Arrow>().explosionEffect = ExplostionEffect;
        this.SpawnPosition = spawnPos.position;
    }
}
