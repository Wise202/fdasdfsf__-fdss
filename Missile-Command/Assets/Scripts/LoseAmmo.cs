using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseAmmo : MonoBehaviour
{
    public P1Controller ammoSupply;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Missile")
        {
            //ammoSupply.missileAmmo -= 10;
            Destroy(gameObject);
        }
    }
}
