using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    float deathTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //deathTimer++;
        if(deathTimer >= 10f)
        {
            Destroy(gameObject);
        }
    }
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
