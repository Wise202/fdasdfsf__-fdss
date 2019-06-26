using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissileClicker : MonoBehaviour
{
    public GameObject missileVector;
    public GameObject player;
    Vector3 missilePos;
    Vector3 playerPos;
    Vector3 missileTarget;
    public LayerMask hitLayer;
    // Start is called before the first frame update
    void Start()
    {
        
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
                missilePos = hit.point;
                Instantiate(missileVector, missilePos, Quaternion.identity);
            }

            
            Debug.DrawRay(vectorRay.origin,vectorRay.direction * 100, Color.red);

            

           //missilePos = Camera.main.scr(Input.mousePosition);
           //playerPos = player.transform.position;
           //missileTarget = new Vector3(missilePos.x * 10, missilePos.y * 10, playerPos.z);

            //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));

            
        }
    }
}
