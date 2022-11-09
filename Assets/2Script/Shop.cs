using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BulidManager bulidManager;

    void Start()
    {
        bulidManager = BulidManager.instance;
        
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("1");
        bulidManager.SetTurretBulid(bulidManager.standardTurretPrefab);
    }
    public void PurchaseMissileLauncher()
    {
        Debug.Log("2");
        bulidManager.SetTurretBulid(bulidManager.missileLauncherPrefab);

    }   
}

