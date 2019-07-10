using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer2Base : MonoBehaviour
{

    public General2 playerTwoHealth;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Missile")
        {
            playerTwoHealth.playerTwoHealth -= 1;
            Destroy(gameObject);
        }
    }

}
