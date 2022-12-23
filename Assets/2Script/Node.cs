using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positonOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgrade = false;


    private Renderer rend;
    private Color startcolor;
    BulidManager bulidManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;
        bulidManager = BulidManager.instance;
    }

    public Vector3 GetBulidPosition()
    {
        return transform.position + positonOffset;
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            bulidManager.SelectNode(this);
            return;
        }
        if (!bulidManager.CanBulid)
        {
            return;
        }
        BuildTurret(bulidManager.GetTurretToBulid());
    }

    void BuildTurret (TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not Money");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        turretBlueprint = blueprint;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefabs, GetBulidPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = Instantiate(bulidManager.BuildEffect, GetBulidPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Tureet Bulid");
    }
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not Money upgrade");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //기존 터렛 제거
        Destroy(turret);

        //업그레이드 된 터렛 배치
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradeprefabs, GetBulidPosition(), Quaternion.identity);
        turret = _turret;


        GameObject effect = Instantiate(bulidManager.BuildEffect, GetBulidPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgrade = true;
        Debug.Log("Tureet upgrade");
    }
    void OnMouseEnter()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!bulidManager.CanBulid)
        {
            return;
        }
        if (bulidManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }
    void OnMouseExit()
    {
        rend.material.color = startcolor;
    }
}
