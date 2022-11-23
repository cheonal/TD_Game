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
    public GameObject BuildEffect;
    private TurretBlueprint turretToBuild;

    public bool CanBulid
    {
        get
        {
            return turretToBuild != null;
        }
    }
    public bool HasMoney
    {
        get
        {
            return PlayerStats.Money >= turretToBuild.cost;
        }
    }
    public void BulidTurretOn (Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not Money");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefabs, node.GetBulidPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = Instantiate(BuildEffect, node.GetBulidPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Tureet Bulid" + PlayerStats.Money);
    }
    public void SelectTurretToBulid(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
