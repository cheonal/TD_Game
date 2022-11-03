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

    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }
    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
