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

    public GameObject BuildEffect;
    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

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
    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }


        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    public void SelectTurretToBulid(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;

        DeselectNode();
    }
    public TurretBlueprint GetTurretToBulid()
    {
        return turretToBuild;
    }
}
