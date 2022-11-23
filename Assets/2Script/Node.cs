using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positonOffset;

    [Header("Optioanl")]
    public GameObject turret;


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
        if (!bulidManager.CanBulid)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("cant - TODO: Display on screen.");
            return;
        }

        bulidManager.BulidTurretOn(this);



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
