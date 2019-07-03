using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float xCurrent;
    float yCurrent;
    float zCurrent; 


    float xScaleMax = 3f;
    float yScaleMax = 3f;
    float zScaleMax = 3f;

    bool hasExploded = false;
    bool destroySelf = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(xCurrent <= xScaleMax && yCurrent <= yScaleMax && zCurrent <= zScaleMax && hasExploded == false)
        {
            Debug.Log("Expand Boom");
            
            transform.localScale += new Vector3(3f, 3f, 3f) * Time.deltaTime;
            xCurrent = transform.localScale.x;
            yCurrent = transform.localScale.y;
            zCurrent = transform.localScale.z;
            if(xCurrent >= xScaleMax || yCurrent >= yScaleMax || zCurrent >= zScaleMax)
            {
                hasExploded = true;
            }
        }
       else if(hasExploded == true && destroySelf == false)
        {
            Debug.Log("Shrink Boom");
            transform.localScale -= new Vector3(3f, 3f, 3f) * Time.deltaTime;
            xCurrent = transform.localScale.x;
            yCurrent = transform.localScale.y;
            zCurrent = transform.localScale.z;
            if(xCurrent <= 0f || yCurrent <= 0f || zCurrent <= 0f)
            {
                destroySelf = true;
            }
        }
       else if(destroySelf == true)
        {
            Debug.Log("Destroy Explosion");
            Destroy(gameObject);
        }     
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
