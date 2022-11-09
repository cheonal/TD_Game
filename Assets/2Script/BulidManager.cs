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
    public GameObject anotherTurretPrefab;

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
    public void SetTurretBulid(GameObject turret)
    {
        turretToBuild = turret;
    }
}
