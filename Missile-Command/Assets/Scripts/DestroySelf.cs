using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float deathTime;
    public GameObject explosion;

    void Start()
    {
        //explosion = GameObject.FindGameObjectWithTag("Explosion");
    }
    // Update is called once per frame
    void Update()
    {
        deathTime += Time.deltaTime;
        if (deathTime > 3.0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Missile")
        {
            Instantiate(explosion, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
