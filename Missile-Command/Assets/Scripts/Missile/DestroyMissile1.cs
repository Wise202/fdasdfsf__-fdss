using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMissile1 : MonoBehaviour
{
    public GameObject explosion;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Destroy(gameObject);
        }

        if (collision.collider.tag == "Base")
        {
            Destroy(gameObject);
        }
        if(collision.collider.tag == "Missile")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}
