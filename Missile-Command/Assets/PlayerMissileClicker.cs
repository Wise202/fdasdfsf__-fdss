using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissileClicker : MonoBehaviour
{
    public GameObject missileVector;
    Vector3 missilePos;
    public LayerMask hitLayer;

    public Transform middlePlayer;
    public Transform leftPlayer;
    public Transform rightPlayer;

    Vector3 middlePlayerPos;
    Vector3 leftPlayerPos;
    Vector3 rightPlayerPos;

    public bool middlePlayerFire = false;
    public bool leftPlayerFire = false;
    public bool rightPlayerFire = false;
    // Start is called before the first frame update
    void Start()
    {
        middlePlayerPos = middlePlayer.transform.position;
        leftPlayerPos = leftPlayer.transform.position;
        rightPlayerPos = rightPlayer.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetButtonDown("Fire1"))
        {
 
            Ray vectorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(vectorRay, out hit, hitLayer.value))
            {
                Debug.Log("Centre Player Distance is: " + Vector3.Distance(missilePos, middlePlayerPos));
                Debug.Log("Left Player Distance is: " + Vector3.Distance(missilePos, leftPlayerPos));
                Debug.Log("Right Player Distance is: " + Vector3.Distance(missilePos, rightPlayerPos));

                missilePos = hit.point;
                if (Vector3.Distance(missilePos, middlePlayerPos) < Vector3.Distance(missilePos, leftPlayerPos) && Vector3.Distance(missilePos, middlePlayerPos) < Vector3.Distance(missilePos, rightPlayerPos))
                {

                    leftPlayerFire = false;
                    rightPlayerFire = false;
                    middlePlayerFire = true;
                    Instantiate(missileVector, missilePos, Quaternion.identity);
                }
                else if (Vector3.Distance(missilePos, leftPlayerPos) < Vector3.Distance(missilePos, middlePlayerPos) && Vector3.Distance(missilePos, leftPlayerPos) < Vector3.Distance(missilePos, rightPlayerPos))
                {
                    

                    middlePlayerFire = false;
                    rightPlayerFire = false;
                    leftPlayerFire = true;
                    Instantiate(missileVector, missilePos, Quaternion.identity);
                }

                else if (Vector3.Distance(missilePos, rightPlayerPos) < Vector3.Distance(missilePos, middlePlayerPos) && Vector3.Distance(missilePos, rightPlayerPos) < Vector3.Distance(missilePos, leftPlayerPos))
                {

                    middlePlayerFire = false;
                    leftPlayerFire = false;
                    rightPlayerFire = true;
                    Instantiate(missileVector, missilePos, Quaternion.identity);
                }
                else
                    return;      
            }

            
            Debug.DrawRay(vectorRay.origin,vectorRay.direction * 100, Color.red);

            

           //missilePos = Camera.main.scr(Input.mousePosition);
           //playerPos = player.transform.position;
           //missileTarget = new Vector3(missilePos.x * 10, missilePos.y * 10, playerPos.z);

            //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));

            
        }
    }
}
