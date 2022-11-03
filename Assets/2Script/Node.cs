using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positonOffset;
    private GameObject turret;


    private Renderer rend;
    private Color startcolor;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("cant - TODO: Display on screen.");
            return;
        }

        GameObject turretToBulid = BulidManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBulid, transform.position + positonOffset, transform.rotation);



    }
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    void OnMouseExit()
    {
        rend.material.color = startcolor;
    }
}
