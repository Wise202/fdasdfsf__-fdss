using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller : MonoBehaviour
{
    public Rigidbody missilePrefab;
    public Transform cannonTop;
    public Vector3 mousePos;
    private bool mouseClicked;
    public GameObject missileDestroy;

    public int missileAmmo = 20;
    void Start()
    {
        
    }

    void Update()
    {
        LookAtMouse();
        FireMissile();
    }

    void LookAtMouse()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
    void FireMissile()
    {
        if (missileAmmo > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Rigidbody missileInstance;
                missileInstance = Instantiate(missilePrefab, cannonTop.position, cannonTop.rotation) as Rigidbody;
                missileInstance.AddForce(cannonTop.forward * 3000);

                missileAmmo--;
            }
            if (Input.GetMouseButtonDown(0) && mouseClicked == false)
            {
                //Instantiate(missileDestroy);
                mouseClicked = true;
                mousePos = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0) && mouseClicked == true)
            {
                mouseClicked = false;
            }
        }
        else
            return;
     
    }
}
