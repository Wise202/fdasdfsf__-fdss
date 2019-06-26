using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller : MonoBehaviour
{
    public Rigidbody missilePrefab;

    public Transform middleCannonTop;
    public Transform leftCannonTop;
    public Transform rightCannonTop;

    //public Rigidbody scatterMissile;

    public Vector3 mousePos;

    private bool mouseClicked;


    public GameObject missileDestroy;

           GameObject middleShooter;
           GameObject leftShooter;
           GameObject rightShooter;

    PlayerMissileClicker playMissileClicker;

    public int missileAmmo = 20;


    void Start()
    {
        playMissileClicker = FindObjectOfType<PlayerMissileClicker>();

        middleShooter = GameObject.FindGameObjectWithTag("MiddlePlayer");
        leftShooter = GameObject.FindGameObjectWithTag("LeftPlayer");
        rightShooter = GameObject.FindGameObjectWithTag("RightPlayer");

   
    }

    void Update()
    {
        LookAtMouse();

        //Check which missile launcher is closest to the cursor to trigger the closest launcher to fire.
        if(playMissileClicker.middlePlayerFire == true && playMissileClicker.leftPlayerFire == false && playMissileClicker.rightPlayerFire == false)
        {
            FireMiddleMissile();
        }
        if (playMissileClicker.leftPlayerFire == true && playMissileClicker.middlePlayerFire == false && playMissileClicker.rightPlayerFire == false)
        {
            FireLeftMissile();
        }
        if (playMissileClicker.rightPlayerFire == true && playMissileClicker.leftPlayerFire == false && playMissileClicker.middlePlayerFire == false)
        {
            FireRightMissile();
        }
    }

    void LookAtMouse()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
    void FireMiddleMissile()
    {
        if (missileAmmo > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Rigidbody missileInstance;
                missileInstance = Instantiate(missilePrefab, middleCannonTop.position, middleCannonTop.rotation) as Rigidbody;
                missileInstance.AddForce(middleCannonTop.forward * 3000);

                missileAmmo--;
                playMissileClicker.middlePlayerFire = false;
            }
            /*else if (Input.GetMouseButtonDown(1))
            {
                Rigidbody scattershotInstance;
                scattershotInstance = Instantiate(scatterMissile, middleCannonTop.position, middleCannonTop.rotation) as Rigidbody;
                //scatterMissile.MovePosition(middleCannonTop.transform.position + middleCannonTop.transform.forward * Time.deltaTime);
                scatterMissile.AddForce(middleCannonTop.forward * 3000);

            }*/
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
    void FireLeftMissile()
    {
        if (missileAmmo > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Rigidbody missileInstance;
                missileInstance = Instantiate(missilePrefab, leftCannonTop.position, leftCannonTop.rotation) as Rigidbody;
                missileInstance.AddForce(leftCannonTop.forward * 3000);

                missileAmmo--;
                playMissileClicker.leftPlayerFire = false;
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
    void FireRightMissile()
    {
        if (missileAmmo > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Rigidbody missileInstance;
                missileInstance = Instantiate(missilePrefab, rightCannonTop.position, rightCannonTop.rotation) as Rigidbody;
                missileInstance.AddForce(rightCannonTop.forward * 3000);

                missileAmmo--;
                playMissileClicker.rightPlayerFire = false;
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
