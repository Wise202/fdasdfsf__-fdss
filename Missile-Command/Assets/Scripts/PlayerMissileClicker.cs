using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//github
public class PlayerMissileClicker : MonoBehaviour
{
    public GameObject cH;
    public Vector3 crosshair;
    public GameObject missileVector;
    Vector3 missilePos;
    Vector3 homingMissilePos;

    Transform homingTarget;

    public LayerMask hitLayer;
    public LayerMask homingLayer;

    public Transform middlePlayer;
    public Transform leftPlayer;
    public Transform rightPlayer;

    Vector3 middlePlayerPos;
    Vector3 leftPlayerPos;
    Vector3 rightPlayerPos;

    public bool middlePlayerFire = false;
    public bool leftPlayerFire = false;
    public bool rightPlayerFire = false;

    P1Controller playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<P1Controller>();
        middlePlayerPos = middlePlayer.transform.position;
        leftPlayerPos = leftPlayer.transform.position;
        rightPlayerPos = rightPlayer.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        crosshair = cH.transform.position;
        //Performs a ray cast to the world based on the mouse position. This creates a vector position which the missile targets, flying towards the target, where it detonates on impact.
        //This lets the player target anywhere on the screen.
        //Additionally, a series of distance checks are run to check which launcher is closest to the target vector, and thus the closest launcher fires.
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
 
            Ray vectorRay = Camera.main.ScreenPointToRay(crosshair);
            RaycastHit hit;
            if(Physics.Raycast(vectorRay, out hit, hitLayer.value))
            {
                //Debug.Log("Centre Player Distance is: " + Vector3.Distance(missilePos, middlePlayerPos));
                //Debug.Log("Left Player Distance is: " + Vector3.Distance(missilePos, leftPlayerPos));
               // Debug.Log("Right Player Distance is: " + Vector3.Distance(missilePos, rightPlayerPos));

                missilePos = hit.point;
                if (Vector3.Distance(crosshair, middlePlayerPos) < Vector3.Distance(crosshair, leftPlayerPos) && Vector3.Distance(crosshair, middlePlayerPos) < Vector3.Distance(crosshair, rightPlayerPos))
                {

                    leftPlayerFire = false;
                    rightPlayerFire = false;
                    middlePlayerFire = true;
                    Instantiate(missileVector, crosshair, Quaternion.identity);
                }
                else if (Vector3.Distance(crosshair, leftPlayerPos) < Vector3.Distance(crosshair, middlePlayerPos) && Vector3.Distance(crosshair, leftPlayerPos) < Vector3.Distance(crosshair, rightPlayerPos))
                {
                    

                    middlePlayerFire = false;
                    rightPlayerFire = false;
                    leftPlayerFire = true;
                    Instantiate(missileVector, crosshair, Quaternion.identity);
                }

                else if (Vector3.Distance(crosshair, rightPlayerPos) < Vector3.Distance(crosshair, middlePlayerPos) && Vector3.Distance(crosshair, rightPlayerPos) < Vector3.Distance(crosshair, leftPlayerPos))
                {

                    middlePlayerFire = false;
                    leftPlayerFire = false;
                    rightPlayerFire = true;
                    Instantiate(missileVector, crosshair, Quaternion.identity);
                }
                else
                    return;      
            }

            
            Debug.DrawRay(vectorRay.origin,vectorRay.direction * 100, Color.red);



            
        }
        else if(Input.GetButtonDown("Fire3"))
        {
            Ray homingRay = Camera.main.ScreenPointToRay(crosshair);
            RaycastHit homingHit;
            if(Physics.Raycast(homingRay, out homingHit, homingLayer.value))
            {
                homingMissilePos = homingHit.point;
                homingTarget = homingHit.transform;
                if (Vector3.Distance(crosshair, middlePlayerPos) < Vector3.Distance(crosshair, leftPlayerPos) && Vector3.Distance(crosshair, middlePlayerPos) < Vector3.Distance(crosshair, rightPlayerPos))
                {

                    leftPlayerFire = false;
                    rightPlayerFire = false;
                    middlePlayerFire = true;
                    //Instantiate(missileVector, crosshair, Quaternion.identity);
                }
                else if (Vector3.Distance(crosshair, leftPlayerPos) < Vector3.Distance(crosshair, middlePlayerPos) && Vector3.Distance(crosshair, leftPlayerPos) < Vector3.Distance(crosshair, rightPlayerPos))
                {


                    middlePlayerFire = false;
                    rightPlayerFire = false;
                    leftPlayerFire = true;
                    //Instantiate(missileVector, crosshair, Quaternion.identity);
                }

                else if (Vector3.Distance(crosshair, rightPlayerPos) < Vector3.Distance(crosshair, middlePlayerPos) && Vector3.Distance(crosshair, rightPlayerPos) < Vector3.Distance(crosshair, leftPlayerPos))
                {

                    middlePlayerFire = false;
                    leftPlayerFire = false;
                    rightPlayerFire = true;
                    //Instantiate(missileVector, crosshair, Quaternion.identity);
                }
                else
                    return;

            }
        }
    }
    public void EmptyLauncher()
    {
        if(playerController.leftEmpty == true)
        {
            if (Vector3.Distance(crosshair, middlePlayerPos) < Vector3.Distance(crosshair, leftPlayerPos) && Vector3.Distance(crosshair, middlePlayerPos) < Vector3.Distance(crosshair, rightPlayerPos))
            {

                leftPlayerFire = false;
                rightPlayerFire = false;
                middlePlayerFire = true;
                Instantiate(missileVector, crosshair, Quaternion.identity);
            }
            else if (Vector3.Distance(crosshair, rightPlayerPos) < Vector3.Distance(crosshair, middlePlayerPos) && Vector3.Distance(crosshair, rightPlayerPos) < Vector3.Distance(crosshair, leftPlayerPos))
            {

                middlePlayerFire = false;
                leftPlayerFire = false;
                rightPlayerFire = true;
                Instantiate(missileVector, crosshair, Quaternion.identity);
            }
            else
                return;
        }

    }
}
