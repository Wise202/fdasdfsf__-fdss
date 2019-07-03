using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    float deathTimer;


    // Update is called once per frame
    void Update()
    {
        //In case the missile didn't hit a vector, it will still destroy itself after time off screen.
        deathTimer += Time.deltaTime;
        if(deathTimer >= 3f)
        {
            Destroy(gameObject);
        }

    }
    //Upon hitting the vector, destroy itself.
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Explosion_Point")
        {
            Debug.Log("Hey");
            //Destroy(col.gameObject);
            Destroy(gameObject);
            
        }


    }
}
