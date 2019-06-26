using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissileClicker : MonoBehaviour
{
    public GameObject missileVector;

    Vector3 missilePos;
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
           /* RaycastHit hit;
            if(Physics.Raycast(vectorRay, out hit))
            {
                missilePos = hit.point;
                
            }*/
            Debug.DrawRay(vectorRay.origin,vectorRay.direction * 10, Color.red);

            

           missilePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));
            Instantiate(missileVector, missilePos * 10, Quaternion.identity);
        }
    }
}
