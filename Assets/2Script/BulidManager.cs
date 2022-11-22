using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulidManager : MonoBehaviour
{
    public static BulidManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    private TurretBlueprint turretToBuild;

    public bool CanBulid
    {
        get
        {
            return turretToBuild != null;
        }
    }
    public void BulidTurretOn (Node node)
    {
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefabs, node.GetBulidPosition(), Quaternion.identity);
        node.turret = turret;
    }
    public void SelectTurretToBulid(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
