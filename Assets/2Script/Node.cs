using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positonOffset;
    private GameObject turret;


    private Renderer rend;
    private Color startcolor;
    BulidManager bulidManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;
        bulidManager = BulidManager.instance;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (bulidManager.GetTurretToBuild() == null)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("cant - TODO: Display on screen.");
            return;
        }

        GameObject turretToBulid = bulidManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBulid, transform.position + positonOffset, transform.rotation);



    }
    void OnMouseEnter()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (bulidManager.GetTurretToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }
    void OnMouseExit()
    {
        rend.material.color = startcolor;
    }
}
