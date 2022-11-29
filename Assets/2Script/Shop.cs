using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missleLauncher;
    public TurretBlueprint LaserBeamer;
    BulidManager bulidManager;

    void Start()
    {
        bulidManager = BulidManager.instance;
        
    }
    public void SelectStandardTurret()
    {
        bulidManager.SelectTurretToBulid(standardTurret);
    }
    public void SelectMissileLauncher()
    {
        bulidManager.SelectTurretToBulid(missleLauncher);
    }   
    public void SelectLaserBeamer()
    {
        bulidManager.SelectTurretToBulid(LaserBeamer);
    }
}

