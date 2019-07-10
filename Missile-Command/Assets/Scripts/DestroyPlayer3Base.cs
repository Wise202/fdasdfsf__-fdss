using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer3Base : MonoBehaviour
{

    public General3 playerThreeHealth;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Missile")
        {
            playerThreeHealth.playerThreeHealth -= 1;
            Destroy(gameObject);
        }
    }

}
