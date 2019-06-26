using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMovement : MonoBehaviour
{
    public bool goLeft;

    public float force; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    private void FixedUpdate()
    {
        MoveUFO();
    }

    void MoveUFO()
    {
        if(goLeft == true)
        {
            GetComponent<Rigidbody>().AddForce(-transform.right * force);
        }

        else if(goLeft == false)
        {
            GetComponent<Rigidbody>().AddForce(transform.right * force);
        }
    }
}
