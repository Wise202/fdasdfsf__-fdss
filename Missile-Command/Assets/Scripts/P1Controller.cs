using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//github
public class P1Controller : MonoBehaviour
{
    public Transform crosshair;
    public Rigidbody missilePrefab;
    public GoldScript other;
    public Text MissileText;
    public Transform middleCannonTop;
    public Transform leftCannonTop;
    public Transform rightCannonTop;
    public Transform midScatterLauncher;
    public Transform leftScatterLauncher;
    public Transform rightScatterLauncher;
    public Rigidbody scatterMissile;
    public Vector3 mousePos;
    public bool mouseClicked;


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
        MissileText.text = "Ammo: " + missileAmmo.ToString();
        FuckingLook();

        //Check which missile launcher is closest to the cursor to trigger the closest launcher to fire.
        if (playMissileClicker.middlePlayerFire == true && playMissileClicker.leftPlayerFire == false && playMissileClicker.rightPlayerFire == false)
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

    void FuckingLook()
    {
        transform.LookAt(crosshair);
    }

    void FireMiddleMissile()
    {
        if (missileAmmo > 0)
        {
            if (Input.GetAxis("Fire1") > 0)
            {

                Rigidbody missileInstance;
                missileInstance = Instantiate(missilePrefab, middleCannonTop.position, middleCannonTop.rotation) as Rigidbody;
                missileInstance.AddForce(middleCannonTop.forward * 3000);

                missileAmmo--;
                playMissileClicker.middlePlayerFire = false;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Rigidbody scattershotInstance;
                scattershotInstance = Instantiate(scatterMissile, midScatterLauncher.position, midScatterLauncher.rotation) as Rigidbody;
                scattershotInstance.AddForce(midScatterLauncher.forward * 3000);

                playMissileClicker.middlePlayerFire = false;

            }
            else if (Input.GetMouseButtonDown(2))
            {

            }
            if ((Input.GetAxis("Fire1") > 0) || Input.GetMouseButtonDown(1) && mouseClicked == false)
            {
              
                mouseClicked = true;
                mousePos = Input.mousePosition;
            }
            if ((Input.GetAxis("Fire1") > 0) || Input.GetMouseButtonDown(1) && mouseClicked == true)
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
            if (Input.GetAxis("Fire1") > 0)
            {

                Rigidbody missileInstance;
                missileInstance = Instantiate(missilePrefab, leftCannonTop.position, leftCannonTop.rotation) as Rigidbody;
                missileInstance.AddForce(leftCannonTop.forward * 3000);

                missileAmmo--;
                playMissileClicker.leftPlayerFire = false;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Rigidbody scattershotInstance;
                scattershotInstance = Instantiate(scatterMissile, leftScatterLauncher.position, leftScatterLauncher.rotation) as Rigidbody;
                scattershotInstance.AddForce(leftScatterLauncher.forward * 3000);

                playMissileClicker.leftPlayerFire = false;

            }
            if ((Input.GetAxis("Fire1") > 0) || Input.GetMouseButtonDown(1) && mouseClicked == false)
            {
                
                mouseClicked = true;
                mousePos = Input.mousePosition;
            }
            if ((Input.GetAxis("Fire1") > 0) || Input.GetMouseButtonDown(1) && mouseClicked == true)
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
            if (Input.GetAxis("Fire1") > 0)
            {

                Rigidbody missileInstance;
                missileInstance = Instantiate(missilePrefab, rightCannonTop.position, rightCannonTop.rotation) as Rigidbody;
                missileInstance.AddForce(rightCannonTop.forward * 3000);

                missileAmmo--;
                playMissileClicker.rightPlayerFire = false;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Rigidbody scattershotInstance;
                scattershotInstance = Instantiate(scatterMissile, rightScatterLauncher.position, rightScatterLauncher.rotation) as Rigidbody;
                scattershotInstance.AddForce(rightScatterLauncher.forward * 3000);

                playMissileClicker.rightPlayerFire = false;
            }
            if ((Input.GetAxis("Fire1") > 0) || Input.GetMouseButtonDown(1) && mouseClicked == false)
            {
                
                mouseClicked = true;
                mousePos = Input.mousePosition;
            }
            if ((Input.GetAxis("Fire1") > 0) || Input.GetMouseButtonDown(1) && mouseClicked == true)
            {
                mouseClicked = false;
            }
        }
        else
            return;

    }

    public void BuyAmmo()
    {
        if (other.goldAmount > 50f)
        {
            other.goldAmount -= 50f;
            missileAmmo += 3;
        }
    }
}
