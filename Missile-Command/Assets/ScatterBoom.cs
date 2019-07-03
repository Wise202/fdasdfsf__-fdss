using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterBoom : MonoBehaviour
{
    public GameObject explosion;
    float deathTime;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        deathTime += Time.deltaTime;
        if(deathTime > 1.0f)
        {
            Instantiate(explosion, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Missile")
        {
            Instantiate(explosion, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
