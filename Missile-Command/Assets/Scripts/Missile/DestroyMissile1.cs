using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMissile1 : MonoBehaviour
{
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
    }
}
