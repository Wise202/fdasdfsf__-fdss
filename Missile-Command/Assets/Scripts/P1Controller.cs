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
    AmmoManager ammoManager;

    /*public int leftAmmo = 20;
    public int middleAmmo = 20;
    public int rightAmmo = 20;
    public int totalAmmo;*/

    public bool leftEmpty = false;
    public bool middleEmpty = false;
    public bool rightEmpty = false;
    public bool totallyEmpty = false;

    void Start()
    {
        playMissileClicker = FindObjectOfType<PlayerMissileClicker>();
        ammoManager = FindObjectOfType<AmmoManager>();

        middleShooter = GameObject.FindGameObjectWithTag("MiddlePlayer");
        leftShooter = GameObject.FindGameObjectWithTag("LeftPlayer");
        rightShooter = GameObject.FindGameObjectWithTag("RightPlayer");

    }

    void Update()
    {
      
        FuckingLook();
        BuyAmmo();
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
        if(ammoManager.leftAmmo == 0)
        {
            leftEmpty = true;
        }
        if(ammoManager.middleAmmo == 0)
        {
            middleEmpty = true;
        }
        if(ammoManager.rightAmmo == 0)
        {
            rightEmpty = true;
        }
        if(leftEmpty == true && middleEmpty == true && rightEmpty == true)
        {
            totallyEmpty = true;
        }
    }

    void FuckingLook()
    {
        transform.LookAt(crosshair);
    }

    void FireMiddleMissile()
    {
        if (ammoManager.middleAmmo > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                Debug.Log("test");
                Rigidbody missileInstance;
                missileInstance = Instantiate(missilePrefab, middleCannonTop.position, middleCannonTop.rotation) as Rigidbody;
                missileInstance.AddForce(middleCannonTop.forward * 3000);

                ammoManager.MiddleMissile();
                playMissileClicker.middlePlayerFire = false;
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                Rigidbody scattershotInstance;
                scattershotInstance = Instantiate(scatterMissile, midScatterLauncher.position, midScatterLauncher.rotation) as Rigidbody;
                scattershotInstance.AddForce(midScatterLauncher.forward * 3000);

                playMissileClicker.middlePlayerFire = false;

            }
            else if (Input.GetMouseButtonDown(2))
            {

            }
            if ((Input.GetButtonDown("Fire1")) || Input.GetButtonDown("Fire2") && mouseClicked == false)
            {
                Debug.Log("test");
                mouseClicked = true;
                mousePos = Input.mousePosition;
            }
            if ((Input.GetButtonUp("Fire1")) || Input.GetButtonUp("Fire2") && mouseClicked == true)
            {
                Debug.Log("test");
                mouseClicked = false;
            }
            
        }
       
        else
            return;

    }
    void FireLeftMissile()
    {
        if (ammoManager.leftAmmo > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                

                Rigidbody missileInstance;
                missileInstance = Instantiate(missilePrefab, leftCannonTop.position, leftCannonTop.rotation) as Rigidbody;
                missileInstance.AddForce(leftCannonTop.forward * 3000);

                ammoManager.LeftMissile();
                playMissileClicker.leftPlayerFire = false;
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                Rigidbody scattershotInstance;
                scattershotInstance = Instantiate(scatterMissile, leftScatterLauncher.position, leftScatterLauncher.rotation) as Rigidbody;
                scattershotInstance.AddForce(leftScatterLauncher.forward * 3000);

                playMissileClicker.leftPlayerFire = false;

            }
            if ((Input.GetButtonDown("Fire1")) || Input.GetButtonDown("Fire2") && mouseClicked == false)
            {
                
                mouseClicked = true;
                mousePos = Input.mousePosition;
            }
            if ((Input.GetButtonUp("Fire1")) || Input.GetButtonUp("Fire2") && mouseClicked == true)
            {
                mouseClicked = false;
            }
        }
        else
            return;

    }
    void FireRightMissile()
    {
        if (ammoManager.rightAmmo > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {                
                
                Rigidbody missileInstance;
                missileInstance = Instantiate(missilePrefab, rightCannonTop.position, rightCannonTop.rotation) as Rigidbody;
                missileInstance.AddForce(rightCannonTop.forward * 3000);

                ammoManager.RightMissile();
                playMissileClicker.rightPlayerFire = false;
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                Rigidbody scattershotInstance;
                scattershotInstance = Instantiate(scatterMissile, rightScatterLauncher.position, rightScatterLauncher.rotation) as Rigidbody;
                scattershotInstance.AddForce(rightScatterLauncher.forward * 3000);

                playMissileClicker.rightPlayerFire = false;
            }
            if ((Input.GetButtonDown("Fire1")) || Input.GetButtonDown("Fire2") && mouseClicked == false)
            {
                
                mouseClicked = true;
                mousePos = Input.mousePosition;
            }
            if ((Input.GetButtonUp("Fire1")) || Input.GetButtonUp("Fire2") && mouseClicked == true)
            {
                mouseClicked = false;
            }
        }
        else
            return;

    }

    public void BuyAmmo()
    {
        if (other.goldAmount > 50f && Input.GetButtonDown("Jump"))
        {
            other.goldAmount -= 50f;
            //middleAmmo += 3;
        }
    }
}
