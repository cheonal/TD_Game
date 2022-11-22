using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missleLauncher;
    BulidManager bulidManager;

    void Start()
    {
        bulidManager = BulidManager.instance;
        
    }
    public void SlectStandardTurret()
    {
        Debug.Log("1");
        bulidManager.SelectTurretToBulid(standardTurret);
    }
    public void SlectMissileLauncher()
    {
        Debug.Log("2");
        bulidManager.SelectTurretToBulid(missleLauncher);

    }   
}

