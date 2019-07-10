using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//github
public class P2Controller : MonoBehaviour
{
    public Transform crosshair2;
    public Rigidbody missilePrefab2;
    public GoldScript2 other2;
    public Text MissileText2;
    public Transform middleCannonTop2;
    public Transform leftCannonTop2;
    public Transform rightCannonTop2;
    public Transform midScatterLauncher2;
    public Transform leftScatterLauncher2;
    public Transform rightScatterLauncher2;
    public Rigidbody scatterMissile2;
    public Vector3 mousePos2;
    public bool mouseClicked2;


    public GameObject missileDestroy2;

    GameObject middleShooter2;
    GameObject leftShooter2;
    GameObject rightShooter2;

    PlayerMissileClicker playMissileClicker2;
    AmmoManager ammoManager2;

    /*public int leftAmmo = 20;
    public int middleAmmo = 20;
    public int rightAmmo = 20;
    public int totalAmmo;*/

    public bool leftEmpty2 = false;
    public bool middleEmpty2 = false;
    public bool rightEmpty2 = false;
    public bool totallyEmpty2 = false;

    void Start()
    {
        playMissileClicker2 = FindObjectOfType<PlayerMissileClicker>();
        ammoManager2 = FindObjectOfType<AmmoManager>();

        middleShooter2 = GameObject.FindGameObjectWithTag("MiddlePlayer");
        leftShooter2 = GameObject.FindGameObjectWithTag("LeftPlayer");
        rightShooter2 = GameObject.FindGameObjectWithTag("RightPlayer");

    }

    void Update()
    {

        FuckingLook();
        BuyAmmo();
        //Check which missile launcher is closest to the cursor to trigger the closest launcher to fire.
        if (playMissileClicker2.middlePlayerFire == true && playMissileClicker2.leftPlayerFire == false && playMissileClicker2.rightPlayerFire == false)
        {
            FireMiddleMissile();
        }
        if (playMissileClicker2.leftPlayerFire == true && playMissileClicker2.middlePlayerFire == false && playMissileClicker2.rightPlayerFire == false)
        {
            FireLeftMissile();
        }
        if (playMissileClicker2.rightPlayerFire == true && playMissileClicker2.leftPlayerFire == false && playMissileClicker2.middlePlayerFire == false)
        {
            FireRightMissile();
        }
        if (ammoManager2.leftAmmo == 0)
        {
            leftEmpty2 = true;
        }
        if (ammoManager2.middleAmmo == 0)
        {
            middleEmpty2 = true;
        }
        if (ammoManager2.rightAmmo == 0)
        {
            rightEmpty2 = true;
        }
        if (leftEmpty2 == true && middleEmpty2 == true && rightEmpty2 == true)
        {
            totallyEmpty2 = true;
        }
    }

    void FuckingLook()
    {
        transform.LookAt(crosshair2);
    }

    void FireMiddleMissile()
    {
        if (ammoManager2.middleAmmo > 0)
        {
            if (Input.GetButtonDown("p2Fire1"))
            {

                Debug.Log("test");
                Rigidbody missileInstance;
                missileInstance = Instantiate(missilePrefab2, middleCannonTop2.position, middleCannonTop2.rotation) as Rigidbody;
                missileInstance.AddForce(middleCannonTop2.forward * 3000);

                ammoManager2.MiddleMissile();
                playMissileClicker2.middlePlayerFire = false;
            }
            else if (Input.GetButtonDown("p2Fire2"))
            {
                Rigidbody scattershotInstance;
                scattershotInstance = Instantiate(scatterMissile2, midScatterLauncher2.position, midScatterLauncher2.rotation) as Rigidbody;
                scattershotInstance.AddForce(midScatterLauncher2.forward * 3000);

                playMissileClicker2.middlePlayerFire = false;

            }
            else if (Input.GetMouseButtonDown(2))
            {

            }
            if ((Input.GetButtonDown("p2Fire1")) || Input.GetButtonDown("p2Fire2") && mouseClicked2 == false)
            {
                Debug.Log("test");
                mouseClicked2 = true;
                mousePos2 = Input.mousePosition;
            }
            if ((Input.GetButtonUp("p2Fire1")) || Input.GetButtonUp("p2Fire2") && mouseClicked2 == true)
            {
                Debug.Log("test");
                mouseClicked2 = false;
            }

        }

        else
            return;

    }
    void FireLeftMissile()
    {
        if (ammoManager2.leftAmmo > 0)
        {
            if (Input.GetButtonDown("p2Fire1"))
            {


                Rigidbody missileInstance;
                missileInstance = Instantiate(missilePrefab2, leftCannonTop2.position, leftCannonTop2.rotation) as Rigidbody;
                missileInstance.AddForce(leftCannonTop2.forward * 3000);

                ammoManager2.LeftMissile();
                playMissileClicker2.leftPlayerFire = false;
            }
            else if (Input.GetButtonDown("p2Fire2"))
            {
                Rigidbody scattershotInstance;
                scattershotInstance = Instantiate(scatterMissile2, leftScatterLauncher2.position, leftScatterLauncher2.rotation) as Rigidbody;
                scattershotInstance.AddForce(leftScatterLauncher2.forward * 3000);

                playMissileClicker2.leftPlayerFire = false;

            }
            if ((Input.GetButtonDown("p2Fire1")) || Input.GetButtonDown("p2Fire2") && mouseClicked2 == false)
            {

                mouseClicked2 = true;
                mousePos2 = Input.mousePosition;
            }
            if ((Input.GetButtonUp("p2Fire1")) || Input.GetButtonUp("p2Fire2") && mouseClicked2 == true)
            {
                mouseClicked2 = false;
            }
        }
        else
            return;

    }
    void FireRightMissile()
    {
        if (ammoManager2.rightAmmo > 0)
        {
            if (Input.GetButtonDown("p2Fire1"))
            {

                Rigidbody missileInstance;
                missileInstance = Instantiate(missilePrefab2, rightCannonTop2.position, rightCannonTop2.rotation) as Rigidbody;
                missileInstance.AddForce(rightCannonTop2.forward * 3000);

                ammoManager2.RightMissile();
                playMissileClicker2.rightPlayerFire = false;
            }
            else if (Input.GetButtonDown("p2Fire2"))
            {
                Rigidbody scattershotInstance;
                scattershotInstance = Instantiate(scatterMissile2, rightScatterLauncher2.position, rightScatterLauncher2.rotation) as Rigidbody;
                scattershotInstance.AddForce(rightScatterLauncher2.forward * 3000);

                playMissileClicker2.rightPlayerFire = false;
            }
            if ((Input.GetButtonDown("p2Fire1")) || Input.GetButtonDown("p2Fire2") && mouseClicked2 == false)
            {

                mouseClicked2 = true;
                mousePos2 = Input.mousePosition;
            }
            if ((Input.GetButtonUp("p2Fire1")) || Input.GetButtonUp("p2Fire2") && mouseClicked2 == true)
            {
                mouseClicked2 = false;
            }
        }
        else
            return;

    }

    public void BuyAmmo()
    {
        if (other2.goldAmount2 > 50f && Input.GetButtonDown("p2Fire3"))
        {
            other2.goldAmount2 -= 50f;


        }
    }
}
