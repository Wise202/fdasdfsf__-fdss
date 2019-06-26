using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterBlast : MonoBehaviour
{
    public GameObject scatterBlast;

    float scattersShot;
    float scatterSpread;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Explosion_Point")
        {
            float totalSpread = scatterSpread / scattersShot;
            for(int i = 0; i < scattersShot; i++)
            {
                float spreadA = totalSpread * (i + 1);
                float spreadB = scatterSpread / 2.0f;
                float spread = spreadB - spreadA + totalSpread / 2;
                float angle = transform.eulerAngles.y;

                Quaternion rotation = Quaternion.Euler(new Vector3(0, spread + angle, 0));

                GameObject scatterShot = Instantiate(scatterBlast);
                scatterShot.transform.position = transform.position;
                scatterShot.transform.rotation = rotation;
            }
            Destroy(gameObject);
        }
    }
}
