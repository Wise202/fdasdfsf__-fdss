using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer1Base : MonoBehaviour
{

    public General playerOneHealth;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Missile")
        {
            playerOneHealth.playerOneHealth -= 1;
            Destroy(gameObject);
        }
    }

}
