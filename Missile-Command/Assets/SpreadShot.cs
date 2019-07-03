using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShot : MonoBehaviour
{
    public GameObject scatterShot;

    public bool exploded = false;
    float spreadTimer;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        spreadTimer += Time.deltaTime;
        if(spreadTimer >= 1f)
        {
            exploded = true;
        }
        if(exploded == true)
        {
            CreateBullet(-15f);
            CreateBullet(0f);
            CreateBullet(15f);
            exploded = false;
        }
      

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Explosion_Point")
        {
            exploded = true;
        }
    }
    void CreateBullet(float angleOffset = 0f)
    {
        GameObject scatter = Instantiate(scatterShot);
        scatter.transform.position = transform.position;

        Rigidbody rigidbody = scatter.GetComponent<Rigidbody>();
        rigidbody.AddForce(Quaternion.AngleAxis(angleOffset, Vector3.forward) * transform.right * 100.0f);
    }
}
