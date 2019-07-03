using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterSpread : MonoBehaviour
{
    public GameObject scatterShot;

    float spreadTimer;
    bool exploded = false;


    // Update is called once per frame
    void Update()
    {
        spreadTimer += Time.deltaTime;
        if(spreadTimer > 0.5f)
        {
            exploded = true;
        }
        if(exploded == true)
        {
            CreateScatterBullet(-30f);
            CreateScatterBullet(0f);
            CreateScatterBullet(30f);
            exploded = false;
            Destroy(gameObject);
        }
    }

    void CreateScatterBullet(float angleOffset = 0f)
    {
        GameObject bullet = Instantiate(scatterShot);
        bullet.transform.position = transform.position;

        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.AddForce(Quaternion.AngleAxis(angleOffset, Vector3.forward) * transform.right * 100.0f);
    }
}
