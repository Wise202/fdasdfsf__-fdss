using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    float deathTimer;


    // Update is called once per frame
    void Update()
    {
        deathTimer++;
        if(deathTimer >= 20f)
        {
            Destroy(gameObject);
        }

    }
    //Upon hitting the vector, destroy itself and the vector.
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Explosion_Point")
        {
            Debug.Log("Hey");
            Destroy(col.gameObject);
            Destroy(gameObject);
            
        }


    }
}
